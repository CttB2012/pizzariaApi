using Entidades;
using MySqlX.XDevAPI;
using Repositorios;
using Repositorios.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProdutoService : IProdutoService
    {
        public const string PRODUTO_CADASTRADO = "Produto cadastrado com sucesso";
        public const string PRODUTO_NAO_PERMITIDO = "Para continuar, um produto deve ser informado";

        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio; 
        }

        public string CadastrarNovoProduto(Produto produto)
        {
            if (produto != null)
            {
                var produtoCadastrado = _produtoRepositorio.CadastrarNovoProduto(produto);
                return PRODUTO_CADASTRADO;
            }
            return PRODUTO_NAO_PERMITIDO;
        }

        public List<Produto> ListarTodosProdutos()
        {
            var listaDeProdutos = _produtoRepositorio.ListarTodosProdutos();
            return listaDeProdutos;
        }

        public Produto ListarProdutoPorId(int id)
        {
            var produtoEncontrado = _produtoRepositorio.ListarProdutoPorId(id);
            return produtoEncontrado;
        }

        public bool ExcluirProduto(int id)
        {
            var produtoParaExluir = _produtoRepositorio.ExcluirProduto(id);
            return produtoParaExluir;
        }

        public Produto AtualizarProduto(Produto produto, int id)
        {
            var produtoAtualizado = _produtoRepositorio.AtualizarProduto(produto, id);
            return produtoAtualizado;
        }
    }
}
