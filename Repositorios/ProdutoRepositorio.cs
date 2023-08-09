using Dapper;
using Entidades;
using MySql.Data.MySqlClient;
using Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public Produto CadastrarNovoProduto(Produto produto)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"INSERT INTO produtos(id, nome, preco, descricao, categoriaId) VALUES({produto.Id}, '{produto.Nome}', {produto.Preco}, '{produto.Descricao}', {produto.CategoriaId})";

            instrucaoSql.ExecuteNonQuery();

            return produto;
        }
        public List<Produto> ListarTodosProdutos()
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = "SELECT * FROM produtos";

            var listaDeProdutos = conexao.Query<Produto>(instrucaoSql).ToList();
            return listaDeProdutos;
        }

        public Produto ListarProdutoPorId(int id)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = $"SELECT * FROM produtos WHERE id = {id}";

            var produtoEncontrado = conexao.Query<Produto>(instrucaoSql).FirstOrDefault();

            if (produtoEncontrado != null)
            {
                return produtoEncontrado;
            }
            return null;
        }

        public bool ExcluirProduto(int id)
        {
            var produtoParaExcluir = ListarProdutoPorId(id);

            if (produtoParaExcluir != null)
            {
                using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
                conexao.Open();
                using var instrucaoSql = new MySqlCommand();

                instrucaoSql.Connection = conexao;

                instrucaoSql.CommandText = $"DELETE FROM produtos WHERE id = {id}";
                instrucaoSql.ExecuteNonQuery();

                return true;
            }
            return false;
        }

        public Produto AtualizarProduto(Produto produtoRequest, int id)
        {
            var produtoParaAtualizar = ListarProdutoPorId(id);
            if (produtoParaAtualizar == null)
            {
                return null;
            }
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"UPDATE `produtos` SET `id` = {produtoRequest.Id}, `nome` = '{produtoRequest.Nome}', `preco` = {produtoRequest.Preco}, `descricao` = '{produtoRequest.Descricao}', `categoriaId` = {produtoRequest.CategoriaId}  WHERE `id` = {id}";

            instrucaoSql.ExecuteNonQuery();
            return produtoRequest;
        }
    }
}
