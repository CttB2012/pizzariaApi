using Entidades;
using Repositorios.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EnderecoClienteService : IEnderecoClienteService
    {
        public const string NOVO_ENDERECO = "Novo endereco inserido";
        public const string NULO_NAO_PERMITIDO = "Os campos devem ser informados ";

        private readonly IEnderecoClienteRepositorio _enderecoCLienteRepositorio;
       
        public EnderecoClienteService(IEnderecoClienteRepositorio enderecoClienteRepositorio)
        {
            _enderecoCLienteRepositorio = enderecoClienteRepositorio;
        }

        public string IncluirNovoEndereco(EnderecoCliente enderecoCliente)
        {
            if (enderecoCliente != null)
            {
                var novoEndereco = _enderecoCLienteRepositorio.IncluirNovoEndereco(enderecoCliente);
                return NOVO_ENDERECO;
            }
            return NULO_NAO_PERMITIDO;
        }
        
        public List<EnderecoCliente> ListarEnderecos()
        {
            var listaDeEnderecos = _enderecoCLienteRepositorio.ListarEnderecos();
            return listaDeEnderecos;
        }

        public EnderecoCliente ListarEnderecoPelaId(int id)
        {
            var enderecoEncontrado = _enderecoCLienteRepositorio.ListarEnderecoPelaId(id);
            return enderecoEncontrado;
        }

        public bool ExcluirEndereco(int id)
        {
            var enderecoExcluido = _enderecoCLienteRepositorio.ExcluirEndereco(id);
            return enderecoExcluido;
        }

        public EnderecoCliente AtualizarEndereco(EnderecoCliente endereco, int id)
        {
            var enderecoAtualizado = _enderecoCLienteRepositorio.AtualizarEndereco(endereco, id);
            return enderecoAtualizado;
        }
    }
}
