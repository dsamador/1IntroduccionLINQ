using System;
using System.Collections.Generic;
using System.Linq;
namespace _6BasicOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Operaciones basicas
            List<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante("Ana", "A100", "Mercadotecnia", 10.0),
                new Estudiante("Rodrigo", "S200", "POO", 9.0),
                new Estudiante("Angelie", "A110", "Mercadotecnia", 4.0),
                new Estudiante("Andres", "A130", "Mercadotecnia", 8.7),
                new Estudiante("Luisa", "S233", "Fundamentos", 4.3),
                new Estudiante("Silena", "S100", "POO", 8.3)
            };
            //conteo
            int cantidad = estudiantes.Count();
            Console.WriteLine($"Total de estudiantes {cantidad}");

            int cantidadAprobados = 
                estudiantes.Where(x => 
                                    x.Promedio >= 5).Count();
            Console.WriteLine($"Total de estudiantes aprobados {cantidadAprobados}");

            var aprobados = estudiantes.Where(x => x.Promedio > 5);
            foreach (var item in aprobados)
                Console.WriteLine($"Aprobados {item}");
            
            Console.WriteLine("-----------");
            
            Console.WriteLine("Orden inverso");
            foreach (var item in aprobados.Reverse())
                Console.WriteLine($"Aprobados {item}");

            Console.WriteLine("Ordenados");
            var ordenados = from e in estudiantes
                            orderby e.Promedio descending /*ascending*/
                            select e;
            foreach (var item in ordenados)
                Console.WriteLine($"{item}");

            int[] numeros = { 1, 2, 3, 4, 5 };

            //Encontrar el maximo
            int maximo = (from n in numeros select n).Max();
            Console.WriteLine($"El numero maximo es {maximo}");

            //minimo
            int minimo = (from n in numeros select n).Min();
            Console.WriteLine($"El numero minimo es {minimo}");

            //promedio
            double prom = (from n in numeros select n).Average();
            Console.WriteLine($"El promedio es {prom}");

            //sumatoria 
            int sumatoria = (from n in numeros select n).Sum();
            Console.WriteLine($"La sumatoria es {sumatoria}");

        }
    }
}
