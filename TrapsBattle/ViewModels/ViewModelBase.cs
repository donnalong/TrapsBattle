using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrapsBattle.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T field, T value, Action<T, T> onValueChanged = null, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(field, value))
            {
                T oldValue = field;
                field = value;

                OnPropertyChanged(propertyName);
                onValueChanged?.Invoke(oldValue, value);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
