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
        private void ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is ReceberPedidoViewModel vm)
            {
                vm.ValidarCartaoSelecionado();
            }
        }

        private void ApenasNumero(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void FormatarValidade(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            var texto = textBox.Text.Replace("/", "");

            if (texto.Length > 2)
                texto = texto.Insert(2, "/");

            textBox.Text = texto;
            textBox.SelectionStart = textBox.Text.Length;
        }
        //private void NumeroCartao_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (DataContext is ReceberPedidoViewModel vm)
        //    {
        //        vm.ValidarNumeroCartao();
        //    }
        //}
        //private void NomeCartao_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (DataContext is ReceberPedidoViewModel vm)
        //    {
        //        vm.ValidarNomeCartao();
        //    }
        //}
        //private void DataValidadePicker_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (DataContext is ReceberPedidoViewModel vm)
        //    {
        //        vm.ValidarDataValidade();
        //    }
        //}












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
