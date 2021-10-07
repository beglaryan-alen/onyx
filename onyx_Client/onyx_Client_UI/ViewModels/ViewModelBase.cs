using onyx_Client_UI.State.Navigators;
using System.Collections.Generic;
using System.ComponentModel;

namespace onyx_Client_UI.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetPropertyChanged<T>(string propertyName, ref T field, T newValue)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
