using System;
using System.Collections.Generic;
using System.Linq;
namespace _9OtherOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 2, 4, 5, 78, 3 };
            
            Console.WriteLine("-------------Take-------------");
            IEnumerable<int> desdeInicio = numeros.Take(5);
            foreach(int i in desdeInicio)//1, 2, 4, 5, 78
                Console.WriteLine(i);

            Console.WriteLine("-------------Skip-------------");
            IEnumerable<int> brinco = numeros.Skip(5);
            foreach(int i in brinco)//3
                Console.WriteLine(i);

            Console.WriteLine("-------------Reverse-------------");
            IEnumerable<int> reversa = numeros.Reverse();
            foreach(int i in reversa)//3, 78, 5, 4, 2, 1
                Console.WriteLine(i);

            Console.WriteLine("-------------First-------------");
            Console.WriteLine($"Primer elemento es {numeros.First()}");//1
            
            Console.WriteLine("-------------Last-------------");
            Console.WriteLine($"Ultimo elemento es {numeros.Last()}");//3

            Console.WriteLine("-------------ElementAt-------------");
            Console.WriteLine($"En el indice 2: {numeros.ElementAt(2)}");//4

            //True or false
            Console.WriteLine("-------------Contains-------------");
            Console.WriteLine($"Contiene al 78 {numeros.Contains(78)}");//true

            Console.WriteLine("-------------Any-------------");
            Console.WriteLine($"Tiene elementos {numeros.Any()}");//true

            //Any tambien sirve para hacer cosas mas profundas
            Console.WriteLine($"Hay multiplos de 5 : {numeros.Any(n => n % 5 == 0)}");
            Console.WriteLine("-----------------------------");

            
        }
    }
}
