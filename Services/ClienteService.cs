using Entidades;
using Repositorios;
using Repositorios.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteService : IClienteService
    {
        public const string CLIENTE_CADASTRADO = "Cliente cadastrado";
        public const string CLIENTE_NAO_PERMITIDO = "Cliente Nulo não permitido";

        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteService(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public string CadastrarNovoCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                var clienteCadastrado = _clienteRepositorio.CadastrarNovoCliente(cliente);
                return CLIENTE_CADASTRADO;
            }
            return CLIENTE_NAO_PERMITIDO;
        }

        public List<Cliente> ListaTodosClientes()
        {
            var listaDeClientes = _clienteRepositorio.ListaTodosClientes();
            return listaDeClientes;
        }

        public Cliente ListaClientePorId(int id)
        {
            var clienteEncontrado = _clienteRepositorio.ListaClientePorId(id);
            return clienteEncontrado;
        }

        public bool ExcluiClientePelaId(int id)
        {
            var clienteParaExluir = _clienteRepositorio.ExcluiClientePelaId(id);
            return clienteParaExluir;
        }

        public Cliente AtualizaCliente(Cliente cliente, int id)
        {
            var clienteAtualizado = _clienteRepositorio.AtualizaCliente(cliente, id);
            return clienteAtualizado;
        }
    }
}
