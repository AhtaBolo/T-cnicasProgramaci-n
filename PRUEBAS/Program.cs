
/*
 * using System;
using System.Runtime.InteropServices;

Console.WriteLine("AsdfgAsdfg, ya funciona");
Console.WriteLine(""); //IA es mejor para la memoria que este (); sin ""

Console.WriteLine("Ingresa El Nombre: ");
string nombre = Console.ReadLine() ?? "";

Console.WriteLine(); //IA

Console.WriteLine("Ingresa La Edad: ");
int edad = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("\nEstado: "); //IA
String estado = Console.ReadLine() ?? ""; //YO

Console.WriteLine($"\nNombre: {nombre}"); //IA \n
Console.WriteLine($"Edad: {edad}");
Console.WriteLine($"Estado: {estado}\n"); //YO

/*

Console.WriteLine("Primera Parte\n\n"); //¡LO PUSE YO!

Console.WriteLine("Años A Sumar:");
int años = int.Parse(Console.ReadLine() ?? "");

// Calcula el número dentro de la frase
Console.WriteLine($"En {años} años tendrás {edad + años} años.");
// Imprime: El año que viene tendrás 21 años.

Console.WriteLine("Ingresa Tu Marca: ");
string marca = Console.ReadLine() ?? "";

// Convierte a mayúsculas ahí mismo
Console.WriteLine($"Tu marca se llama: {marca.ToUpper()}");
Console.WriteLine($"Tu marca es: {marca.ToLower()}");



// PARA ADMITIR LETRAS PERO MANDA A 0


Console.WriteLine("\n\nPARTE DOS\n\n");
Console.WriteLine("Ingresa La Edad: ");
string textoEscrito = Console.ReadLine() ?? ""; // Leemos el texto primero

int edad2; // Creamos la variable vacía

// "out edad" significa: "Si logras convertirlo, guarda el resultado en la variable 'edad'"
bool esNumeroValido = int.TryParse(textoEscrito, out edad2);

if (esNumeroValido)
{
    Console.WriteLine($"¡Perfecto! Tienes {edad2} años.");
}
else
{
    Console.WriteLine("Eso no es un número. Asumiremos que tienes 0 años.");
}



/* 
    PARA NUMEROS MUY LARGOSlong es el apodo de Int64 (64 bits).
    Su límite es gigantesco: 9,223,372,036,854,775,807. (Básicamente, nunca lo llenarás contando cosas normales).


Console.WriteLine("Ingresa un número GIGANTE: ");
string entrada = Console.ReadLine() ?? "";

long numeroGigante; // Usamos long en lugar de int

// Usamos long.TryParse
if (long.TryParse(entrada, out numeroGigante))
{
    Console.WriteLine($"¡Wow! El número {numeroGigante} sí cupo.");
}
else
{
    Console.WriteLine("Oye, eso ya es demasiado grande incluso para un long (o no es un número).");
}




// Aprendiendo a usar \ Secuencias de escape
Console.WriteLine($"Tu nombre es:\t{nombre}"); //tabulador \t

Console.WriteLine("Karla Jacinto cantaba \"Stereo Hearts\" de Gym Class Heroes"); //Solo pone comillas \" \"

Console.WriteLine("No se que poner de ruta C:Documentos\\Hachi\\Es\\Feo\\Muy\\Muy\\Feo"); // \\ doble porque si es individual piensa en secuencias de escape

Console.WriteLine(@"Ahora no importan las secuencias de escape C:Bongo\Bong\Manu\Caho\20:25"); // @ingnora las rutas de escape

Console.WriteLine("Comee\b Cacaaaa\bb \bx" /*\rEntonces desaparecera lo de atras si escribo enfrente");


Console.WriteLine("Hola\b");    // Imprime: Hola (Retrocede, pero no escribe nada encima)
Console.WriteLine("Hola\bX");   // Imprime: HolX (Retrocede y escribe 'X' sobre la 'a')
Console.WriteLine("Hola\b ");   // Imprime: Hol  (Retrocede y escribe espacio sobre la 'a')


// Esto NO abre nada, ni revisa si existe. Solo guarda letras en memoria.
string miRuta = @"C:\Usuarios\Carlos\Documentos\tarea.txt";

Console.WriteLine($"{miRuta}, tonteando"); // Solo imprime las letras en la pantalla negra.


// Paso 1: Definimos la ruta (Solo texto)
string rutaArchivo = @"C:\Desktop\System32\notepad.exe";

// Paso 2: Usamos una herramienta real (File) para verificar si existe
if (System.IO.File.Exists(rutaArchivo))
{
    Console.WriteLine("¡Sí existe! El Bloc de Notas está ahí.");
}
else
{
    Console.WriteLine("No encontré nada en esa ruta.");
}

string ruta = "C:\\Juegos";
string accion = "tonteando";

// Forma 1: Interpolación (La moderna con $)
Console.WriteLine($"{ruta}, {accion}");

// Forma 2: Composite Formatting (La clásica)
// El {0} se reemplaza con la primera variable después de la coma (ruta)
// El {1} se reemplaza con la segunda (accion)
Console.WriteLine("{0}, {1}", ruta, accion);

Console.WriteLine("Iniciando cuenta regresiva...");

// Usamos un ciclo (bucle) para contar del 10 al 0
for (int i = 10; i >= 0; i--)
{
    // El \r regresa al inicio y sobrescribe el número anterior
    Console.Write($"\rDetonación en: {i} segundos...   ");

    // Esto pausa el programa 1000 milisegundos (1 segundo) para que alcances a verlo
    System.Threading.Thread.Sleep(1000);
}

Console.WriteLine("\n¡BOOM!");
System.Threading.Thread.Sleep(1000);
Console.Clear();

string claveCorrecta = "1234";
string loQueEscribioElUsuario = " 1234 "; // Nota los espacios al inicio y final

if (claveCorrecta == loQueEscribioElUsuario)
{
    Console.WriteLine("Entraste");
}
else
{
    Console.WriteLine("Error"); // ¡Va a caer aquí!
}

Console.WriteLine("Ingresa tu usuario:");
string usuario = Console.ReadLine() ?? "";

// Limpiamos los espacios basura antes de guardar o comparar
usuario = usuario.Trim();

Console.WriteLine($"Hola, '{usuario}'");
// Si escribiste "   Carlos   ", ahora dirá "Hola, 'Carlos'"

*

Console.WriteLine("Escribe algo (ej. 'gato'):");
string texto = Console.ReadLine() ?? "";

// 1. PROPIEDAD (Sustantivo / Dato)
// Solo preguntamos "¿Cuántas letras tienes?". No cambia nada.
int cantidadLetras = texto.Length;

// 2. MÉTODO (Verbo / Acción)
// Ordenamos: "¡Transfórmate a mayúsculas AHORA!".
// Los () son el botón de "Enter" para ejecutar la orden.
string enGritos = texto.ToUpper();


// --- RESULTADOS ---
Console.WriteLine($"Dato (Length): El texto tiene {cantidadLetras} letras.");
Console.WriteLine($"Acción (ToUpper): El texto transformado es '{enGritos}'");
*/
// Tu código principal se convierte en un "Índice" o lista de pasos

