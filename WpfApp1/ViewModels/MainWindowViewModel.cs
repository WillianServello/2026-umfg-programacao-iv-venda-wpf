using projetoVendas.Interfaces;
using projetoVendas.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace projetoVendas.ViewModels
{
    internal sealed class MainWindowViewModel : AbstractViewModel, IObserver
    {
       
        private UserControl _userControl;

        public UserControl UserControl
        {
            get => _userControl;
            set => SetField(ref _userControl, value);
        }

        public MainWindowViewModel() : base("UMFG - Tela Principal")
        {
            
        }

        public void Update(ISubject subject)
        {
            throw new NotImplementedException();
        }
    }
}
