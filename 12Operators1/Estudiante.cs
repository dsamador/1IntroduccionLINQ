using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12Operators1
{
    public class Estudiante
    {
        public string Nombre { get; set; }
        public int Id { get; set; }

        public Estudiante(string nombre, int id)
        {
            Nombre = nombre;
            Id = id;
        }
        public override string ToString() => $"Estudiante: {Nombre} con Id: {Id}";                            
    }

    public class Clase
    {
        public string Curso { get; set; }
        public int Id { get; set; }

        public Clase(string curso, int id)
        {
            Curso = curso;
            Id = id;
        }
        public override string ToString() => $"Curso => {Curso}";
    }
}
