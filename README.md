# T-cnicasProgramaci-n
Idk, será el definitivo?
Si, deberá ser el definitivo
blah blah blah


1.-
namespace APP.INTERFACES
{
    public interface IReceta        // Contrato para Clase RecetA
    {
        // Atributos y Propiedades
        
        /*
        /   Mejoramos las propiedaes de lectura y escritura
        /   Añadimos el metodo ToString faltante
        */

        string Nombre { get; } // Sin set para que sean solo de lectura
        string Chef { get; }
        int TiempoMinutos { get; }

        // Metodos
        string ToString(); // En la clase se podra establecer el formato
    }
}

2.-
using APP.INTERFACES;
namespace APP.MODELOS
{
    public class Receta : IReceta
    {
        /*
        /   Corregimos las propiedaes de lectura y escritura (como en su interfaz)
        /   Añadimos el metodo ToString faltante
        */

        // Atributos y Propiedades
        private readonly string nnombre;    // pr --> solo es modificable detnro de la clase
        private readonly string cchef;      // readonly solo asigna el valor en el constructor
        private readonly int ttiempoMinutos;

        public string Nombre { get { return nnombre; } }    // public cualquiera las puede ver 
        public string Chef { get { return cchef; } }        // set solo eprmite lectura, como la interfaz
        public int TiempoMinutos { get { return ttiempoMinutos; } }

        // Constructor
        public Receta(string nombre, string chef, int tiempoMinutos)
        {
            if (tiempoMinutos <= 0)
                throw new ArgumentException("El tiempo de preparación debe ser mayor a 0.");

            nnombre = nombre;
            cchef = chef;
            ttiempoMinutos = tiempoMinutos;
        }

        // Metodos
        public override string ToString()
        {
            return $"{Nombre} - {Chef} ({TiempoMinutos} min)";
        }
    }
}

3.-
namespace APP.MODELOS
{
    public class Usuario
    {
        // Propiedades
        public string Nombre { get; set; }
        public Dictionary<string, List<Receta>> LibrosRecetas { get; set; }

        // Constructor
        public Usuario(string nombre)
        {
            Nombre = nombre;
            LibrosRecetas = new Dictionary<string, List<Receta>>();
        }

        // Metodos
        public void CrearLibroRecetas(string nombreLibro)
        {
            if (LibrosRecetas.ContainsKey(nombreLibro))
                throw new InvalidOperationException("Ya existe un libro con este nombre.");

            LibrosRecetas.Add(nombreLibro, new List<Receta>());
        }

        public void AgregarRecetaALibro(string nombreLibro, Receta receta)
        {
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");

            LibrosRecetas[nombreLibro].Add(receta);
        }

        public void EliminarLibro(string nombreLibro)
        {
            /* NO LO PIDE, pero evitaria que elimine algo que no existe
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");
            */

            LibrosRecetas.Remove(nombreLibro);
        }

        public List<Receta> ObtenerLibro(string nombreLibro)
        {
            /* NO LO PIDE, pero lanzaria una excepcion si la clave no existiera
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");
             */

            return LibrosRecetas[nombreLibro];
        }

        /*
        /    El metodo antes implementado buscaba en un solo libro, este busca todas las recetas
        */
        public int ContarRecetas() // va libro a libro contando las recetas
        {
            int total = 0;
            foreach (var lista in LibrosRecetas.Values)
            {
                total += lista.Count;
            }
            return total;
        }
        public void MostrarLibros()
        {
            if (LibrosRecetas.Count == 0) // Revisa el numero de libros, si es 0 imprime y termina ahí
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            foreach (var libro in LibrosRecetas)        // Recorre los libros en el diccionario
            {
                Console.WriteLine($"Libro: {libro.Key}");

                foreach (var receta in libro.Value)     // Recorre las recetas de los libros
                {
                    Console.WriteLine("   - " + receta.ToString());
                }
            }
        }
    }
}

4.-
using APP.MODELOS;

namespace APP.INTERFACES

{
    /*
    / Se declaran los metodos a usar
    / Se cambia la declaracion class por interface (sintaxis)
    / Se corrigen nombres de los metodos y se eliminan repeticiones
    / Se elimina 'public' al ser una redundancia en los metodos de la interfaz
    / Faltaba metodo merge sort su parametro era una lista, no una clase
    / La busqueda binaria debia regresar un indice
    / Se elimina un metodo no solicitado
    */

