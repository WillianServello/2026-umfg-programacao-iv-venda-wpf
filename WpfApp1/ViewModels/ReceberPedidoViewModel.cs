using projetoVendas.Abstract;
using projetoVendas.Interfaces;
using projetoVendas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
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

        private string _cartaoSelecionado;
        private long _numeroCartao;
        private long _cvv;
        private DateTime _dataValidade = DateTime.MinValue;
        private string _nomeCartao = string.Empty;

        public List<string> TiposCartao
        {
            get => _tiposCartao;
            set => SetField(ref _tiposCartao, value, true);
        }
        
        [Required(ErrorMessage = "Por favor selecione o cartão")]
        public string CartaoSelecionado
        {
            get => _cartaoSelecionado;
            set => SetField(ref _cartaoSelecionado, value, true);
        }

        public long NumeroCartao 
        { 
            get => _numeroCartao; 
            set => SetField(ref _numeroCartao, value, true);
        }
        public long CVV
        { 
            get => _cvv; 
            set => SetField(ref _cvv, value, true);
        }
        public DateTime DataValidade
        {
            get => _dataValidade;
            set => SetField(ref _dataValidade, value, true);
        }
        public string NomeCartao
        {
            get => _nomeCartao;
            set => SetField(ref _nomeCartao, value, true);
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
        public void Validar()
        {
            ValidateAllProperties();
        }
    }
}
