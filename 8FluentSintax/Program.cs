using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _8FluentSintax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hemos utilizado una sintaxis que llamamos query expression
            //Ahora veremos una sintaxis que se conoce como fluent sintax
            //Query operator es un metodo que transforma una secuencia
            //acepta una secuencia de entrada y da como resultado una secuencia de salida
            //Se tienen cerca de 40 operadores para LINQ, estos forma parte
            //de los standard quer operators
            //El query es una expresion que cuando se enumera transforma a la secuencia
            //usando los operadores

            //Creamos un arreglo sobre el cual trabajar

            int[] numeros = { 1, 2, 4, 6, 7, 87, 9, 5, 4, 324, 5 };

            //Usamos expresion lambda como argumento, n es el argumento de entrada.
            IEnumerable<int> pares = numeros.Where(x => x % 2 == 0);

            string[] postres = {"pay de manzana", 
                                "tres leches",
                                "fresas con almibar",
                                "fresas con crema"
                                };

            //Operator chaining
            IEnumerable<string> fresas = postres
                .Where(x => x.Contains("fresas"))
                .OrderBy(x => x.Length)
                .Select(x => x.ToUpper());

            foreach (string i in fresas)
                Console.WriteLine(i);
        }
    }
}
