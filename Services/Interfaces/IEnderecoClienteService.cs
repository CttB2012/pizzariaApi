using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEnderecoClienteService 
    {
        string IncluirNovoEndereco(EnderecoCliente enderecoCliente);
        List<EnderecoCliente> ListarEnderecos();
        EnderecoCliente ListarEnderecoPelaId(int id);
        bool ExcluirEndereco(int id);
        EnderecoCliente AtualizarEndereco(EnderecoCliente endereco, int id);
    }
}
