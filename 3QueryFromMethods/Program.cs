using System;
using System.Collections.Generic;
using System.Linq;

namespace _3QueryFromMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //obtener resultados de query desde metodos

            //invocamos el metodo
            IEnumerable<int> resultados = ClaseExplicita.ObtenerNumerosPares();

            //mostramos los resultados
            foreach (var item in resultados)
                Console.WriteLine(item);

            Console.WriteLine("----------");

            IEnumerable<string> postres = ClaseExplicita.ObtenerPostres();

            //resultados
            foreach (var item in postres)
                Console.WriteLine(item);

            Console.WriteLine("----------");

            var impares = ClaseExplicita.Impares();
            foreach (var item in impares)
                Console.WriteLine(item);
        }        
    }
}
