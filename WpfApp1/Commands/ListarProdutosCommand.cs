using projetoVendas.Abstract;
using projetoVendas.UserControls;
using projetoVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoVendas.Commands
{
    internal sealed class ListarProdutosCommand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            ucListarProdutos.Show(parameter as MainWindowViewModel);
        }
    }
}
