using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace projetoVendas.Abstract
{
    internal abstract class AbstractNotifyPropertyChange : ObservableValidator
    {
        protected bool SetField<T>(ref T field, T value, bool validate = false, [CallerMemberName] string propertyName = null)
        {
            return SetProperty(ref field, value, validate, propertyName);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetField<T>(ref T field, T value,
            [CallerMemberName] string nameProperty = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaizePropertyChange(nameProperty);
            }
        }

        private void RaizePropertyChange(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }
    }
}
