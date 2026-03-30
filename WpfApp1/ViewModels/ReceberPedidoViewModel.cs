using CommunityToolkit.Mvvm.ComponentModel;
using projetoVendas.Abstract;
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



        public List<string> TiposCartao
        {
            get => _tiposCartao;
            set => SetField(ref _tiposCartao, value, true);
        }

        [Required(ErrorMessage = "Por favor selecione o cartão")]
        public string? CartaoSelecionado
        {
            get => _cartaoSelecionado;
            set => SetField(ref _cartaoSelecionado, value, true);
        } 

        [Required(ErrorMessage = "Por favor informe o nome do cartão")]
        public string? NomeCartao
        {
            get => _nomeCartao;
            set => SetField(ref _nomeCartao, value, true);
        }

        [Required(ErrorMessage = "Por favor informe o numero do cartão")]
        public string? NumeroCartao
        {
            get => _numeroCartao;
            set => SetField(ref _numeroCartao, value, true);
        }

        // DATA VALIDADE
        [Required(ErrorMessage = "Por favor informe a data de validade")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Formato inválido (MM/YY)")]
        [CustomValidation(typeof(ValidadorCartao), nameof(ValidadorCartao.ValidarData))]
        public string? DataValidade
        {
            get => _dataValidade;
            set
            {
                SetField(ref _dataValidade, value, true);
                ValidateProperty(value, nameof(DataValidade));
            }

        }
        // CONVERTIDA DATA POR QUE ESTOU USANDO STRING PRA PEGAR MAIS FACIL DO FRONT, SE PRECISAR
        //public DateTime? DataValidadeConvertida
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(DataValidade))
        //            return null;

        //        var partes = DataValidade.Split('/');

        //        if (partes.Length != 2)
        //            return null;

        //        if (!int.TryParse(partes[0], out int mes) ||
        //            !int.TryParse(partes[1], out int ano))
        //            return null;

        //        ano += 2000; // transforma 26 em 2026

        //        return new DateTime(ano, mes, 1);
        //    }
        //}

        [Required(ErrorMessage = "Por favor informe o CVV")]
        public string? CVV
        { 
            get => _cvv; 
            set => SetField(ref _cvv, value, true);
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
        public void ValidarNumeroCartao()
        {
            ValidateProperty(NumeroCartao, nameof(NumeroCartao));
        }
        public void ValidarNomeCartao()
        {
            ValidateProperty(NomeCartao, nameof(NomeCartao));
        }
        public void ValidarCVV()
        {
            ValidateProperty(CVV, nameof(CVV));
        }
    }
}
