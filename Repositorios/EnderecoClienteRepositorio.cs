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
    public class EnderecoClienteRepositorio : IEnderecoClienteRepositorio
    {
        public EnderecoCliente IncluirNovoEndereco(EnderecoCliente enderecoCliente)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"INSERT INTO enderecoClientes(id, logradouro, numero, bairro, cidade, estado, pais, cep, clienteId) VALUES({enderecoCliente.Id}, '{enderecoCliente.Logradouro}', '{enderecoCliente.Numero}', '{enderecoCliente.Bairro}', '{enderecoCliente.Cidade}', '{enderecoCliente.Estado}', '{enderecoCliente.Pais}', '{enderecoCliente.Cep}', '{enderecoCliente.ClienteId}')";

            instrucaoSql.ExecuteNonQuery();
            return enderecoCliente;
        }

        public List<EnderecoCliente> ListarEnderecos()
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = "SELECT * FROM enderecoclientes";

            var listaDeEnderecos = conexao.Query<EnderecoCliente>(instrucaoSql).ToList();
            return listaDeEnderecos;
        }

        public EnderecoCliente ListarEnderecoPelaId(int id)
        {
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            string instrucaoSql = $"SELECT * FROM enderecoclientes WHERE id = {id}";

            var enderecoEncontrado = conexao.Query<EnderecoCliente>(instrucaoSql).FirstOrDefault();

            if (enderecoEncontrado != null)
            {
                return enderecoEncontrado;
            }
            return null;
        }

        public bool ExcluirEndereco(int id)
        {
            var enderecoParaExcluir = ListarEnderecoPelaId(id);

            if (enderecoParaExcluir != null)
            {
                using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
                conexao.Open();
                using var instrucaoSql = new MySqlCommand();

                instrucaoSql.Connection = conexao;

                instrucaoSql.CommandText = $"DELETE FROM enderecoclientes WHERE id = {id}";
                instrucaoSql.ExecuteNonQuery();

                return true;
            }
            return false;
        }

        public EnderecoCliente AtualizarEndereco(EnderecoCliente enderecoRecebido, int id)
        {
            var enderecoParaAtualizar = ListarEnderecoPelaId(id);
            if (enderecoParaAtualizar == null)
            {
                return null;
            }
            using var conexao = new MySqlConnection(Utils.CONNECTION_STRING);
            conexao.Open();

            using var instrucaoSql = new MySqlCommand();
            instrucaoSql.Connection = conexao;

            instrucaoSql.CommandText =
                $"UPDATE `enderecoclientes` SET `id`  = {enderecoRecebido.Id}, `logradouro` = '{enderecoRecebido.Logradouro}', `numero` = {enderecoRecebido.Numero}, `bairro` = '{enderecoRecebido.Bairro}', `cidade` = '{enderecoRecebido.Cidade}', `estado` = '{enderecoRecebido.Estado}', `pais` = '{enderecoRecebido.Pais}', `cep` = {enderecoRecebido.Cep}, `clienteId` = {enderecoRecebido.ClienteId} WHERE `id` = {id}";
            
            instrucaoSql.ExecuteNonQuery();
            return enderecoRecebido;
        }
    }
}

