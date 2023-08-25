using Entidades;
using Repositorios.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class ClienteService : IClienteService
    {
        public const string CLIENTE_CADASTRADO = "Cliente cadastrado";
        public const string CLIENTE_NAO_PERMITIDO = "Cliente Nulo não permitido";
        public const string CPF_INVALIDO = "CPF inválido. Verifique o número informado";
        public const string MENOR_NAO_PERMITIDO = "Você deve ser maior de idade para se cadastrar";


        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteService(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public string CadastrarNovoCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return CLIENTE_NAO_PERMITIDO;
            }
            if (UtilsService.IsCpf(cliente.Cpf) == false)
            {
                return CPF_INVALIDO;
            }
            if (UtilsService.IsMaiorDeIdade(cliente.DataNascimento) == false)
            {
                return MENOR_NAO_PERMITIDO;
            }
            _clienteRepositorio.CadastrarNovoCliente(cliente);
            return CLIENTE_CADASTRADO;
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
