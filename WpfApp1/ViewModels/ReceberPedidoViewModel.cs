using CommunityToolkit.Mvvm.ComponentModel;
using projetoVendas.Abstract;
using projetoVendas.Commands;
using projetoVendas.Interfaces;
using projetoVendas.Models;
using projetoVendas.Validador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;
namespace projetoVendas.ViewModels
{
    internal class ReceberPedidoViewModel : AbstractViewModel
    {
        private ModelPedido _pedido = new ModelPedido();
        private List<string> _tiposCartao = new()
        {
                                                            
            "Cartão de Crédito",
            "Cartão de Débito"
        };

        private string? _cartaoSelecionado;
        private string? _numeroCartao;
        private string? _cvv;
        private string? _dataValidade;    
        private string? _nomeCartao = string.Empty;


        public FinalizarPedidoCommand Finalizar { get; private set; } = new();
        public void ValidarTudo()
        {
            ValidateAllProperties();
        }

        public void RaiseCanExecuteChanged()
        {
            Finalizar.RaiseCanExecuteChanged();
        }
        public List<string> TiposCartao
        {
            get => _tiposCartao;
            set => SetField(ref _tiposCartao, value, true);
        }

        [Required(ErrorMessage = "Por favor selecione o cartão")]
        public string? CartaoSelecionado
        {
            get => _cartaoSelecionado;
            set
            {
                SetField(ref _cartaoSelecionado, value, true);
                ValidateProperty(value, nameof(CartaoSelecionado));
                RaiseCanExecuteChanged();
            }
        }

        [Required(ErrorMessage = "Por favor informe o nome do cartão")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "Apenas letras são permitidas")]
        [StringLength(26, MinimumLength = 2, ErrorMessage = "Informe com tamanho válido")]
        public string? NomeCartao
        {
            get => _nomeCartao;
            set
            {
                SetField(ref _nomeCartao, value, true);
                ValidateProperty(value, nameof(NomeCartao));
                RaiseCanExecuteChanged();
            }

        }
        
        // NUMERO CARTAO - USANDO O LUHN, RAPAZ E BOM DEMAIS ESSE DATAANNOTATION
        [Required(ErrorMessage = "Por favor informe o numero do cartão")]
        [RegularExpression(@"^[0-9 ]+$", ErrorMessage = "Apenas números")]
        [StringLength(19, MinimumLength = 13, ErrorMessage = "Tamanho inválido")]
        [CustomValidation(typeof(ValidadorCartao), nameof(ValidadorCartao.ValidarLuhn))]
        public string? NumeroCartao
        {
            get => _numeroCartao;
            set {
                SetField(ref _numeroCartao, value, true);
                ValidateProperty(value, nameof(NumeroCartao));
                RaiseCanExecuteChanged();
            }
        }

        // DATA VALIDADE
        [Required(ErrorMessage = "Por favor informe a data de validade")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{4}$", ErrorMessage = "Formato inválido (MM/YYYY)")]
        [CustomValidation(typeof(ValidadorCartao), nameof(ValidadorCartao.ValidarData))]
        public string? DataValidade
        {
            get => _dataValidade;
            set
            {
                SetField(ref _dataValidade, value, true);
                ValidateProperty(value, nameof(DataValidade));
                RaiseCanExecuteChanged();
            }
        }

        // CVV
        [Required(ErrorMessage = "Por favor informe o CVV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV deve conter 3 caracteres") ]
        public string? CVV
        { 
            get => _cvv;
            set
            {
                SetField(ref _cvv, value, true);
                ValidateProperty(value, nameof(CVV));
                RaiseCanExecuteChanged();
            }
        }

        public ModelPedido Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value, true);
        }

        public ReceberPedidoViewModel(UserControl userControl, IObserver observer, ModelPedido pedido) : base("Receber Pedido")
        {
            UserControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
            MainWindow = observer ?? throw new ArgumentNullException(nameof(observer));
            Pedido = pedido ?? throw new ArgumentNullException(nameof(observer));

            Add(observer);
        }
        public void ValidarCartaoSelecionado()
        {
            ValidateProperty(CartaoSelecionado, nameof(CartaoSelecionado));
        }
    }
}
