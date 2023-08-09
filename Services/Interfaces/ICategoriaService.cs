using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoriaService
    {
        public string CadastrarNovaCategoria(Categoria categoria);

        public List<Categoria> ListarTodasCategorias();
        Categoria ListarCategoriaPorId(int id);
        bool ExcluirCategoria(int id);
        Categoria AtualizarCategoria(Categoria categoria, int id);
    }
}
