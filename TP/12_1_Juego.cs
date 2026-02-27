// Implementacion del Juego
try
{
    Console.WriteLine("Binevenido al torneo de guerreros");
    Console.WriteLine("Ingresa el nombre de tu Guerrero");
    string nombre = Console.ReadLine() ?? "";



///////////////////////////////////////////////

////////////////////////////////////////////////
catch
{

}

// Apartado de FUnciones
static Guerrero SeleccionarClase()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Selecciona tu clase de guerrero");
            Console.WriteLine("1) Caballero" +
                "\n2) Mago" +
                "\n3) Arquero" +
                "\n4) Geerrero Sombra");
            /*
            switch (opcion)
            {
                case 1:
                    inventario.MostrarSuministros();
                    break;

                case 2:
                    Console.WriteLine($"Ingresa El Nombre Del SUministro A Buscar: ");
                    string nombre = Console.ReadLine() ?? "";
                    inventario.buscarSuministro(nombre);
                    break;

                case 3:
                    inventario.ordenarPorNombre();
                    break;

                case 4:
                    inventario.invertirOrden();
                    break;
                */
            }
        }
        catch
        {

        }
    }
}






// Definiciones de clases

public class Guerrero()
{
    //Atributos
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Ataque {  get; set; }

    // Constructor
    public Guerrero(string nombre, int vida, int ataque)
    {
        Nombre = nombre;
        Vida = vida;
        Ataque = ataque;
    }

    // Metodos
    public virtual void Atacar(Guerrero enemigo)
    {
        int danio = Ataque + new Random().Next(0,5);

        // Recibir Daño
        enemigo.RecibirDanio(danio);
        Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre} causa {danio} de daño");
    }

    public void RecibirDanio (int cantidad)
    {
        Vida = Math.Max( Vida - cantidad, 0);
    }

    // Sobrecarga del operador +
    public static Guerrero operator +(Guerrero g1, Guerrero g2)
    {
        Console.WriteLine($"{g1.Nombre} + {g2.Nombre} Se fusionan en un nuevo guerrero");
        return new Guerrero($"{g1.Nombre}--{g2.Nombre}", ( g1.Vida+g2.Vida)/2 , (g1.Ataque + g2.Ataque) / 2);
    }
}

// Clase Caballero, Arquero, GuerreoSombra
public class Caballero : Guerrero
{
    // Constructor
    public Caballero(string nombre) : base(nombre, 120, 20) {    }

    // Polimorifsmo
    public override void Atacar(Guerrero enemigo)
    {
        Console.Write($"{Nombre} (Caballero) usa golpe critico");
        base.Atacar(enemigo);
    }
}

// Clase Mago
public class Mago : Guerrero
{
    // Constructor
    public Mago(string nombre) : base(nombre, 80, 25) { }

    // Polimorifsmo
    public override void Atacar(Guerrero enemigo)
    {
        Console.Write($"{Nombre} (Mago) lanza hechizo de fuego");
        base.Atacar(enemigo);
    }
}

// Clase Arquero
public class Arquero : Guerrero
{
    // Constructor
    public Arquero(string nombre) : base(nombre, 90, 15) { }

    // Polimorifsmo
    public override void Atacar(Guerrero enemigo)
    {
        int probabilidad = new Random().Next(1, 100);
        if (probabilidad < 30)
        {
            Console.WriteLine($"{Nombre} (Arquero) Dispara una flecha y falla");
        }
        else
        {
            Console.Write($"{Nombre} (Arquero) lanza una flecha y acierta");
            base.Atacar(enemigo);
        }
    }
}

// Clase Guerrero Sombra
public class GuerreroSombra : Guerrero
{
    // Constructor
    public GuerreroSombra(string nombre) : base(nombre, 110, 22) { }

    // Polimorifsmo
    public override void Atacar(Guerrero enemigo)
    {
        int chance = new Random().Next(1, 100);
        if (chance < 20)
        {
            Console.WriteLine($"{Nombre} (Guerrrero Sombra) Desaparece");
        }
        else
        {
            Console.Write($"{Nombre} (Guerrero Sombra) ataca");
            base.Atacar(enemigo);
        }
    }
}
