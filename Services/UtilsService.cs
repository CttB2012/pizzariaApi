using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Services
{
    public class UtilsService
    {

        public const int MAIORIDADE = 18;

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public static string DataFormatada(DateTime _date)
        {
            string stringData = "";

            _date = DateTime.Parse("yyyy-MM-dd");
            stringData = _date.ToString("dd-MM-yyyy");
            
            return stringData;
        }

        public static bool IsMaiorDeIdade(DateTime dataNascimento)
        {
            var dataFormatada = DataFormatada(dataNascimento);

            var idade = (int) ((DateTime.Now - dataNascimento).TotalDays/365.242199);
            if (idade < MAIORIDADE )
            {
                return false;
            }            
            return true;
        }

    }
}


//string dataFormatada = idade.ToString("yyyy-MM-dd");

