using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ProgessiveQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //en el progressive quey hacemos un query en varios pasos
            //eso nos permite meter logica antes de obeneter el resultado final
            Console.WriteLine("---------------progressive");
            string[] postres = {"pay de manzana"
                                ,"tres leches"
                                ,"fresas con salsa de almibar"
                                ,"fresas con crema de mora"
                                ,"fresas con crema de mani"
                                ,"fresas con crema de guallaba"
                                ,"fresas con salsa de miel"
                                ,"manzana caramelizada"
                                ,"manzana dorada"
                                ,"manzana en pastel"
                                };
            bool mayusculas = true;
            IEnumerable<string> resultado;

            var manzanas = postres.Where(n => n.Contains("manzana"));
            var ordenadas = manzanas.OrderBy(n => n);

            if (mayusculas)
                resultado = ordenadas.Select(n => n.ToUpper());
            else
                resultado = ordenadas;

            foreach (string postre in resultado)
                Console.WriteLine(postre);

            Console.WriteLine("--------------Usando into");

            //Into se puede interpretar de dos formas, aqui lo vemos 
            //en una continuacion de query, solo se puede usar despues
            //de select o group. Es como si reinciara el query permitiendo
            //otros where, orderby, select

            IEnumerable<string> encotrados = from p in postres
                                             where p.Contains("fresas")
                                             orderby p
                                             select p
                                             into crema
                                             where crema.Contains("crema")
                                             select crema;

            foreach (string postre in encotrados)
                Console.WriteLine(postre);//trae todas las fresas con crema
            Console.WriteLine("---------- Wrapping");
            //Envolver Queries -wrapping
            //Es otra opcion de como podemos trabajar con el query
            //no confundir esta tecnica con los subqueries que colocan
            //el query en la expresion lambda

            IEnumerable<string> salsa = from p in (
                                    from p1 in postres
                                    where p1.Contains("fresas")
                                    orderby p1
                                    select p1
                                    )
                                  where p.Contains("salsa")
                                  select p;
            foreach (string postre in salsa)
                Console.WriteLine(postre);

            Console.WriteLine("-------------Usando let");

            IEnumerable<string> mispays = from e in postres
                                               let manzanitas = e
                                               where e.Contains("manzana")
                                               where manzanitas.Contains("pay")
                                               select e;
            //esto no tiene que ver, pero me gustó
            IEnumerable<string> mispays2 = from p in postres
                                           where p.Contains("manzana") && p.Contains("pay")
                                           select p;


            foreach (string postre in mispays2)
                Console.WriteLine(postre);
        }
    }
}
