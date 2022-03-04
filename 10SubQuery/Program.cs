using System;
using System.Collections.Generic;
using System.Linq;

namespace _10SubQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Una subquery es una query que esta contenida en la
            //expresion lambda de otra query
            //El scope que tiene existe dentro de la expresion
            //que lo contiene
            string[] postres = {"pay de manzana",
                                "tres leches",
                                "fresas con almibar",
                                "fresas con crema",
                                "manzana caramelizada"
                                };

            //Ordenamos alfabeticamente de acuerdo a la ultima palabra
            //de cada elemento.
            //Split divide en una coleccion a la cadena
            //p.Split().Last() es la subquery

            IEnumerable<string> resultados = 
                postres.OrderBy(p => p.Split().Last());
            //Mostramos los resultados
            foreach (string postre in resultados)
                Console.WriteLine($"Postre: {postre}");

            Console.WriteLine("------------");

            int[] numeros = { 13, 23, 32, 41, 10, 1, 3, 5, 74, 2, 3 };

            IEnumerable<int> numeros2 = numeros
                .Where(n => n < numeros.First());//numeros menores a 13
            foreach (int n in numeros2)
                Console.WriteLine(n);

            Console.WriteLine("------------");

            IEnumerable<int> numeros3 = numeros
                .Where(x => x <= (numeros.Where(n => n %2 == 0)).First());

            foreach (int n in numeros3)
                Console.WriteLine(n);
        }
    }
}
