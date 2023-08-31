using Entidades;
using Repositorios;
using Repositorios.Interfaces;
using Services.Interfaces;
using System.Reflection.Metadata;

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
            cliente.Cpf = cliente.Cpf.Trim();
            cliente.Cpf = cliente.Cpf.Replace(".", "").Replace("-", "");

            cliente.Celular = cliente.Celular.Trim();
            cliente.Celular = cliente.Celular.Replace("(", "").Replace(")", "").Replace("-", "");


            if (cliente == null)
            {
                return CLIENTE_NAO_PERMITIDO;
            }
            if (UtilsService.IsCpf(cliente.Cpf) == false)
            {
                return CPF_INVALIDO;
            }
            if (UtilsService.IsMaiorDeIdade(cliente.DataNascimento.StringParaData()) == false)
            {
                return MENOR_NAO_PERMITIDO;
            }
            _clienteRepositorio.CadastrarNovoCliente(cliente);
            return CLIENTE_CADASTRADO;
        }

        public List<Cliente> ListaTodosClientes()
        {
            var listaDeClientes = _clienteRepositorio.ListaTodosClientes();

            listaDeClientes.ForEach(documento => documento.Cpf = Utils.CpfFormatado(documento.Cpf));
            listaDeClientes.ForEach(cel => cel.Celular = Utils.CelularFormatado(cel.Celular));

            listaDeClientes.ForEach(clienteNascimento =>
            {
                clienteNascimento.DataNascimento = clienteNascimento.DataNascimento.DataFormatadaBR();
            });


            return listaDeClientes;
        }

        public Cliente ListaClientePorId(int id)
        {
            var clienteEncontrado = _clienteRepositorio.ListaClientePorId(id);

            clienteEncontrado.Celular = Utils.CelularFormatado(clienteEncontrado.Celular);
            clienteEncontrado.Cpf = Utils.CpfFormatado(clienteEncontrado.Cpf);
            clienteEncontrado.DataNascimento = clienteEncontrado.DataNascimento.DataFormatadaBR();

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
