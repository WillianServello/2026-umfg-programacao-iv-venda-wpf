using projetoVendas.Abstract;
using projetoVendas.Interfaces;
using projetoVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace projetoVendas.ViewModels
{
    internal class ReceberPedidoViewModel : AbstractViewModel
    {

        private ModelPedido _pedido = new ModelPedido();
        private long _numeroCartao = 0;
        private long _cvv = 0;
        private DateTime _dataValidade = DateTime.MinValue;
        private string _nomeCartao = string.Empty;

        public long NumeroCartao 
        { 
            get => _numeroCartao; 
            set => SetField(ref _numeroCartao, value);
        }
        public long CVV
        { 
            get => _cvv; 
            set => SetField(ref _cvv, value);
        }
        public DateTime DataValidade
        {
            get => _dataValidade;
            set => SetField(ref _dataValidade, value);
        }
        public string NomeCartao
        {
            get => _nomeCartao;
            set => SetField(ref _nomeCartao, value);
        }

        public ModelPedido Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value);
        }

        public ReceberPedidoViewModel(UserControl userControl, IObserver observer, ModelPedido pedido) : base("Receber Pedido")
        {
            UserControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
            MainWindow = observer ?? throw new ArgumentNullException(nameof(observer));
            Pedido = pedido ?? throw new ArgumentNullException(nameof(observer)); 

            Add(observer);
        }
    }
}
