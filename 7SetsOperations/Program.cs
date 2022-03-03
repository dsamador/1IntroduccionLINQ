using System;
using System.Collections.Generic;
using System.Linq;

namespace _7SetsOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 4, 5, 78, 3 };
            List<int> list2 = new List<int>() { 4, 2, 2, 6, 90, 31 };

            //Except nos da la diferencia entre dos contenedores
            //var expt = (from n1 in list select n1).Except(from n2 in list2 select n2);
            var expt = (from n1 in list select n1).Except(list2);//esta es mas corta
            Console.WriteLine("Except");
            foreach (int i in expt)
                Console.WriteLine(i); //1, 5, 78, 3 que pertenecen a list y no a list2

            //Intersect nos da lo comun entre los dos contenedores
            var ints = (from n in list2 select n).Intersect(list);
            Console.WriteLine("Intersect");
            foreach (int i in ints)
                Console.WriteLine(i);
            
            //Union nos da la union de los dos contenedores sin repeticiones
            var union = (from n in list2 select n).Union(list);
            Console.WriteLine("Union");
            foreach (int i in union)
                Console.WriteLine(i);

            //Concat nos da la union de los dos contenedores con repeticiones
            var concat = (from n in list2 select n).Concat(list);
            Console.WriteLine("Concat");
            foreach (int i in concat)
                Console.WriteLine(i);

            //Distinc remueve los duplicados, pero no modifica el arreglo sino que 
            //retorna otro arreglo.
            Console.WriteLine("Distinct");
            foreach (int i in list2.Distinct())
                Console.WriteLine(i);
        }
    }
}
