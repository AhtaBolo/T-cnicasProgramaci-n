/* Programa Principal Del Banco
Banco banco = new Banco();
// FALTA ESTA PARTE DEL INICIO
char repetir 'y';
do
{
    try
    {
        CuentaBancaria cuentaOrigen = banco.BuscarCuenta("123456");

        // Ejercicio Menu
        Console.WriteLine("Selecciona El Movimiento A Realizar \n1)Depositar \n2)Reitar \nTransferir");
        int menu = int.Parse(Console.ReadLine() ?? "");
        switch (menu)
        {
            case 1:
                Console.WriteLine($"Saldo Inicial:{cuentaOrigen.Saldo}");
                Console.WriteLine($"Ingresa El Monto a Depositar\n");
                int deposito = int.Parse(Console.ReadLine() ?? "");
                cuentaOrigen.Saldo += deposito;
                Console.WriteLine($"\nIngresa El Monto a Depositar\n");
                break;

            case 2:
                Console.WriteLine($"\nEl resultado de la calculadora básica : {calculadora.Resta()}");
                break;

            case 3:
                Console.WriteLine($"Saldo Inicial:${cuentaOrigen.Saldo}");
                Console.WriteLine($"Excribe la cuenta destino para tansferir:");
                CuentaBancaria cuentaDestino = banco.BuscarCuenta(Console.ReadLine() ?? "");
                Console.WriteLine($"Excribe la cantidad para tansferir: $");
                decimal cantidad = decimal.Parse(Console.ReadLine() ?? "");

                Console.WriteLine($"Haceindo Transferencia ...");
                cuentaOrigen.Transferir(cuentaDestino, cantidad);
                Console.WriteLine($"Saldo Final:${cuentaOrigen.Saldo}");


                break;

            default: // <--- ¡Aquí van dos puntos, no punto y coma!
                Console.WriteLine("\nOperacion no válida");
                break;
        }

        Console.WriteLine("Esrcibe Y para realizar omas operaciones");
        repetir = char.Parse(Console.ReadLine() ?? "");
    }


    catch (CuentaNoEncontradaException ex)
    {
        Console.WriteLine(ex.Message);
        // Console.WriteLine(ex.ToString()); // Te arroja el string directo
    }
    catch (SaldoInsuficienteException ex)
    {
        Console.WriteLine(ex.Message);
        // Console.WriteLine(ex.ToString()); // Te arroja el string directo
    }
    catch (DepositoInvalidoException ex)
    {
        Console.WriteLine(ex.Message);
        // Console.WriteLine(ex.ToString()); // Te arroja el string directo
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        // Console.WriteLine(ex.ToString()); // Te arroja el string directo
    }

} 

// Excepciones
class SaldoInsuficienteException : Exception
{
    // Solo se modifica el constructor en la herencia
    public SaldoInsuficienteException(string mensaje) : base(mensaje) { }
}

class CuentaNoEncontradaException : Exception
{
    // Solo se modifica el constructor en la herencia
    public CuentaNoEncontradaException(string mensaje) : base(mensaje) { }
}

class DepositoInvalidoException : Exception
{
    // Solo se modifica el constructor en la herencia
    public DepositoInvalidoException(string mensaje) : base(mensaje) { }
}

// Clses del Banco
public class CuentaBancaria
{
    // Atributos
    public string NumeroCuenta { get; } //No lleva el set para que no sea moficable despues de ser creado
    public decimal Saldo {  get; set; }

    // Construcotor
    public CuentaBancaria(string numeroCuenta, decimal saldo)
    {
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
    }

    // Metodos
    public void Depositar(decimal cantidad)
    {
        if(cantidad < 0)
        {
            throw new DepositoInvalidoException("No Puedes Depositar Cantidades Negativas");
        }
        Saldo += cantidad; // += hace lo mismo que  saldo = saldo + cantidad
    }

    public void Retirar(decimal cantidad)
    {
        if (cantidad > Saldo)
        {
            throw new SaldoInsuficienteException("Saldo Insuficiente Para La Operación");
        }
        Saldo -= cantidad; // -= hace lo mismo que  saldo = saldo - cantidad
    }
    public void Transferir(CuentaBancaria destino, decimal cantidad)
    {
        if (destino == null)
        {
            throw new CuentaNoEncontradaException("Cuenta No Encontrada");
        }
        Retirar(cantidad); // SE retira de la propia cuenta
        destino.Depositar(cantidad); // Se llama a la cuenta de destino y se ejecuta el depositar bajo el mismo monto
    }
}

public class Banco
{
    // Atributos
    private CuentaBancaria[] cuentas; 

    // Contructor 
    public Banco()
    {
        cuentas = new CuentaBancaria[] // Lo de abajo es el arreglo
        {
            new CuentaBancaria("123456", 600),
            new CuentaBancaria("789456", 200),
            new CuentaBancaria("741852", 10000),
        };
    }

    // Metodos
    public CuentaBancaria BuscarCuenta(string numeroCuenta)
    {
        foreach(CuentaBancaria cuenta in cuentas)
        {
            if (cuenta.NumeroCuenta == numeroCuenta)
            {
                return cuenta;
            }
        }
        throw new CuentaNoEncontradaException("Cuenta No Encontrada");
    }
}
