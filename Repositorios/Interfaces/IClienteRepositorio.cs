using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        Cliente CadastrarNovoCliente(Cliente cliente);

        List<Cliente> ListaTodosClientes();

        Cliente ListaClientePorId(int id);

        bool ExcluiClientePelaId(int id);

        Cliente AtualizaCliente(Cliente cliente, int id);

    }
}
