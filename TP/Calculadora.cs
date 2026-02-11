// Programa principal
Calculadora calculadora = new Calculadora(5, 2);

float resultadoD = calculadora.Division();
Console.WriteLine(resultadoD);

int resultadoS = calculadora.Suma();
Console.WriteLine(resultadoS);

int resultadoR = calculadora.Resta();
Console.WriteLine(resultadoR);

int resultadoM = calculadora.Multiplicacion();
Console.WriteLine(resultadoM);

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