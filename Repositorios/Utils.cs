using Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class Utils
    {
        public const string CONNECTION_STRING = "server=localhost;userid=root;password=123456;database=projetopizzaria";

        public static string DataFormatada(DateTime _date)
        {
            var data = _date.ToString("yyyy-MM-dd");
            return data;
        }
        //public static string DataFormatada2(DateTime _date) => _date.ToString("yyyy-MM-dd"); Outra forma de fazer o metodo DataFormatada acima     

        public static string DataFormatada(string _date)
        {
            var dataBr = Convert.ToDateTime(_date, new CultureInfo("pt-BR"));

            return dataBr.ToString("yyyy-MM-dd");
        }

        public static string CelularFormatado(string _celular)
        {
            var celularPadrao = string.Format("{0:(##)#####-####}", double.Parse(_celular));
            return celularPadrao;
        }

        public static string CpfFormatado(string _cpf)
        {
            {
                var cpf = string.Format("{0}.{1}.{2}-{3}", _cpf.Substring(0, 3), _cpf.Substring(3, 3), _cpf.Substring(6, 3), _cpf.Substring(9, 2));
                return cpf;
            }
        }
    }
}
