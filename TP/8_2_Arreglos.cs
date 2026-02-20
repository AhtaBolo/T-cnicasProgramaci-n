// Arreglos con [] arreglos son objetos sin atributos

// Declaracion con tmaño explicito
using static System.Runtime.InteropServices.JavaScript.JSType;

int [] numeros = new int[2]; //tambien es un objeto, una instancia de un arreglo de 2 numeros

// Asignando elementos al arreglo
numeros[1] = 8; // atraves del indice 0 - idk

// Obteniendo valores
if (numeros[0] == 0)
{
    Console.WriteLine("Hay un cero");
}

// Obteniendo la longitud del arreglo , declaracion explicita
Console.WriteLine(numeros.Length); //se usa el .lenght para obtener la longitud, mas no indie (0, 1);

//declaracion implicita
int[] numeros2 = new[] { 4, 5, 3, 6, 5 }; //colocas los valores adentro
Console.WriteLine(numeros2[3]); // entra por indice


char[] vocales = new[] {'a', 'e', 'i', 'o', 'u'}; //comilla individual
for (int i = 0; i < vocales.Length; i++)
{
    Console.WriteLine(vocales[i]);
}
foreach (char c in vocales) // Variante del for, ciclo repetitivo, cual es el valor inficidual y el arrelgo a contar
{
    Console.WriteLine(c);
}


bool[] estado = new bool[3]; // arreglo de booleanos

foreach (bool b in estado) // Variante del for, ciclo repetitivo, cual es el valor inficidual y elarrelgo a contar
{
    Console.WriteLine(b);
    //if (b==0) // no se aplica porque se ve como false, no 0
    if (!b) // negacion de si es falso, se pregunta si es falso o verdadero, si se quita el !, se pregunta si b es verdadero
    {
        Console.WriteLine("Idk");
    }
}



// METODOS ARREGLOS

//Ordenar arreglo
Console.WriteLine("Desordenado");
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

Array.Sort(numeros2); // Ordenamiento tipo burbuja SORT mayor a menor
Console.WriteLine("Ordenado con Sort");
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

Array.Reverse(numeros2); // Ordenamiento tipo burbuja Reverse invierte las posiciones
Console.WriteLine("Reverse");
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

// Metodo para buscar un valor, funciono pero creo que fallaba algo tecnico quitando el sort y el reverse
int indice = Array.BinarySearch(numeros2,6);
Console.WriteLine(indice);


// LISTAS 
List <int> numeros3 = new List<int>(); // se instancia la lista, no necesita saber el numero de elementos
//Arreglos definidos, Listas dinamicas

numeros3.Add(7);
numeros3.Add(20);

foreach (int numero in numeros3)
{
    Console.WriteLine(numero);
}
