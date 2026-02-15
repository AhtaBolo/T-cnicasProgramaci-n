// Programa principal
/* 
Calculadora calculadora = new Calculadora(5, 2);


float resultadoD = calculadora.Division();
float resultadoD2 = calculadora2.Division();

Console.WriteLine(resultadoD);
Console.WriteLine(resultadoD2);

//GET
Console.WriteLine($"El resultado de la calculadora 1 es {calculadora, Numero1}");
Console.WriteLine($"El resultado de la calculadora 1 es {calculadora2, Numero2}");

int resultadoS = calculadora.Suma();
Console.WriteLine(resultadoS);

int resultadoR = calculadora.Resta();
Console.WriteLine(resultadoR);

int resultadoM = calculadora.Multiplicacion();
Console.WriteLine(resultadoM);

Console.WriteLine($"El primer );

*/

//FUncion Factoria
/*

Calculadora calculadora2 = new Calculadora(6, 8);

 
Console.WriteLine($"El resultado calculadora Cientifica : {calculadoraCientifica.Suma()}");

Console.WriteLine($"El resultado de la caalculadora basica : {calculadora2.Suma(3)}");

Calculadora calculadora3 = calculadora2 + calculadora1;

Console.WriteLine($"Calculadora 3 ({calculadora3.Numero1}, {calculadora3.Numero2})");
calculadoraCientifica.MensajeC();
*/

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*

Console.WriteLine("Ingresa el primer numero a operar");
int num1 = int.Parse(Console.ReadLine() ?? "");
Console.WriteLine("Ingresa el segundo numero a operar");
int num2 = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("Presiona: \n1- Calculadora Basica \n2- Calculadora Cientifica");
int sel = int.Parse(Console.ReadLine() ?? "");

if (sel == 1)
{
    Calculadora calculadora1 = new Calculadora(1, 3);
    Console.WriteLine("1- Suma \n2- Resta\n3- Multiplicacion \n4- Division");
    int sel = int.Parse(Console.ReadLine() ?? "");

    switch (sel)
    {
        case 1:
            Console.WriteLine($"El resultado de la caalculadora basica : {calculadora1.Suma()}");
            break;
        case 2:
            Console.WriteLine($"El resultado de la caalculadora basica : {calculadora1.Resta()}");
            break;
        case 3:
            Console.WriteLine($"El resultado de la caalculadora basica : {calculadora1.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"El resultado de la caalculadora basica : {calculadora1.Division()}");
            break;
        default;
    }

}
else if (sel == 2)
{
    CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica(5, 2);
    Console.WriteLine("1- Suma \n2- Resta\n3- Multiplicacion \n4- Division" +
        "\n5- Logaritmo\n6- Raiz Cuadrada \n7- Factorial");
    int sel = int.Parse(Console.ReadLine() ?? "");
}


switch ()
{
    case 1:
        Console.WriteLine($"El resultado de la caalculadora basica : {calculadora1.Suma()}");
        break;
    case 2:
        Console.WriteLine($"El resultado de la caalculadora basica : {calculadora1.Resta()}");
        break;
    case 3:
        Console.WriteLine($"El resultado de la caalculadora basica : {calculadora1.Multiplicacion()}");
        break;
    case 4:
        Console.WriteLine($"El resultado de la caalculadora basica : {calculadora1.Division()}");
        break;


    case 5:
        Console.WriteLine($"El resultado calculadora cientifica: {CalculadoraCientifica.Logaritmo()}");
        break;
    case 2:
        Console.WriteLine($"El resultado calculadora cientifica: {CalculadoraCientifica.RaizCuadrada()}");
        break;
    case 7:
        Console.WriteLine($"El resultado calculadora cientifica: {CalculadoraCientifica.Factorial()}");
    default;



    default;
}





// Clases

//Calculadora basica que opera solo 2 numeros enteros
public class Calculadora
{
    // Atributos public 
    public int Numero1 { get; set; }
    public int Numero2 { get; set; }

    // Atributo Privado
    private int Resultado;
    private string mensaje = "Asdfg ASDFG";

    // Constructor 
    public Calculadora(int numero1, int numero2)
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }

    // Metodos
    public virtual int Suma()
    {
        Resultado = Numero1 + Numero2;
        return Resultado;
    }

    // Metodo Privado                                        0000000000000000000000000
    private void MostrarMensaje()
    {
        Console.WriteLine(mensaje);
    }

    // METodo proregido
    protected void Mensaje()
    {
        MostrarMensaje();
    }


    // Sobrcarga del metodo suna
    public virtual int Suma(int num3)
    {
        return Numero1 + Numero2 + num3;
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
        if (Numero2 == 0)
        {
            Console.WriteLine("MATH ERROR");
            return 0;
        }
        return (float)Numero1 / Numero2;
    }

    // Sobrecarga del operador +
    public static Calculadora operator +(Calculadora calc1, Calculadora cal2)
    {
        return new Calculadora(calc1.Numero1 + calc1.Numero1, calc1.Numero2 + calc1.Numero2);
    }
}


// Clase Hija

public class CalculadoraCientifica : Calculadora
{
    //Atributos


    //Constructor
    public CalculadoraCientifica(int num1, int num2) : base(num1, num2)
    {
    }

    //Metodos
    public double Logaritmo()
    {
        return MathF.Log(Numero1);
    }

    public double RaizCuadrada()
    {
        return MathF.Sqrt(Numero2);
    }


    // Override Cambia el metodo geredado

    public override int Suma()
    {
        int resultado = base.Suma();
        return resultado * resultado;

    }
    public void MensajeC()
    {
        base.Mensaje();
    }
    public int Factorial()
    {
        if (Numero1 == 0 || Numero1 == 1)
        {
            return 1;
        }
        else if (Numero1 < 0)
        {
            Console.WriteLine("No es posible el factorial de un numero negativo");
            return 0;
        }
        else
        {
            int Fct = 1;
            for (int i = 2; i <= Numero1; i++)
            {
                Fct = Fct * i;
            }
            return Fct;
        }

    }
}

*/