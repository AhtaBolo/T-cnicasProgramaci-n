// See https://aka.ms/new-console-template for more information
using System;

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
*/

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

