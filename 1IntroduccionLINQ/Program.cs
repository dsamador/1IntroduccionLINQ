using System;
using System.Collections.Generic;
using System.Linq;

namespace _1IntroduccionLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //queries sencillos con arreglos y reflexion

            //ejemplo con numeros
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, };

            //hacemos el query
            IEnumerable<int> valores = from n in numeros
                                       where n > 3 && n < 8
                                       select n;
            //query con extension methods
            var valores2 = numeros.Where(x => x > 3 && x < 8);


            foreach (var item in valores)            
                Console.WriteLine(item);
            
            Console.WriteLine("-------");
            
            foreach (var item in valores2)            
                Console.WriteLine(item);

            Console.WriteLine("---------------------");
            Console.WriteLine("Cadenas");

            string[] postres = { "pay de manzana", "tres leches", "fresas con crema", "fresas con almibar" };

            //query
            var encontrado = postres.Where(x => x.Contains("fresas"));

            foreach (var item in encontrado)
                Console.WriteLine(item);

            Console.WriteLine("---------------");

            InfoResultados(valores);
            Console.WriteLine("-------");
            InfoResultados(valores2);
            Console.WriteLine("-------");
            InfoResultados(encontrado);
        }

        static void InfoResultados(object resultados)
        {
            Console.WriteLine($"Tipo {resultados.GetType().Name}");
            Console.WriteLine($"Locacion {resultados.GetType().Assembly.GetName().Name}");
        }
    }
}
