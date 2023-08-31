using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class MetodosExtensao
    {
        public static DateTime StringParaData(this string _date)
        {
            return Convert.ToDateTime(_date, new CultureInfo("pt-BR"));
        }

        public static string DataFormatadaBR(this string _date)
        {
            var dataBr = Convert.ToDateTime(_date, CultureInfo.InvariantCulture);

            var stringBr = dataBr.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            return stringBr;
        }
        
    }
}
