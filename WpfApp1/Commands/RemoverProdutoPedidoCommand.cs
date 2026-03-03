using projetoVendas.Abstract;
using projetoVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace projetoVendas.Commands
{
    internal sealed class RemoverProdutoPedidoCommand : AbstractCommand
    {
        public override bool CanExecute(object? parameter)
        {
            var vm = parameter as ListarProdutoViewModel;

            //o método Any() indica que a lista possui ao menos um registro
            return vm is not null && vm.Pedido.Produtos.Any();

        }

        public override void Execute(object? parameter)
        {
            var vm = parameter as ListarProdutoViewModel;

            if (vm is null)
            {
                MessageBox.Show("Parâmetro obrigatorio não informado! Verifique.");
                return;
            }

            if(vm.ProdutoSelecionado is null || Guid.Empty.Equals(vm.ProdutoSelecionado.Id))
            {
                MessageBox.Show("Nenhum produto selecionado para remover do carringo!"); 
                return;
            }
            //testa se o item selecionado pelo usuario consta na lista de itens do pedido
            //utilizado a passagem instrucao lambda no metodo Any()
            if (!vm.Pedido.Produtos.Any(x => x.Id == vm.ProdutoSelecionado.Id))
            {
                return;
            }

            var result =
                MessageBox.Show("Deseja realmente remover este item no carrinho?", "Confirma produto", MessageBoxButton.YesNo);
            if (!MessageBoxResult.Yes.Equals(result))
            {
                return;
            }

            vm.Pedido.Produtos.Remove(vm.ProdutoSelecionado);
            vm.Pedido.Total = vm.Pedido.Produtos.Sum(x => x.Valor);
            vm.RaiseCanExecuteChanged();
        }
    }
}
