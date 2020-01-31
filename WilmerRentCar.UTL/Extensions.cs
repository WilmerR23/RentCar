using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.UTL
{
    public static class Extensions
    {

        public static string generateShaText(this string clave)
        {
            return string.Concat(new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(clave)).Select(b => b.ToString("x2")));
        }
    }
}
