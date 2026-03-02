using projetoVendas.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoVendas.Models
{
    internal sealed class ModelPedido : AbstractModel
    {
        private Guid _id = Guid.NewGuid();
        private decimal _total = 0.0m;
        private ObservableCollection<ModelProduto> _produtos = [];

        public Guid Id 
        { 
            get => _id;
            set => SetField(ref _id, value); 
        }
        public decimal Total 
        { 
            get => _total; 
            set => SetField(ref _total, value); 
        }
        public ObservableCollection<ModelProduto> Produtos 
        { 
            get => _produtos; 
            set => SetField(ref _produtos, value);
        }


    }
}
