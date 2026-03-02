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
    internal sealed class AdicionarProdutoPedidoCommand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            //parameter é convertdo para o tipo 'ListarProdutosViewModel' usando a expressao 'as'
            var vm = parameter as ListarProdutoViewModel;
            

            //implementado Fail First (clean Code)
            if (vm == null)
            {
                MessageBox.Show("Parâmetro obrigatório não foi informado");
                return;
            }

            if(vm.Pedido is null || Guid.Empty.Equals(vm.Pedido.Id))
            {
                MessageBox.Show("Pedido não foi criado corretamente! Verifique. ");
                return;
            }

            if(vm.ProdutoSelecionado is null || Guid.Empty.Equals(vm.ProdutoSelecionado.Id))
            {
                MessageBox.Show("Nenhum produto selecionado! Verifique");
                return;
            }

            var result = 
                MessageBox.Show("Deseja realmente incluir este item no carrinho?", "Confirma produto", MessageBoxButton.YesNo);

            if (!MessageBoxResult.Yes.Equals(result))
            {
                return;
            }
            vm.Pedido.Produtos.Add(vm.ProdutoSelecionado); //Adicionar o produto selecionado no pedido
            vm.Pedido.Total = vm.Pedido.Produtos.Sum(x => x.Valor); // atualizar o sub-total do pedido
        }
    }
}
