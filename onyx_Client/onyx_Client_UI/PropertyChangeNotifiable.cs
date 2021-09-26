using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI
{
	public class PropertyChangeNotifiable : INotifyPropertyChanged
	{
		protected void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null && this != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
				System.Windows.Input.CommandManager.InvalidateRequerySuggested();
			}

		}

		protected bool RaisePropertyChanged<T>(ref T field, T value, Expression<Func<T>> memberExpression)
		{
			//compile error
			//if (field != value)
			//	return false;

			if (field == null && value == null)
				return false;

			if ((field != null && value == null) ||
				(field == null && value != null) ||
				!field.Equals(value))
			{
				field = value;
				SetProperty(memberExpression);
				return true;
			}
			else
				return false;
		}

		protected bool RaisePropertyChanged<T>(Expression<Func<T>> memberExpression)
		{
			SetProperty(memberExpression);
			return true;
		}

		private void SetProperty<T>(Expression<Func<T>> memberExpression)
		{
			if (memberExpression == null)
			{
				throw new ArgumentNullException("memberExpression");
			}
			var body = memberExpression.Body as MemberExpression;
			if (body == null)
			{
				throw new ArgumentException("Lambda must return a property.");
			}

			var vmExpression = body.Expression as ConstantExpression;
			if (vmExpression != null)
			{
				LambdaExpression lambda = System.Linq.Expressions.Expression.Lambda(vmExpression);
				Delegate vmFunc = lambda.Compile();
				object sender = vmFunc.DynamicInvoke();

				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));
					System.Windows.Input.CommandManager.InvalidateRequerySuggested();
				}
			}
		}

		protected void SetPropertyChanged<T>(string propertyName, ref T field, T newValue)
		{
			if (!EqualityComparer<T>.Default.Equals(field, newValue))
			{
				field = newValue;
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
