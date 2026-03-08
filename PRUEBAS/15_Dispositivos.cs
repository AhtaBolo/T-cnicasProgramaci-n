/* dispositivos:
    lampara (ajustable brillo)
    ventilador (ajustable velocidad), 
    altavoces (reproduciendo musica; de parametro una cancion y que diga que se esata reproduciendo)
 encender/apagar, mostrar estado actual
*/

using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

public interface IDispositivoInteligente
{
    void Encender();
    void Apagar();
    void MostrarEstado();
}

public class Lampara : IDispositivoInteligente
{
    // Atributos
    private string nombre;
    private bool encendido;
    private int brillo;

    // Propiedades
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public bool Encendido
    {
        get { return encendido; }
        set { encendido = value; }
    }

    public int Brillo
    {
        get { return brillo; }

        set
        {
            if (value >= 0 && value <= 100)
            {
                brillo = value;

                if (brillo > 0)
                {
                    encendido = true;
                }
                else
                {
                    encendido = false;
                }
            }
        }
    }

    // Constructor
    public Lampara(string nombre)
    {
        Nombre = nombre;
        // Encendido = false; // Redundancia con el set del brillo
        Brillo = 0;
    }

    // Sobrecarga del constructor
    public Lampara(string nombre, bool encendido)
    {
        Nombre = nombre;
        if (encendido == true)
        {
            Brillo = 50;
        }
        else
        {
            Brillo = 0;
        }
    }

    public Lampara(string nombre, bool encendido, int brillo)
    {
        Nombre = nombre;
        if (encendido == true)
        {
            Brillo = brillo;
        }
        else
        {
            Brillo = 0;
        }       
    }

    // Metodos
    public void Encender()
    {
        // Encendido =true;
        Brillo = 50;
        Console.WriteLine($"Lampara: {Nombre} Encendida");
    
    
    }
    public void Apagar()
    {
        // Encendido= false;
        Brillo = 0;
        Console.WriteLine($"Lampara: {Nombre} Apagada");
    }

    public void MostrarEstado()
    {
        if (Encendido == true)
        {
            Console.WriteLine($"La Lampara:\n Nombre: {Nombre}" +
                $"\n Estado: Encendida" +
                $"\n Brillo: {Brillo}%");
        }
        else
        {
            Console.WriteLine($"La Lampara: \nNombre: {Nombre}" +
                $"\n Estado: Apagada");
        }
    }

    public void AjustarBrillo(int nivel)
    {
        Brillo = nivel;
        Console.WriteLine($"El Brillo De {Nombre} Ahora Es: {Brillo}% ");
    }
}

public class Ventilador : IDispositivoInteligente
{
    // Atributos
    private string nombre;
    private bool encendido;
    private int velocidad;

    // Porpiedades
    public string Nombre
    {
        get { return nombre; } 
        set { nombre = value; }
    }

    public bool Encendido
    {
        get { return encendido; }
        set { encendido = value; }
    }

    public int Velocidad
    {
        get { return velocidad; }
        set 
        {
            if (value >=0 && value <= 3)
            {
                velocidad = value;

                if (velocidad > 0)
                {
                    encendido = true;
                }
                else
                {
                    encendido= false;
                }
            }
        }
    } 
    
    // Constructor
    public Ventilador(string nombre)
    {
        Nombre = nombre;
        // Encendido = false;
        Velocidad = 0;
    }
    
    // constructor Sobrecargado
    public Ventilador(string nombre, bool encendido)
    {
        Nombre = nombre;
        if (encendido == true)
        {
            Velocidad = 2;
        }
        else
        {
            Velocidad = 0;
        }
    }









    // Sobrecarga del constructor
    public Lampara(string nombre, bool encendido)
    {
        Nombre = nombre;
        Encendido = encendido;
        Brillo = 50;
    }

    public Lampara(string nombre, bool encendido, int brillo)
    {
        Nombre = nombre;
        Encendido = encendido;
        Brillo = brillo;
    }

    // Metodos
    public void Encender()
    {
        // Encendido =true;
        Brillo = 50;
        Console.WriteLine($"Lampara: {Nombre} Encendida");


    }
    public void Apagar()
    {
        // Encendido= false;
        Brillo = 0;
        Console.WriteLine($"Lampara: {Nombre} Apagada");
    }

    public void MostrarEstado()
    {
        if (Encendido == true)
        {
            Console.WriteLine($"La Lampara:\n Nombre: {Nombre}" +
                $"\n Estado: Encendida" +
                $"\n Brillo: {Brillo}%");
        }
        else
        {
            Console.WriteLine($"La Lampara: \nNombre: {Nombre}" +
                $"\n Estado: Apagada");
        }
    }

    public void AjustarBrillo(int nivel)
    {
        Brillo = nivel;
        Console.WriteLine($"El Brillo De {Nombre} Ahora Es: {Brillo}% ");
    }
}
// Para el estado general debe de ir en una lista con un foreach