using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoVendas.Models
{
    public sealed class ModelPedido
    {
        private Guid _id = Guid.NewGuid();
        private decimal _total = 0.0m;
        private ObservableCollection<ModelProduto> _produtos = [];

        public Guid Id { get => _id; set => _id = value; }
        public decimal Total { get => _total; set => _total = value; }
        public ObservableCollection<ModelProduto> Produtos { get => _produtos; set => _produtos = value; }


    }
}
