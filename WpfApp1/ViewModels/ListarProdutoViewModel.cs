using projetoVendas.Abstract;
using projetoVendas.Commands;
using projetoVendas.Interfaces;
using projetoVendas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace projetoVendas.ViewModels
{
    internal sealed class ListarProdutoViewModel : AbstractViewModel
    {
        private ModelProduto _produtoSelecionado = new();
        private ObservableCollection<ModelProduto> _produtos = [];
        private ModelPedido _pedido = new();

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

        public ModelPedido Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value);
        }

        public AdicionarProdutoPedidoCommand Adicionar { get; private set; } = new();

        public RemoverProdutoPedidoCommand Remover { get; private set; } = new();

        public ReceberPedidoCommand Receber { get; private set; } = new();

        public ListarProdutoViewModel(IObserver observer, UserControl userControl) : base("Produtos")
        {
            UserControl = userControl;
            MainWindow = observer;

            Add(observer);
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            Produtos.Clear();

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net8.0-windows\Imagens\batata.png", UriKind.Relative)),
                Descricao = "Batata Frita 300gr",
                Referencia = "0001",
                Valor = 10.90m,
            });

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net8.0-windows\Imagens\combo.png", UriKind.Relative)),
                Descricao = "Combo BIG MAC + BATATA 300GR + REFIL 500ML",
                Referencia = "0002",
                Valor = 49.90m,
            });

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net8.0-windows\Imagens\lanche.png", UriKind.Relative)),
                Descricao = "Big Mac 350g",
                Referencia = "0003",
                Valor = 25.90m,
            });

            Produtos.Add(new ModelProduto()
            {
                Imagem = new BitmapImage(new Uri(@"..\net8.0-windows\Imagens\refrigerante.png", UriKind.Relative)),
                Descricao = "Refrigerante Refil 500ml",
                Referencia = "0004",
                Valor = 10.90m,
            });

        }
    }
    }
