using projetoVendas.Interfaces;
using projetoVendas.ViewModels;
using System;
using System.Windows.Input;

namespace projetoVendas.Commands
{
    internal class VoltarCommand : ICommand
    {
        private readonly ReceberPedidoViewModel _viewModel;

        public VoltarCommand(ReceberPedidoViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true; 
        }

        public void Execute(object? parameter)
        {
            if (_viewModel.MainWindow is MainWindowViewModel main)
            {
                //PRA MIM LEMBRAR, MEIO QUE ESSE TELA ANTERIOR ELE SALVA A TELA QUE A GENTE ESTAVA ANTES, MEIO GAMBIARRA, MAS COM PROPOSITO SO DE VOLTAR ESSA PAGINA SERVE 
                main.UserControl = main.TelaAnterior;
            }
        }
    }
}