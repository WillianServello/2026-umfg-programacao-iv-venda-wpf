using projetoVendas.Abstract;
using projetoVendas.Commands;
using projetoVendas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace projetoVendas.ViewModels
{
    internal sealed class MainWindowViewModel : AbstractViewModel, IObserver
    {
       
        private UserControl _userControl;

        public UserControl UserControl
        {
            get => _userControl;
            set => SetField(ref _userControl, value, true);
        }

        public ListarProdutosCommand ListarProdutos { get; private set; } = new();

        public MainWindowViewModel() : base("UMFG - Tela Principal")
        {
            
        }

        public void Update(ISubject subject)
        {
            if (subject is ListarProdutoViewModel)
                UserControl = (subject as ListarProdutoViewModel).UserControl;
            if (subject is ReceberPedidoViewModel)
                UserControl = (subject as ReceberPedidoViewModel).UserControl;
        }
    }
} 
