using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StepperApp.Models
{
    [DataContract(IsReference = true)]
    [Serializable]
    public abstract class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void NotifyPropertyChanged(string propName)
        {
            PropertyChanged(this,
                new PropertyChangedEventArgs(propName));
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        //разрешить кольцевые изменения свойств
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            else
            {
                field = value;
                OnPropertyChanged(PropertyName);
                return true;
            }
        }
    }
}
