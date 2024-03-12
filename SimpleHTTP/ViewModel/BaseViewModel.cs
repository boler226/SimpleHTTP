using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHTTP.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged // дозволяє підписуватися на події зміни властивостей і відображати ці зміни в інтерфейсі користувача.
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