    public interface IGestorRecetas // Interface gestor -> Contrato con el gestor
    {
        // Atributos y Propiedades
        List<Receta> RecetasDisponibles { get; set; }

        // Metodos
        // Se implementan los metodos que debera llevar por contrato la clase del gestor de recetas y se 
        void AgregarReceta(Receta receta);
        void EliminarReceta(Receta receta);
        void EliminarPorIndice(int indice);

        List<Receta> BuscarPorNombre(string nombre);

        void LimpiarCatalogo();

        void QuickSort(List<Receta> lista);
        List<Receta> MergeSort(List<Receta> lista);     // No estaba implementado en los comentarios
        int BusquedaBinaria(string nombre);      // Se establecio el nombre correcto

        // Se elimino busqueda por tiempo
    }
}

5.-
using APP.INTERFACES;
using APP.MODELOS;

namespace APP.GESTORES
{
    /*          CORRECCIONES
    / Se modifican las instrucciones del metodo AgregarReceta
    / Se corrige el parametro de EliminarReceta y se modifica el algoritmo
    / Se corrige el metodo EliminarPorIndice
    / Corereccion del nombre del metodo "BuscarPorNombre"
    / Se agregan los algoritmos QuickSort y MergeSort
    / Se modifico el algoritmo de busqeuda binaria
    */

    public class GestorRecetas : IGestorRecetas
    {
        // Propiedades
        public List<Receta> RecetasDisponibles { get; set; }

        // Constructor
        public GestorRecetas()
        {
            RecetasDisponibles = new List<Receta>();
        }

