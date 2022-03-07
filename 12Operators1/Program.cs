using System;
using System.Collections.Generic;
using System.Linq;
namespace _12Operators1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hay tres categorias para los operadores de query
            //Secuencia a secuencia (secuencia de entrada, secuencia de salida)
            //Secuencia de entrada, elemento sencillo o escalar
            //Nada de entrada, secuencia de salida

            //Secuencia a secuencia =>
            //Filtro: Where, Take, TakeWhile, Skip, SkipWhile, Distinct
            //Proyeccion: Select, SelectMany
            //Union: Join, GroupJoin, Zip
            //Ordenamiento: OrderBy, ThenBy, Reverse
            //Agrupamiento: GroupBy
            //Operadores de conjuntos: Concat, Union, Intersect, Except
            //Conversion import: OfType, Cast
            //Conversion export: ToArray, ToDictionary, ToLookup, AsEnumerable,
            //-AsQueriable

            //Secuencia a elemento o escalar =>
            //Operadores de elemento: First, FirstOrDefault, Last, LastOrDefault,
            //-Single, SingleOrDefault, ElementAt, ElementAtOrDefault, DefaultEmpty
            //Agregacion: Aggregate, Average, Count, LongCount, Sum, Max, Min
            //Cuantificador: All, Any, Contains, SequenceEqual

            //Nada de entrada, secuencia de salida =>
            //Generacion: Empty, Range, Repeat

            //////////////////////////////////////////////////////////////////////

            //Solo se muestran los que no hemos usado a lo largo de la solucion

            //FILTRO
            //Where regresa un subconjunto de elementos que satisfacen una condicion
            //Take regresa el primer elemento n e ignora el resto
            //Skip ignora los primeros n elementos y regresa el resto
            //TakeWhile emite elementos de la secuencia de entrada hasta que el-
            //-predicado es falso
            //SkipWhile Ignora elementos de la secuencia de entrada hasta que el-
            //-predicado es falso, luego emite el resto
            //Distinct regresa una secuencia que excluye a los duplicados            
            
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

            //Where
            //Aparte de lo que hemos visto, where permite un segundo argumento de 
            //tipo int que simboliza el indice del elemento
            //Esto se conoce como filtrado por indice
            Console.WriteLine("----FILTROS => WHERE----\r\n");
            
            Console.WriteLine("Where con indice");
            //retorna el primero e intercala uno no y otro si
            IEnumerable<string> r1 = postres.Where((n, i) => i % 2 ==0);
            foreach (string s in r1)
                Console.WriteLine(s);
            Console.WriteLine("---------");

            Console.WriteLine("Where con StartsWith");
            //Los que empiecen con "tres"
            IEnumerable<string> r2 = postres.Where(p => p.StartsWith("tres"));
            foreach (string s in r2)
                Console.WriteLine(s);
            Console.WriteLine("---------");
            
            Console.WriteLine("Where con EndsWith");
            //Los que terminen con "miel"
            IEnumerable<string> r3 = postres.Where(p => p.EndsWith("miel"));
            foreach (string s in r3)
                Console.WriteLine(s);
            Console.WriteLine("---------");

            //TakeWhile emite elementos de la secuencia de entrada hasta que
            //- el predicado es falso
            Console.WriteLine("----FILTROS => TAKEWHILE----\r\n");

            int[] numeros = { 1, 2, 4, 3, 63, 645, 85, 3, 11, 7, 9, 9, 9 };

            var r4 = numeros.TakeWhile(n => n < 8);
            foreach (int s in r4)
                Console.WriteLine(s);
            Console.WriteLine("---------");

            //SkipWhile Ignora elementos de la secuencia de entrada hasta que el-
            //-predicado es falso, luego emite el resto sin tener en cuenta
            //-la condicion porque esta solo es valida una vez
            Console.WriteLine("----FILTROS => SKIPWHILE----\r\n");
            var r5 = numeros.SkipWhile(n => n < 8);
            foreach (int s in r5)
                Console.WriteLine(s);
            Console.WriteLine("---------");


            ///////////////////////////////////////////////////////////
            //Proyeccion
            //Select transforma el elemento de entrada con la expresion
            //lambda
            //SelectMany transforma el elemento, lo aplana y concatena con los
            //subsecuencias resultantes

            //Hemos usado Select con tipos anonimos o para tomar el elemento
            //completamente

            Console.WriteLine("----PROYECCION => INDEXADA----\r\n");
            IEnumerable<string> r6 = postres.Select((p, i) =>
                $"Indice {i+1} para el postre {p}");
            foreach (string s in r6)
                Console.WriteLine(s);
            Console.WriteLine("---------");

            //SelectMany
            //En Select cada elemento de entrada produce un elemento de salida
            //SelectMany produce 0...n elementos
            //Sencillamente: Select da un arreglo de palabras por cada oracion
            //y SelectMany da palabra por palabra, es decir aplana todo
            Console.WriteLine("----PROYECCION => SELECTMANY----\r\n");
            IEnumerable<string> r7 = postres.SelectMany(p => p.Split());
            foreach (string s in r7)
                Console.WriteLine(s);
            Console.WriteLine("---------");

            
        }
    }
}
