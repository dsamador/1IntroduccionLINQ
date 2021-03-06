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
            
            Console.WriteLine("----PROYECCION => SELECT----\r\n");
            Console.WriteLine("Para ver la diferencia con SelectMany");
            IEnumerable<string[]> r8 = postres.Select(p => p.Split());
            foreach (string[] s in r8)
            {
                Console.WriteLine("-");
                foreach(string t in s)
                    Console.WriteLine(t);
            }                
            Console.WriteLine("---------");

            Console.WriteLine("----PROYECCION => SELECT----\r\n");
            Console.WriteLine("Select con multiples variables de rango");
            IEnumerable<string> r9 = from p in postres
                                       from p1 in p.Split()
                                       select p1 + "====>" + p;
            foreach(string n in r9)
                Console.WriteLine(n);
            
            Console.WriteLine("---------");

            // Union-Joining
            // Join une los elementos de dos colecciones en un solo conjunto
            // GroupJoin es como Join pero da un resultado jerarquico
            // Zip Enumera dos secuencias y aplica una funcion a cada par

            List<Estudiante> estudiantes = new List<Estudiante>()
            {
                new Estudiante("Ana", 100),
                new Estudiante("Mario", 150),
                new Estudiante("Camilo", 180)
            };

            List<Clase> clases = new List<Clase>
            {
                new Clase("Programacion", 100),
                new Clase("Orientado a objetos", 150),
                new Clase("Programacion", 150),
                new Clase("Programacion", 180),
                new Clase("UML", 100),
                new Clase("Orientado a objetos", 100),
                new Clase("UML", 180),
            };

            Console.WriteLine("----UNION => JOIN----\r\n");

            //Esto funciona y no usamos Join
            //var listado = from e in estudiantes
            //              from c in clases
            //              where c.Id == e.Id
            //              select e.Nombre + " esta en el curso " + c.Curso;

            var listado = from e in estudiantes
                          join c in clases on e.Id equals c.Id
                          select e.Nombre + " esta en el curso " + c.Curso;
            
            foreach (var item in listado)
                Console.WriteLine(item);
            Console.WriteLine("---------");


            // Los resultados se obtienen en forma gerarquica
            // la sintaxis es la misma per utilizamos into
            Console.WriteLine("----UNION => GROUP JOIN----\r\n");
            var listado2 = from e in estudiantes
                           join c in clases on e.Id equals c.Id
                           into tempListado
                           select new { estudiante = e.Nombre, tempListado };

            //Mostramos los resultados
            foreach (var item in listado2)
            {//creamos una coleccion de clases por cada estudiante
                Console.WriteLine(item.estudiante);
                foreach (var item2 in item.tempListado)
                {
                    Console.WriteLine(item2);
                }
            }
            Console.WriteLine("---------");


            //ZIP 
            // Regresa una secuencia que aplica una funcion a cada par
            Console.WriteLine("----UNION => ZIP----\r\n");
            string[] helados = { "chocolate", "vainilla", "fresa", "limon" };

            IEnumerable<string> r12 = postres.Zip(helados, (p, h) => p + " con helado de " + h);

            foreach (var item in r12)
            {
                Console.WriteLine(item);
            }

            // Ordenamiento 
            // OrderBy, ThenBy, Ordena en orden ascendente
            // OrderByDescending, ThenByDescending Ordena de orden descendente
            // Reverse Regresa en el orden inverso

            Console.WriteLine("----ORDENAMIENTO => ORDERBY----\r\n");
            IEnumerable<int> numOrder = numeros.OrderBy(x => x); //escendente
            IEnumerable<int> numDes = numeros.OrderByDescending(x => x); //descendente

            foreach (var item in numOrder)            
                Console.WriteLine(item);

            foreach (var item in numDes)            
                Console.WriteLine(item);

            Console.WriteLine("------------");

            string[] palabras = { "hola", "piedra", "pato", "pastel", "carros", "auto" };
            //con cadenas, ordena primero por longitud y luego por orden alfabetico
            IEnumerable<string> palabrasOrdenadas = palabras.OrderBy(x => x.Length).ThenBy(p => p);

            foreach (var item in palabrasOrdenadas)
                Console.WriteLine(item);

            Console.WriteLine("------------");
            //////////////////////////////////////////////////////////
            // Agrupamiento
            // GroupBy agrupa una secuencia en subsecuencias

            Console.WriteLine("----AGRUPAMIENTO => GROUPBY----\r\n");

            string[] archivos = System.IO.Directory.GetFiles("H:\\amade\\Documents");

            Console.WriteLine("Archivos obtenidos por GetFiles");

            foreach (string archivo in archivos)
                Console.WriteLine(archivo);

            //Agrupamos basados en la extension
            //Adentro de () colocamos el criterio de agrupamiento

            var archivoAg = archivos.GroupBy(x => System.IO.Path.GetExtension(x));

            Console.WriteLine("Resultados agrupados");

            foreach (IGrouping<string, string> g in archivoAg)
            {
                //llave de agrupamiento
                Console.WriteLine($"Archivos de extension {g.Key}");
                foreach (string item in g)
                {
                    Console.WriteLine($"\t {item}");
                }
            }

            Console.WriteLine("---------");

            //////////////////////////////////////////////////////////
            // Conjuntos
            // Concat, Union, Intersect, Except
            //////////////////////////////////////////////////////////

            //Conversion
            //OfType Convierte de IEnumerable a IEnumerable<T>, desecha los elementos erroneos
            //Cast Convierte de IEnumerable a IEnumerable<T>, lanza excepcion con los elementos erroneos
            //ToArray Convierte de IEnumerable<T> a T[]
            //ToList Convierte de IEnumerable<T> a List[]
            //ToDictionary IEnumerable<T> a Dictionary<TKey, TValue>
            //ToLookup Convierte de IEnumerable<T> a Lookup<TKey, TElement>
            //AsEnumerable Hace downcast a IEnumerable<T>
            //AsQueryable Hace cast o convierte a IQueryable<T>

            //////////////
            // De elemento
            // First, FirstOrDefault Regresa primer elemento de la secuencia
            // Last, LastOrDefault Regresa ultimo elemento de la secuencia
            // Single, SingleOrDefault Equivalente a First, FirstOrDefault, pero lanza una
            //  excepcion si hay mas de un elemento
            // ElementAt, ElementAtOrDefault
            // DefaultEmpty

            Console.WriteLine("----DE ELEMENTO => FIRST----\r\n");
            //obtenemos el primero
            int primero = numeros.First();
            Console.WriteLine(primero);

            Console.WriteLine("----DE ELEMENTO => FIRST con condicion----\r\n");
            //Primer par
            int primerPar = numeros.First(n => n % 2 == 0);
            Console.WriteLine(primerPar);

            Console.WriteLine("----DE ELEMENTO => FIRSTORDEFAULT----\r\n");
            //Primer divisible por 57
            int primeroNo = numeros.FirstOrDefault(n => n % 57 == 0);
            Console.WriteLine(primeroNo);


            ////////////////////////////////////////
            //Agregacion
            //Count LongCount Regresa la cantidad de elementos en la secuencia int o int64
            //Min Regresa el elemento menor de la secuencia
            //Max Regresa el elemento mayor de la secuencia
            //Sum Regresa la sumatoria de los elementos
            //Average Regresa el promedio de los elementos
            //Aggregate Hace una agregacion usando nuestro algoritmo

            Console.WriteLine("----DE AGREGACION => SUM----\r\n");

            int sumatoria = numeros.Sum();
            Console.WriteLine(sumatoria);


            Console.WriteLine("----DE AGREGACION => AGGREGATE----\r\n");
            int[] numeros2 = { 1, 2, 3, 4, 5, 6, 7 };

            //En este caso la semilla es cero, si no se pone la semilla, toma el primer valor
            int agregado = numeros2.Aggregate(0, (t,n)=> t + (n * 2));
            Console.WriteLine(agregado);

            /////////////////////////////////////
            //Cuantificadores
            //Contains Regresa true si la secuencia contiene al elemento
            //Any Regresa true si un elemento satisface al predicado
            //All Regresa true si todos los elementos satisfacen al predicado
            //SequenceEqual Regresa true si la segunda secuencia tiene elementos identicos a la de entrada

            Console.WriteLine("----CUANTIFICADORES => ALL----\r\n");

            bool todos = numeros2.All(n => n < 10);
            Console.WriteLine(todos);

            Console.WriteLine("----CUANTIFICADORES => SEQUENCE_EQUAL----\r\n");
            bool iguales = numeros2.SequenceEqual(numeros);
            Console.WriteLine(iguales);

            /////////////////////////////////////////////////////
            ///Generacion
            ///Empty crea una secuencia vacia
            ///Repeat crea una secuencia de elementos que se repiten
            ///Range crea una secuencia de enteros
            ///

            var vacia = Enumerable.Empty<int>();//se puede hacer cw pero no tiene nada

            Console.WriteLine("----------------");

            var repetir = Enumerable.Repeat("Hola", 5);//Hola  cinco veces

            Console.WriteLine("----------------");

            Console.WriteLine("----GENERACION => RANGE----\r\n");
            var rango = Enumerable.Range(5, 15);//Inicio, elementos

            foreach (var item in rango)
            {
                Console.WriteLine(item);
            }
        }
    }
}
