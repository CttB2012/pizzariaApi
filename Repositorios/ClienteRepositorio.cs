using Dapper;
using Entidades;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Repositorios.Interfaces;

namespace Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public Cliente CadastrarNovoCliente(Cliente cliente)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"INSERT INTO clientes(id, nomeCompleto, dataNascimento, email, celular, cpf, enderecoId) VALUES({cliente.Id}, '{cliente.NomeCompleto}', '{cliente.DataNascimento}', '{cliente.Email}', '{cliente.Celular}', '{cliente.Cpf}', {cliente.EnderecoId})";

            instrucaoSql.ExecuteNonQuery();

            return cliente;
        }

        public List<Cliente> ListaTodosClientes()
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = "SELECT * FROM clientes";

            var listaDeClientes = conexao.Query<Cliente>(instrucaoSql).ToList();
            return listaDeClientes;
        }

        public Cliente ListaClientePorId(int id)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = $"SELECT * FROM clientes WHERE id = {id}";

            var clienteEncontrado = conexao.Query<Cliente>(instrucaoSql).FirstOrDefault();

            if (clienteEncontrado != null)
            {
                return clienteEncontrado;
            }
            return null;
        }

        public bool ExcluiClientePelaId(int id)
        {
            var clienteParaExcluir = ListaClientePorId(id);

            if (clienteParaExcluir != null)
            {
                using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
                conexao.Open();
                using var instrucaoSql = new MySqlCommand();

                instrucaoSql.Connection = conexao;

                instrucaoSql.CommandText = $"DELETE FROM clientes WHERE id = {id}";
                instrucaoSql.ExecuteNonQuery();

                return true;
            }
            return false;
        }

        public Cliente AtualizaCliente(Cliente clienteNovo, int id)
        {
            var clienteNaBase = ListaClientePorId(id);
            if (clienteNaBase == null)
            {
                return null;
            }
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"UPDATE `clientes` SET `id` = {clienteNovo.Id}, `nomeCompleto` = '{clienteNovo.NomeCompleto}', `dataNascimento`= '{clienteNovo.DataNascimento}', " +
                                    $"`email` = '{clienteNovo.Email}', `celular` = '{clienteNovo.Celular}', " +
                                    $"`cpf` = '{clienteNovo.Cpf}', `enderecoId` = '{clienteNovo.EnderecoId}'  WHERE `id` = {id}";

            instrucaoSql.ExecuteNonQuery();
            return clienteNovo;
        }

    }
}