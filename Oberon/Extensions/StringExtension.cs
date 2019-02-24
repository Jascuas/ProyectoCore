using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Extensions
{
    public static class StringExtension
    {
        public static int 
            GetNumeroPalabras(this String objetotexto)
        {
            return objetotexto.Split(' ').Count();
        }
    }
}
