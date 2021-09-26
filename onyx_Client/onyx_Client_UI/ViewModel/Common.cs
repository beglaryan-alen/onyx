using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace onyx_Client_UI.ViewModel
{
    public class WindowedBaseVM: PropertyChangeNotifiable
    {
        public WindowedBaseVM()
        {
        }


        static protected PageBaseVM _currentPageVM = null;
        /// <summary>
        /// Текущий DataContext. Соотвествует текущему состоянию Flow.UIMain. 
        /// То есть, соотвествует текущему Page (MainWindow.Content).
        /// Без учета наличия блокирующих \ модальных окон
        /// </summary>
        static public PageBaseVM CurrentPageVM { get { return _currentPageVM; } }


        static protected WindowedBaseVM _activeVM = null;
        /// <summary>
        /// Активный DataContext. DataContext с учетом возможного наличия блокирующих \ модальных окон.
        /// При их отсуствии возвращает PageBase.Current
        /// </summary>
        static public WindowedBaseVM ActiveVM
        {
            get
            {
                return _activeVM ?? _currentPageVM;
            }
        }


        //заголовок окна, на случай его динамического изменения
        private string _title;
        public string Title { get { return _title; } set { RaisePropertyChanged(ref _title, value, () => Title); } }





        /// <summary>
        /// !не вызывать!, Вызывается при активации окна или замене его DataContext
        /// </summary>
        virtual internal void _Activate()
        {
            _activeVM = this;
            Activated();
        }

        /// <summary>
        /// !не вызывать!, Вызывается при деактивации окна
        /// </summary>
        virtual internal void _Deactivate()
        {
            Deactivated();
            _activeVM = null;
        }

        /// <summary>
        /// Вызывается после смены Page для "новой" VM или при активации модального окна
        /// </summary>
        public virtual void Activated()
        {
        }

        /// <summary>
        /// Вызывается при смене Page (перед), когда текущая VM заменяется новой или при деактивации модального окна.
        /// Текущая VM  в этом методе должна завершить все действия, иницированные в процессе своего функционирования
        /// (дождаться завершения операции...)
        /// Все "завершения" должны быть закончены на выходе из этого метода (в потоке вызова).
        /// </summary>
        public virtual void Deactivated()
        {
        }


        /// <summary>
        /// Допустимо ли прерывание текущего контекста путем авторизации пользователя
        /// По умолчанию для админских контекстов - нет (бессмысленно)
        /// По умолчанию для клиентских контекстов - да, но в некоторых случаях нет.
        /// Причина, по которой прерываение клиентского контекста невозможна, 
        /// должна быть объяснена в сообщении на экране.
        /// </summary>
        internal virtual bool CanUserInterrupt { get { return false; } }

        /// <summary>
        /// Закрывает окно (предполагается модальное), связаное с этой ViewModel
        /// </summary>
        /// <param name="dialogResult"></param>
        protected void CloseBoundWindow(bool? dialogResult)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                var boundWnd = Application.Current.Windows.Cast<Window>().First((w) => this.Equals(w.DataContext)); //упадем, если не найдется. И это правильно...
                boundWnd.DialogResult = dialogResult;
                boundWnd.Close();
            }));
        }
    }


    public class PageBaseVM : WindowedBaseVM
    {
        /// <summary>
        /// !не вызывать!, Вызывается после смены Page для "новой" VM
        /// </summary>
        override internal void _Activate()
        {
            _currentPageVM = this;
            Activated();
        }

        /// <summary>
        /// !не вызывать!, Вызывается перед сменой Page для "старой" VM
        /// </summary>
        override internal void _Deactivate()
        {
            Deactivated();
            _currentPageVM = null;
        }

        /// <summary>
        /// Ожидает, когда загрузится page (Activated) c требуемым VM
        /// Для использования в активностях Workflow (Flow.UIMain). (TODO)
        /// Обычно в методах Execute, когда Workflow может опережать по времени UI navigation
        /// При неправильном использовании может стать причиной вечного цикла.
        /// !!!В этом случае для начала нужно УБЕДИТЬСЯ, что данный вызов не происходит в потоке UI!!! (Важно!)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static internal T WaitCurrentPageVM<T>() where T : class
        {
            T vm = null;
            while (ViewModel.WindowedBaseVM.CurrentPageVM == null)
                System.Threading.Thread.Yield();
            vm = ViewModel.WindowedBaseVM.CurrentPageVM as T;
            System.Diagnostics.Debug.Assert(vm != null);
            return vm;
        }

    }

}
