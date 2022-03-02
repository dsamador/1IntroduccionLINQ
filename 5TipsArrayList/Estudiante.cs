using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5TipsArrayList
{
    internal class Estudiante
    {
        public string Nombre { get; }
        public string Id { get; }
        public string Curso { get; }
        public double Promedio { get; }

        public Estudiante(
            string nombre,
            string id,
            string curso,
            double promedio)
        {
            Nombre = nombre;
            Id = id;
            Curso = curso;
            Promedio = promedio;
        }
        public override string ToString()
        {
            return $"Nombre {Nombre}, Id {Id}, " +
                   $"Curso {Curso}, Promedio {Promedio}";
        }
    }
}
