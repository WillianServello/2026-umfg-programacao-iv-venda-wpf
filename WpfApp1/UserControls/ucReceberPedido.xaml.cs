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

        private void FormatarCartao(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            // remove espaços
            var texto = textBox.Text.Replace(" ", "");

            // limita a 16 (ou pode usar 19 se quiser mais completo)
            if (texto.Length > 16)
                texto = texto.Substring(0, 16);

            // adiciona espaço a cada 4 dígitos
            var formatado = "";
            for (int i = 0; i < texto.Length; i++)
            {
                if (i > 0 && i % 4 == 0)
                    formatado += " ";

                formatado += texto[i];
            }

            textBox.Text = formatado;
            textBox.SelectionStart = textBox.Text.Length;
        }

        //Validacao de apenas Numeros
        private void ApenasNumero(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        //Validacao de apenas letras
        private void ApenasLetras(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }

        //DATA VALIDADE LOGICA
        private void FormatarValidade(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            var texto = textBox.Text.Replace("/", "");

            if (texto.Length > 2)
                texto = texto.Insert(2, "/");

            textBox.Text = texto;
            textBox.SelectionStart = textBox.Text.Length;

            //ESSE CARA FAZ COM QUE O USUARIO NAO CONSIGA DIGITAR ESPACO
            if (textBox.Text.Contains(" "))
            {
                textBox.Text = textBox.Text.Replace(" ", "");
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        // CVV LOGICA
     
        // COPIEI DO DE CIMA JA QUE E A MESMA COISA SO QUE PRO CVV
        private void RemoverEspacos(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox.Text.Contains(" "))
            {
                textBox.Text = textBox.Text.Replace(" ", "");
                textBox.SelectionStart = textBox.Text.Length;
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
