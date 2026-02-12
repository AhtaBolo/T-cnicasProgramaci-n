// Programa principal
Calculadora calculadora = new Calculadora(5, 2);

Console.WriteLine("Los numeros a operar son: \nNumero 1 = 5 \nNumero 2 = 2 \n");

float resultadoD = calculadora.Division();
Console.WriteLine($"El resultado de la division es: {resultadoD}");

int resultadoS = calculadora.Suma();
Console.WriteLine($"El resultado de la suma es: {resultadoS}");

int resultadoR = calculadora.Resta();
Console.WriteLine($"El resultado de la resta es: {resultadoR}");

int resultadoM = calculadora.Multiplicacion();
Console.WriteLine($"El resultado de la multiplicacion es: {resultadoM}");

// Clases



//Calculadora basica que opera solo 2 numeros enteros
public class Calculadora
{
    // Atributos public 
    public int Numero1 { get; set; }
    public int Numero2 { get; set; }

    // Constructor 
    public Calculadora (int numero1, int numero2)
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }

    // Metodos
    public int Suma()
    {
        return Numero1 + Numero2;
    }

    public int Resta()
    {
        return Numero1 - Numero2;
    }

    public int Multiplicacion()
    {
        return Numero1 * Numero2;
    }
    public float Division()
    {
        if (Numero2==0)
        {
            Console.WriteLine("MATH ERROR");
            return 0;
        }
        return (float) Numero1 / Numero2;
    }
}