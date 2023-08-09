using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProdutoService
    {
        string CadastrarNovoProduto(Produto produto);
        List<Produto> ListarTodosProdutos();
        Produto ListarProdutoPorId(int id);
        bool ExcluirProduto(int id);
        Produto AtualizarProduto(Produto produto, int id);
    }
}
