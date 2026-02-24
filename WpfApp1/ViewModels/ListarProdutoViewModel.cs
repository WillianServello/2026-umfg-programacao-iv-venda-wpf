using projetoVendas.Models;
using projetoVendas.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace projetoVendas.ViewModels
{
    internal sealed class ListarProdutoViewModel : AbstractViewModel
    {
        private ModelProduto _produtoSelecionado = new();
        private ObservableCollection<ModelProduto> _produtos = [];

        public ModelProduto ProdutoSelecionado
        {
            get => _produtoSelecionado;
            set => SetField(ref _produtoSelecionado, value);
        }
        public ObservableCollection<ModelProduto> Produtos
        {
            get => _produtos;
            set => SetField(ref _produtos, value);
        }

        public ListarProdutoViewModel(string titulo) : base("Produtos")
        {
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            Produtos.Clear();

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net-8.0-windows\Images\batata.png", UriKind.Relative)),
                Descricao = "Batata Frita 300gr",
                Referencia = "0001",
                Valor = 10.90m,
            });

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net-8.0-windows\Images\batata.png", UriKind.Relative)),
                Descricao = "Batata Frita 300gr",
                Referencia = "0001",
                Valor = 10.90m,
            });

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net-8.0-windows\Images\combo.png", UriKind.Relative)),
                Descricao = "Combo BIG MAC + BATATA 300GR + REFIL 500ML",
                Referencia = "0002",
                Valor = 49.90m,
            });

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net-8.0-windows\Images\lanche.png", UriKind.Relative)),
                Descricao = "Big Mac 350g",
                Referencia = "0003",
                Valor = 25.90m,
            });

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net-8.0-windows\Images\refrigerante.png", UriKind.Relative)),
                Descricao = "Refrigerante Refil 500ml",
                Referencia = "0004",
                Valor = 10.90m,
            });

        }
    }
    }
