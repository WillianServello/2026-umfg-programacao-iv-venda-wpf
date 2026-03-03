using projetoVendas.Abstract;
using projetoVendas.Interfaces;
using projetoVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace projetoVendas.ViewModels
{
    internal class ReceberPedidoViewModel : AbstractViewModel
    {
        private ModelPedido _pedido = new ModelPedido();

        public ModelPedido Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value);
        }

        public ReceberPedidoViewModel(UserControl userControl, IObserver observer, ModelPedido pedido) : base("Receber Pedido")
        {
            UserControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
            MainWindow = observer ?? throw new ArgumentNullException(nameof(observer));
            Pedido = pedido ?? throw new ArgumentNullException(nameof(observer)); 

            Add(observer);
        }
    }
}
