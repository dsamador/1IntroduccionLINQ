using System;
using System.Collections.Generic;
using System.Linq;

namespace _2Deferred_And_Immediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, };

            //El query NO SE EJECUTA en este momento
            var valores = from n in numeros
                          where n %2 == 2
                          select n;

            //Ejecucion diferida
            //La expresion de query no se evalua hasta que se itera sobre el arreglo
            //Se puede usar el mismo query y siempre obtenemos el resultado actualizado

            //modificamos el arreglo
            numeros[1] = 12;
            foreach(int num in valores)
                Console.WriteLine(num);

            //Ejecucion inmediata
            //La consulta se ejecuta en el momento en que definimos la consulta
            //No obtenemos el resultado actualizado en caso de modificarse la
            //lista, en ese caso toca volver a correr la consulta.

            Console.WriteLine("Ejecucion inmediata");

            int[] arrayValores = (from n in numeros where n % 2 == 0 select n)
                .ToArray<int>();

            List<int> listValores = (from n in numeros where n % 2 == 0 select n)
                .ToList<int>();

            Console.WriteLine("El arreglo");

            foreach (var num in arrayValores)
                Console.WriteLine(num);

            numeros[0] = 29;
            Console.WriteLine("No actualiza el resultado");
            foreach (var num in arrayValores)
                Console.WriteLine(num);

            Console.WriteLine("La lista");
            Console.WriteLine("---------");
            foreach (var num in listValores)
                Console.WriteLine(num);
        }
        static void InfoResultados(object resultados)
        {
            Console.WriteLine($"Tipo {resultados.GetType().Name}");
            Console.WriteLine($"Locacion {resultados.GetType().Assembly.GetName().Name}");
        }
    }
    
}
