using projetoVendas.Abstract;
using projetoVendas.UserControls;
using projetoVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace projetoVendas.Commands
{
    internal sealed class ReceberPedidoCommand : AbstractCommand
    {

        //TODO: habilitar este botão apenas quando um produto for adicionado no carrinho
        public override bool CanExecute(object? parameter)
        {
            var vm = parameter as ListarProdutoViewModel;

            return vm is not null && vm.Pedido.Produtos.Any();
        }

        public override void Execute(object? parameter)
        {
            var vm = parameter as ListarProdutoViewModel;

            //Para o usuario final em teoria nao importa esse teste
            //mas é fundamental para garantir a qualidade de codigo a longo prazo
            

            ucReceberPedido.Exibir(vm.MainWindow, vm.Pedido);


        }
    }
}