/*
#region Calculadora

Saludar();
SumarDosNumeros();
Despedirse();

// --- ZONA DE DEFINICIONES (Esto va hasta abajo) ---

void Saludar() // Creas la orden "Saludar"
{
    Console.WriteLine("¡Bienvenido al programa!");
}

void SumarDosNumeros() // Creas la orden "Sumar"
{
    Console.WriteLine("Dame el primer número:");
    int n1 = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine("Dame el segundo número:");
    int n2 = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine($"La suma es: {n1 + n2}");
}

void Despedirse()
{
    Console.WriteLine("Fin del programa. Bye!");
}
#endregion




#region Bloque de Bienvenida
/*
Console.Clear();
Console.WriteLine("-----------------------------");
Console.WriteLine("     SISTEMA DE PRUEBAS      ");
Console.WriteLine("-----------------------------");

#endregion

dynamic cosa = "Hola";
Console.WriteLine(cosa); // Imprime texto

cosa = 55;               // ¡Cambiamos a int! Y NO marca error.
Console.WriteLine(cosa + 10); // Imprime 65

cosa = false;            // ¡Ahora es bool!
Console.WriteLine(cosa);

*/

// Este método promete devolver un entero (int)
int Sumar(int a, int b)
{
    return a + b; // Aquí está la entrega del paquete
}

// USO:
// Tengo que poner una "canasta" (variable) para cachar lo que me lanza
int resultado = Sumar(5, 5);