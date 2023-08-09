using Dapper;
using Entidades;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public Categoria CadastrarNovaCategoria(Categoria categoria)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"INSERT INTO categorias(id, nome) VALUES({categoria.Id}, '{categoria.Nome}')";

            instrucaoSql.ExecuteNonQuery();
            return categoria;
        }

        public List<Categoria> ListarTodasCategorias()
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = "SELECT * FROM categorias";

            var listaDeCategorias = conexao.Query<Categoria>(instrucaoSql).ToList();
            return listaDeCategorias;
        }

        public Categoria ListarCategoriaPorId(int id)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = $"SELECT * FROM categorias WHERE id = {id}";

            var categoria = conexao.Query<Categoria>(instrucaoSql).FirstOrDefault();

            if (categoria != null)
            {
                return categoria;
            }
            return null;
        }
        public bool ExcluirCategoria(int id)
        {
            var categoriaParaExcluir = ListarCategoriaPorId(id);

            if (categoriaParaExcluir != null)
            {
                using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
                conexao.Open();
                using var instrucaoSql = new MySqlCommand();

                instrucaoSql.Connection = conexao;

                instrucaoSql.CommandText = $"DELETE FROM categorias WHERE id = {id}";
                instrucaoSql.ExecuteNonQuery();

                return true;
            }
            return false;
        }
        public Categoria AtualizarCategoria(Categoria categoriaRequest, int id)
        {
            var categoriaNaBase = ListarCategoriaPorId(id);
            if (categoriaNaBase == null)
            {
                return null;
            }
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"UPDATE `categorias` SET `id` = {categoriaRequest.Id}, `nome` = '{categoriaRequest.Nome}' WHERE `id` = {id}";

            instrucaoSql.ExecuteNonQuery();
            return categoriaRequest;
        }
    }
}
