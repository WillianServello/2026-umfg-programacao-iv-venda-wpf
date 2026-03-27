using projetoVendas.Interfaces;
using projetoVendas.Models;
using projetoVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projetoVendas.UserControls
{
    /// <summary>
    /// Interação lógica para ucReceberPedido.xam
    /// </summary>
    public partial class ucReceberPedido : UserControl
    {

        //Isso daqui é pra validação, pra quando a pessoa clicar e não selecionar, indicar que ela deve escolher
        public ucReceberPedido()
        {
            InitializeComponent();
        }

        private void ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is ReceberPedidoViewModel vm)
            {
                vm.Validar();
            }
        }
        private ucReceberPedido(IObserver observer, ModelPedido pedido)
        {
            InitializeComponent();
            DataContext = new ReceberPedidoViewModel(this, observer, pedido);
        }

        internal static void Exibir(IObserver observer, ModelPedido pedido)
        {
            (new ucReceberPedido(observer, pedido).DataContext as ReceberPedidoViewModel).Notify();
        }
    }
}
