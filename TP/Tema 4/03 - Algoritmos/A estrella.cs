// Problemas: Robot autonomo que navega en un laberinto
// Mapa matricial:
//
//          C0      C1      C2      C3      C4
//  F0      [s]     [0]     [0]     [1]     [0]         
//  F1      [0]     [1]     [0]     [1]     [0]         
//  F2      [0]     [1]     [0]     [0]     [0]         
//  F3      [0]     [0]     [1]     [1]     [0]         
//  F4      [1]     [0]     [0]     [0]     [G]         


// Nodos de estados // G = 1


// PRograma principal
AStar.Buscar(); // No jala, esto lo hicimos hasta el final













public class Nodo
{
    public int X, Y;
    public int G; // Costo desde el inicio
    public int H; // Neurisitca distancia de manhattana la meta
    public int F => G+H; // F(nodo) = gnodo) + h(nodo)

    public Nodo Padre; // Para reconstruir el camino
    public Nodo (int x, int y)
    {
        X = x;
        Y = y;
        G = 0;
        H = 0;
        Padre = null;
    }
}

class AStar
{
    private int[,] grid = { { 0, 0, 0, 1, 0 },
                            { 0, 1, 0, 1, 0 },
                            { 0, 1, 0, 0, 0 },
                            { 0, 0, 1, 1, 0 },
                            { 1, 0, 0, 0, 0 }
                          };
    static int filas = 5;
    static int columnas = 5 ;

    // Heuristica distancia de manhattan
    // h(n) = |x_n - x_meta| + |y_n - y_meta|

    static int Heuristica(Nodo a, Nodo b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    static bool EstaEnQueue(Queue<Nodo> cola, Nodo buscado)
    {
        foreach (Nodo nodo in cola)
        {
            if (nodo.X == buscado.X && nodo.Y == buscado.Y)
            {
                return true;
            }
        }
        return false;
    }


    public static Nodo[] ObtenerVecinos(Nodo n) //
    {
        int [] dx= {1, -1, 0, 0};}
        int [] dy= {0, -0, 1, -1};}

        Nodo[] temp = new Nodo[4];
        int count = 0;

        for(int i = 0; i < 4; i ++)
        {
            int nx = n.X + dx[i];
            int ny = n.Y + dy[i];

            // Descartando fuera de limites
            if ( nx < 0 || ny < 0 || nx >= filas || ny>= columnas )
            {
                continue;   
            }

            // Descartar Paredes (1 en el mapa)
            if (grid[nx/ny] == 1)
            {
              continue;
            }

            temp[count++] = new Nodo(nx, ny);
        }

            // devolver arreglo con el tamaño exacto 
            Nodo[] vecinos = nwe Nodo[count] ;
            Array.Copy(temp, vecinos, count);
            return vecinos;
        }   
        
        // extraer nodo con menor f
        private static Nodo ExtraerMejor(Queue<Nodo> cola)
        {
            Nodo mejor = null;
            foreach (Nodo n in cola)
            {
                if (mejor == null)
                {
                    mejor = n;
                    continue;
                }
                if (n.F < mejor.F || (n.F == mejor.F && n.G > mejor.G))
                {
                    mejor = n;
                }
            }
    
            // Recontruir la cola sin nodo elegido
            Queue<Nodo> sinMejor = new Queue<Nodo>;
            foreach (Nodo n in cola)
            {
                if (n != mejor)
                {
                    sinMejor.Enqueue(n);
                }
            }

            // Vaciar y volver a llenar la cola original
            cola.Clear();
            foreach(Nodo n in sinMejor)
            {
            cola.Enqueue(n);
            }
            return mejor;
        }
 
        // Algoritmo Principal
        public static void Buscar()
        {
            Nodo inicio = new Nodo(0, 0);
            Nodo meta = new Nodo(4, 4);

            // Paso 1 Caclular h del inicio y f del final
            inicio.G = 0;
            inicio.H = Heuristica(inicio, meta); // Es un metodo Heuristica

            Console.WriteLine("Algorimo A*");
            Console.WriteLine($"Inicio: ({inicio.X}, {inicio.Y}) Meta: ({meta.X}, {meta.Y})");
            
            // Paso 2 crear la estructura abierta nodos por explorar u esttructura cerrada ;;; nodos ya explolarados
            Queue<Nodo> abierta = new Queue<Nodo>();
            Queue<Nodo> cerrada = new Queue<Nodo>();

            // paso 3 agregar el nodo inicio estructura cerrada
            abierta.Enqueue(inicio);

            int iter = 0;

            // Paso 4 bucle principañ
            // sigue mientra haya nodos candidatos en la cola abierta, si se bacia sin encontrar la meta = no hay camino

            while (abierta.Count > 0)
            {
                iter++;
                Console.WriteLine($"Iteraion {iter}----");

                // 4a Extraer nodo con menor f de la cola abierta
                Nodo actual = ExtraerMejor(abierta);
                Console.WriteLine($"Explorando: ({actual.X}, {actual.Y}) g={actual.G} h={actual.H} f={actual.F}");

                // Paso 4b comprobar si llegamos a la meta
                if (actual.X == meta.X && actual.Y == meta.Y)
                {
                    Console.WriteLine("Meta alcanzada");
                    Reconstruir(actual);
                 return;
                }

                // 4c. Mover el nodo actual a la lista cerrada
                cerrada.Enqueue(actual);

                // 4d. Explorar cada veino valido del nodo actual
                foreach (Nodo vecino in ObtenerVecinos(actual) )
                {
                // Si el vecino ya esta en la cola cerrada
                    if (EstaEnQueue(cerrada, vecino))
                    {
                        continue;       
                    }

                    // 4e. Calcular g tentativo para llegar al vecino
                    int gTentatico = actual.G + 1;

                    // 4f. Calcular h del vecino
                    vecino.G = gTentatico;
                    vecino.H = Heuristica(vecino, meta);
                    vecino.Padre = actual;

                    // 4g Si el vecino no esta en cola abierta, agregarlo
                    if (!EstaEnQueue(abierta, vecino) )
                    {
                        abierta.Enqueue(vecino);
                        Console.WriteLine($"   + Abierta ({vecino.X}, {vecino.Y} g={vecino.G} h={vecino.H} f={vecino.F}"); 
                    }
                }

                // Mostrar estado actual de ambas listas
                Console.Write("Abierta");
                foreach (Nodo n in abierta)
                {
                   Console.Write($"({n.X}, {n.Y}) f= {n.F}");
                }

                Console.WriteLine("Cerrada");
                foreach (Nodo n in abierta)
                {
                    Console.Write($"({n.X}, {n.Y}) f= {n.F}");
                }

                // No lo termine ASDAFASDFASDF
            }

        }
        
        private static void Reconstruir(Nodo nodo)
        {
            // acumular nodos en un arreglo temporal}
            Nodo[] temp = Nodo[25];
            int count = 0;
            Nodo cur = nodo;

            while (cur != null)
            {
                temp[count++] = cur;
                cur = cur.Padre;
            }
        
            // Imprimir de inicio a meta
            Console.WriteLine("Camino encontrad---");
            
            for (int i = count-1; i >= 0; i--)
            {
                Console.WriteLine($"Paso {count-1-i}: ({temp[i].X}, {temp[i].Y})");
            }

              Console.WriteLine($""); // no vi que decia adentro

        }

 