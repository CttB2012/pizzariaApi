using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IClienteService
    {
        string CadastrarNovoCliente(Cliente cliente);

        List<Cliente> ListaTodosClientes();

        Cliente ListaClientePorId(int id);

        bool ExcluiClientePelaId(int id);

        Cliente AtualizaCliente(Cliente cliente, int id);
    }
}
