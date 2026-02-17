public class Dispositivo
{
    // Atributos - Campos 
    private string nombre;
    private bool encendido;
    private int consumo;

    // Propiedades
    public string Nombre
    { 
        get { return nombre; }
        set { nombre = value; }
    }

    public bool Encendido
    {
        get { return encendido; }
    }

    public int Consumo
    {
        get { return consumo; }
        set { consumo = value; }
    }


    // Constructor
    public Dispositivo(string nombre, int consumo)
    {
        this.nombre = nombre;
        this.consumo = consumo;
        this.encendido = false; //inicia en false
    }

    // Metodos
}