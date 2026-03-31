using projetoVendas.Interfaces;
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
    /// Interação lógica para ucListarProdutos.xam
    /// </summary>
    public partial class ucListarProdutos : UserControl
    {
        public ucListarProdutos()
        {
        }

        private ucListarProdutos(IObserver observer)
        {
            InitializeComponent();
            DataContext = new ListarProdutoViewModel(observer, this);
        }

        internal static void Show(IObserver observer)
        {
            (new ucListarProdutos(observer).DataContext as ListarProdutoViewModel).Notify();
        }
    }
}