        // Metodos 
        public void AgregarReceta(Receta receta)
        {
            // Solución a "sin implementación en programa principal": este método se usará al inicio (8 recetas por defecto)
            if (receta == null)
            {
                throw new ArgumentNullException("receta");
            }

            // Solución a "errores de sintaxis" y "LINQ no permitido": se reemplaza Any() por bucle manual
            foreach (var r in RecetasDisponibles)
            {
                if (string.Equals(r.Nombre, receta.Nombre, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("La receta ya existe en el catálogo global.");
                }
            }
            RecetasDisponibles.Add(receta);
        }

        public void EliminarReceta(Receta receta)
        {
            if (receta == null)
            {
                return;
            }
            // Búsqueda manual sin LINQ
            int index = -1;     // -1  no encontrado
            for (int i = 0; i < RecetasDisponibles.Count; i++)
            {
                if (string.Equals(RecetasDisponibles[i].Nombre, receta.Nombre, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;  // Guardamos la posición donde la encontramos
                    break;      // Nos salimos del ciclo de inmediato
                }
            }
            if (index != -1)
            {
                RecetasDisponibles.RemoveAt(index);
            }
        }

        public void EliminarPorIndice(int indice)
        {
            if (indice < 0 || indice >= RecetasDisponibles.Count)
            {
                throw new ArgumentOutOfRangeException("indice", "Índice fuera de los límites del catálogo.");
            }
            RecetasDisponibles.RemoveAt(indice);
        }

        public List<Receta> BuscarPorNombre(string nombre)
        {
            List<Receta> resultado = new List<Receta>();
            foreach (var r in RecetasDisponibles)
            {
                if (r.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    resultado.Add(r);
                }
            }
            return resultado;
        }

        public void LimpiarCatalogo()
        {
            RecetasDisponibles.Clear();
        }

        // Algoritmos
        // 1ero - QuiclSort  -  Segun el tiempo se ordena de forma ascendente
        public void QuickSort(List<Receta> lista)
        {
            if (lista == null || lista.Count <= 1)
            {
                return;
            }
            QuickSortRecursivo(lista, 0, lista.Count - 1);
        }

        private void QuickSortRecursivo(List<Receta> lista, int izquierda, int derecha)
        {
            if (izquierda >= derecha)
            {
                return;
            }

            int pivote = Particionar(lista, izquierda, derecha);
            QuickSortRecursivo(lista, izquierda, pivote - 1);
            QuickSortRecursivo(lista, pivote + 1, derecha);
        }

        private int Particionar(List<Receta> lista, int izquierda, int derecha)
        {
            int pivoteValor = lista[derecha].TiempoMinutos;
            int i = izquierda - 1;
            for (int j = izquierda; j < derecha; j++)
            {
                if (lista[j].TiempoMinutos <= pivoteValor)
                {
                    i++;
                    // Intercambio manual
                    Receta temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                }
            }

            // Intercambiar el pivote
            Receta temp2 = lista[i + 1];
            lista[i + 1] = lista[derecha];
            lista[derecha] = temp2;
            return i + 1;
        }


        // 2do - Regresa la lista ordenada?
        public List<Receta> MergeSort(List<Receta> lista)
        {
            if (lista == null)
            {
                return new List<Receta>();
            }
            if (lista.Count <= 1)
            {
                return new List<Receta>(lista);
            }

            int medio = lista.Count / 2;
            List<Receta> izquierda = new List<Receta>();
            List<Receta> derecha = new List<Receta>();

            for (int i = 0; i < medio; i++)
            {
                izquierda.Add(lista[i]);
            }
            for (int i = medio; i < lista.Count; i++)
            {
                derecha.Add(lista[i]);
            }
            izquierda = MergeSort(izquierda);
            derecha = MergeSort(derecha);
            return Mezclar(izquierda, derecha);
        }

        private List<Receta> Mezclar(List<Receta> izq, List<Receta> der)
        {
            List<Receta> resultado = new List<Receta>();
            int i = 0, j = 0;

            while (i < izq.Count && j < der.Count)
            {
                if (izq[i].TiempoMinutos <= der[j].TiempoMinutos)
                {
                    resultado.Add(izq[i]);
                    i++;
                }
                else
                {
                    resultado.Add(der[j]);
                    j++;
                }
            }
            while (i < izq.Count)
            {
                resultado.Add(izq[i++]);
            }
            while (j < der.Count)
            {
                resultado.Add(der[j++]);
            }
            return resultado;
        }

        // 3ro
        public int BusquedaBinaria(string nombre)
        {
            List<Receta> copia = new List<Receta>(RecetasDisponibles);

            // Ordenar copia por nombre (burbuja)
            for (int i = 0; i < copia.Count - 1; i++)
            {
                for (int j = i + 1; j < copia.Count; j++)
                {
                    if (string.Compare(copia[i].Nombre, copia[j].Nombre, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Receta temp = copia[i];
                        copia[i] = copia[j];
                        copia[j] = temp;
                    }
                }
            }

            // Búsqueda binaria manual
            int bajo = 0, alto = copia.Count - 1;
            while (bajo <= alto)
            {
                int medio = (bajo + alto) / 2;
                int comparacion = string.Compare(copia[medio].Nombre, nombre, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                {
                    return medio;
                }
                if (comparacion < 0)
                {
                    bajo = medio + 1;
                }
                else
                {
                    alto = medio - 1;
                }
            }
            return -1;
        }
    }
}

6.-
using APP.MODELOS;

namespace APP.INTERFACES
{
    /*          CORRECCIONES
    / Se modifico el retorno del metodo
    / Se reorganizo el parametro string del metodo
    */
    public interface IExportador
    {
        // Metodos
        void ExportarATxt(Usuario usuario, string rutaArchivo);
    }
}

7.-
using APP.INTERFACES;
using APP.MODELOS;
using APP.GESTORES;

namespace APP.SERVICIOS
{
    /*          CORRECCIONES
    / Se añadio using.APP.GESTORES
    / Se usa el gestor para aplicar QuickSort o MergeSort según el parámetro.
    / En OrdenarLibroYCalcularTiempo se ordena la lista del libro y se suma TiempoMinutos.
    / Se corrigieron lso metodos RegistrarUsuario, BuscarUsuario, contar usuarios
    / Se añadieron metodos faltantes: EliminarUsuario, OrdenarCatalogo, OrdenarLibroYCalcularTiempo
    / 
    */
    public class ServicioRecetas
    {
        // Atributos y Propiedades
        public IGestorRecetas Gestor { get; private set; }  // Propiedad publica
        public IExportador Exportador { get; private set; } // cualquiera lee, solo la clase puede modificarla
        public List<Usuario> Usuarios { get; private set; }

        // Constructor
        public ServicioRecetas(IGestorRecetas gestor, IExportador exportador)
        {
            Gestor = gestor;
            Exportador = exportador;
            Usuarios = new List<Usuario>();
        }

        // Metodos
        public Usuario RegistrarUsuario(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", "nombre");
            }
            Usuario nuevo = new Usuario(nombre);
            Usuarios.Add(nuevo);
            return nuevo;
        }

        public Usuario BuscarUsuario(string nombre)
        {
            foreach (var u in Usuarios)
            {
                if (string.Equals(u.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return u;
                }
            }
            return null;
        }

        public bool EliminarUsuario(string nombre)
        {
            for (int i = 0; i < Usuarios.Count; i++)
            {
                if (string.Equals(Usuarios[i].Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    Usuarios.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int ContarUsuarios()
        {
            return Usuarios.Count();
        }

        public void OrdenarCatalogo(string algoritmo)
        {
            if (algoritmo == null)
            {
                return;
            }
            string alg = algoritmo.ToLowerInvariant();
            if (alg == "quick")
            {
                Gestor.QuickSort(Gestor.RecetasDisponibles);
                Console.WriteLine("Catálogo ordenado con QuickSort por tiempo.");
            }
            else if (alg == "merge")
            {
                // MergeSort regresa una nueva lista; se reemplaza la original
                List<Receta> nuevaLista = Gestor.MergeSort(Gestor.RecetasDisponibles);
                Gestor.RecetasDisponibles = nuevaLista;
                Console.WriteLine("Catálogo ordenado con MergeSort por tiempo.");
            }
            else
            {
                throw new ArgumentException("Algoritmo no reconocido. Use 'quick' o 'merge'.");
            }
        }

        public int OrdenarLibroYCalcularTiempo(Usuario usuario, string nombreLibro, string algoritmo)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException("usuario");
            }

            // da una lista de recetas del libro
            List<Receta> libro = usuario.ObtenerLibro(nombreLibro);
            if (libro == null)
            {
                return 0;
            }

            // se usa el algoritmo de ordenamiento
            if (algoritmo == null)
            {
                return 0;
            }
            string alg = algoritmo.ToLowerInvariant();
            if (alg == "quick")
            {
                Gestor.QuickSort(libro);
            }
            else if (alg == "merge")
            {
                List<Receta> ordenada = Gestor.MergeSort(libro);
                // Reemplaza el libro original con la lista ordenada
                libro.Clear();
                foreach (var r in ordenada)
                {
                    libro.Add(r);
                }
            }
            else
            {
                throw new ArgumentException("Algoritmo no reconocido. Use 'quick' o 'merge'.");
            }
           
            // da la suma de tiempos
            int suma = 0;
            foreach (var receta in libro)
            {
                suma += receta.TiempoMinutos;
            }
            return suma;
        }
    }
}

8.- Clase Exportador TXT
public class ExportadorTxt : IExportador
{
    public void ExportarATxt(Usuario usuario, string rutaArchivo)
    {
        // Validaciones iniciales (opcionales, pero robustas)
        if (usuario == null)
        {
            throw new ArgumentNullException("usuario");
        }

        if (string.IsNullOrWhiteSpace(rutaArchivo))
        {
            throw new ArgumentException("La ruta del archivo no puede estar vacía.", "rutaArchivo");
        }

        // Construir contenido
        using (StreamWriter writer = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
        {
            // Encabezado con nombre y fecha (PDF página 11)
            writer.WriteLine($"Usuario: {usuario.Nombre}");
            writer.WriteLine($"Fecha de exportación: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine();

            if (usuario.LibrosRecetas.Count == 0)
            {
                writer.WriteLine("El usuario no tiene libros registrados.");
            }
            else
            {
                // Recorrer todos los libros
                foreach (var libro in usuario.LibrosRecetas)
                {
                    writer.WriteLine($"Libro: {libro.Key}");
                    
                    foreach (var receta in libro.Value)
                    {
                        // Usar ToString() de Receta (formato exacto)
                        writer.WriteLine($"  - {receta.ToString()}");
                    }
                    
                    writer.WriteLine();
                }
            }
        }
        // No se retorna nada; si hay error, la excepción se lanza (FileNotFoundException, etc.)
    }
}
