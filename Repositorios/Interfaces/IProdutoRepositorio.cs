using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Produto CadastrarNovoProduto(Produto produto);
        List<Produto> ListarTodosProdutos();
        Produto ListarProdutoPorId(int id);
        bool ExcluirProduto(int id);
        Produto AtualizarProduto(Produto produtoRequest, int id);
    }
}
