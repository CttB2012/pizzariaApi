using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Categoria CadastrarNovaCategoria(Categoria categoria);
        List<Categoria> ListarTodasCategorias();
        Categoria ListarCategoriaPorId(int id);
        bool ExcluirCategoria(int id);
        Categoria AtualizarCategoria(Categoria categoriaRequest, int id);
    }
}
