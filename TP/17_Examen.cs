// Programa Principal


// Clases
using System.Security.Cryptography.X509Certificates;

public abstract class Bola
{
    // Atributos Y Propiedades
    protected double Masa { get; }
    protected double PosX { get; }
    protected double PosY { get; }

    // Variables de clase  ////////////////////////////////////////////

    // Constructor
    public Bola (double masa)
    {
        Masa = masa;
        PosX = 0;
        PosY = 0;
    }

    // Metodos
    public void Mover(double nposX, double nposY) // llevara void?
    {
        double posX = PosX;
        double posY = PosX;
        double Dx = posX + nposX;
        double Dy = posY + nposY;

    }
    public abstract double Friccion(); // ASDFGASFDG
}

public class BolaNormal : Bola
{
    // Constructor
    public BolaNormal(double masa) : base(masa) {  }
    public override double Friccion()
    {
        return 1.2;
    }
}

public class BolaProfesional : Bola
{
    // Constructor
    public BolaProfesional(double masa) : base(masa) { }
    public override double Friccion()
    {
        return 0.6;
    }
}

public class Tiro
{
    // Atributos y Propiedades
    private double Impulso { get; }
    private double DirX { get; }
    private double DirY {  get; }

    // Constructor
    public Tiro(double impulso, double dirX, double dirY)
    {
        Impulso = impulso;
        DirX = dirX;
        DirY = dirY;
    }

    // Metodos

}

public interface IEstrategiaCalculo /////// NOPE ////////////////////////////////////////////
{
    void calculofisico();
    void calculosimple();
}

public class SimuladorBillar
{
    // Atributos  Y Propiedaeds
    // Constructor
    // Metodos
    public void CrearBola()
    {
        // ASDFGASDFG
    }

    public void RegistrarTiro()
    { 
        
    }


}
