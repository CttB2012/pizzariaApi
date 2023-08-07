using Dapper;
using Entidades;
using MySql.Data.MySqlClient;
using Repositorios.Interfaces;
using System.Collections.Generic;

namespace Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        public Pedido InserirNovoPedido(Pedido pedido)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"INSERT INTO pedidos(id, origemDoPedido, itensDoPedidoId, clienteId) VALUES({pedido.Id}, '{(int)pedido.OrigemDoPedido}', '{pedido.ItensDoPedidoId}', '{pedido.ClienteId}' )";

            instrucaoSql.ExecuteNonQuery();
            return pedido;
        }

        public List<Pedido> ListaTodosOsPedidos()
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = "SELECT * FROM pedidos";

            var listaDePedidos = conexao.Query<Pedido>(instrucaoSql).ToList();
            return listaDePedidos;
        }

        public Pedido ListaPedidoPelaId(int id)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = $"SELECT * FROM pedidos WHERE id = {id}";

            var resultado = conexao.Query<Pedido>(instrucaoSql).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }
            return null;
        }

        public bool ExcluirPedido(int id)
        {
            var pedidoParaExcluir = ListaPedidoPelaId(id);

            if (pedidoParaExcluir != null)
            {
                using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
                conexao.Open();
                using var instrucaoSql = new MySqlCommand();

                instrucaoSql.Connection = conexao;

                instrucaoSql.CommandText = $"DELETE FROM pedidos WHERE id = {id}";
                instrucaoSql.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public Pedido AtualizarPedido(Pedido pedidoRequest, int id)
        {
            var pedidoNoBD = ListaPedidoPelaId(id);
            if (pedidoNoBD == null)
            {
                return null;
            }
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText = 
                $"UPDATE `pedidos` SET `id` = {pedidoRequest.Id}, `origemDoPedido` = '{(int)pedidoRequest.OrigemDoPedido}', `itensDoPedidoId` = '{pedidoRequest.ItensDoPedidoId}', `clienteId` = '{pedidoRequest.ClienteId}' WHERE `id` = {id}";

            instrucaoSql.ExecuteNonQuery();
            return pedidoRequest;
        }
    }
}
