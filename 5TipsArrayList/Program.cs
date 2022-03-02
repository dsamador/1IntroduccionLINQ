using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5TipsArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList lista = new ArrayList();

            lista.AddRange(new object[] { 1, 2, "Hola", false, 3.5, 7.6, true, "saludos" });

            //obtenemos solo los enteros
            var enteros = lista.OfType<int>();
            foreach (int n in lista)
                Console.WriteLine(n);

            Console.WriteLine("---------");
            //creamos un Arraylist
            ArrayList estudiantes = new ArrayList()
            {
                new Estudiante("Ana", "A100", "Mercadotecnia", 10.0),
                new Estudiante("Rodrigo", "S200", "POO", 9.0),
                new Estudiante("Angelie", "A110", "Mercadotecnia", 4.0),
                new Estudiante("Andres", "A130", "Mercadotecnia", 8.7),
                new Estudiante("Luisa", "S233", "Fundamentos", 4.3),
                new Estudiante("Silena", "S100", "POO", 8.3)
            };
            //Tenemos que transformar el arraylist a un tipo que implemente
            //a IEnumerable<T> para poder ser usado con LINQ
            var estL = estudiantes.OfType<Estudiante>();

            //Ahora si usamos LINQ
            var reprobados = estL.Where(x => x.Promedio <= 5);

            //mostramos 
            Console.WriteLine("Reprobados");
            foreach (Estudiante estudiante in reprobados)
                Console.WriteLine(estudiante);

            Console.WriteLine("---------PROYECCION---------");

            List<Estudiante> estudiantes2 = new List<Estudiante>
            {
                new Estudiante("Ana", "A100", "Mercadotecnia", 10.0),
                new Estudiante("Rodrigo", "S200", "POO", 9.0),
                new Estudiante("Angelie", "A110", "Mercadotecnia", 4.0),
                new Estudiante("Andres", "A130", "Mercadotecnia", 8.7),
                new Estudiante("Luisa", "S233", "Fundamentos", 4.3),
                new Estudiante("Silena", "S100", "POO", 8.3)
            };

            //Proyeccion
            //hacemos uso de un tipo anonimo
            var nombrePromedio = from e in estudiantes2 select
                                 new { e.Nombre, e.Promedio };
            foreach (var item in nombrePromedio)
            {
                Console.WriteLine(item);
            }
        } 
    }
}
