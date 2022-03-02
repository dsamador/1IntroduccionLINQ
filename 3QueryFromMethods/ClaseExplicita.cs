using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3QueryFromMethods
{
    internal class ClaseExplicita
    {
        private static string[] postres = { "pay de manzana", "tres leches", "fresas con crema", "fresas con almibar" };

        //creamos el query
        //no puede usarse de forma implicita
        //debe ser estatico
        private static IEnumerable<string> encontrados = from p in postres 
                                                         where p.Contains("fresas") 
                                                         orderby p select p;
        private static int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        //el metodo regresa y todo se trabaja internamente
        public static IEnumerable<int> ObtenerNumerosPares()
        {
            
            var pares = numeros.Where(x => x % 2 == 0);
            return pares;
        }

        public static IEnumerable<string> ObtenerPostres()
        {
            return encontrados;
        }

        //metodo que regresa el resultado de un query inmediato
        public static IEnumerable<int> Impares()
        {
            var impares = numeros.Where(x => x % 2 != 0);
            return impares.ToArray();
        }
    }
}
