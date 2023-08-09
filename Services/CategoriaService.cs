using Entidades;
using Repositorios.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriaService : ICategoriaService
    {
        public const string CATEGORIA_CADASTRADA = "Nova categoria cadastrada";
        public const string CATEGORIA_NAO_PERMITIDA = "A categoria não pode ser nula";
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaService(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public string CadastrarNovaCategoria(Categoria categoria)
        {
            if (categoria != null)
            {
                var novaCategoria = _categoriaRepositorio.CadastrarNovaCategoria(categoria);
                return CATEGORIA_CADASTRADA;
            }
            return CATEGORIA_NAO_PERMITIDA;
        }

        public List<Categoria> ListarTodasCategorias()
        {
            var listaDeCategorias = _categoriaRepositorio.ListarTodasCategorias();
            return listaDeCategorias;
        }

        public Categoria ListarCategoriaPorId(int id)
        {
            var categoria = _categoriaRepositorio.ListarCategoriaPorId(id);
            return categoria;
        }

        public bool ExcluirCategoria(int id)
        {
            var categoriaParaExcluir = _categoriaRepositorio.ExcluirCategoria(id);
            return categoriaParaExcluir;
        }

        public Categoria AtualizarCategoria(Categoria categoria, int id)
        {
            var categoriaAtualizada = _categoriaRepositorio.AtualizarCategoria(categoria, id);
            return categoriaAtualizada;
        }
    }
}
