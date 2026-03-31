using projetoVendas.Abstract;
using projetoVendas.UserControls;
using projetoVendas.ViewModels;
using System.Linq;
using System.Windows;

namespace projetoVendas.Commands
{
    internal sealed class FinalizarPedidoCommand : AbstractCommand
    {
        public override bool CanExecute(object? parameter)
        {
            var vm = parameter as ReceberPedidoViewModel;
            
            // ✔ só precisa ter produto (ignora validação como você pediu)
            return vm is not null
       && vm.Pedido.Produtos.Any()
       && !vm.HasErrors; ;
        }

        public override void Execute(object? parameter)
        {
            var vm = parameter as ReceberPedidoViewModel;

            if (vm is null)
                return;

            // 🔥 chama validação pelo ViewModel
            vm.ValidarTudo();

            if (vm.HasErrors)
            {
                MessageBox.Show("Preencha corretamente os campos!");
                return;
            }

            vm.Pedido.Produtos.Clear();
            vm.Pedido.Total = 0;

            vm.MainWindow.Update(
                new ListarProdutoViewModel(vm.MainWindow, new ucListarProdutos())
            );

            MessageBox.Show("Pedido finalizado!");
        }
    }
}