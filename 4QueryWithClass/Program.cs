using System;
using System.Collections.Generic;
using System.Linq;

namespace _4QueryWithClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQ con Clases
            //Creamos una lista
            List<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante("Ana", "A100", "Mercadotecnia", 10.0),
                new Estudiante("Rodrigo", "S200", "POO", 9.0),
                new Estudiante("Angelie", "A110", "Mercadotecnia", 4.0),
                new Estudiante("Andres", "A130", "Mercadotecnia", 8.7),
                new Estudiante("Luisa", "S233", "Fundamentos", 4.3),
                new Estudiante("Silena", "S100", "POO", 8.3)
            };

            //encontramos los reprobados
            var reprobados = from e in estudiantes
                             where e.Promedio <= 5.0
                             select e;
            //mostramos
            Console.WriteLine("Reprobados");
            foreach (Estudiante r in reprobados)            
                Console.WriteLine(r);

            //mostramos solo un atributo
            Console.WriteLine("Solo nombre de reprobados");
            foreach (Estudiante r in reprobados)
                Console.WriteLine(r.Nombre);

            //Encontramos solo los nombre de los de mercadotecnia
            Console.WriteLine("Los de mercadotecnia");
            var mercadotecnia = from e in estudiantes
                                where e.Curso.Contains("Mercadotecnia")
                                //where e.Curso == "Mercadotecnia"
                                select e.Nombre;
            
            foreach (string r in mercadotecnia)
                Console.WriteLine(r);

            
        }
    }
}
