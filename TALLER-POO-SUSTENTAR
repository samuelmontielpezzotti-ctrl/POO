using System;

class HabitacionHotel
{
    // 1. Atributos privados
    private int numero;
    private string tipo;
    private double precioPorNoche;
    private bool disponible;
    private string clienteActual;

    // 2. Propiedades públicas
    public int Numero
    {
        get { return numero; }
    }

    public string Tipo
    {
        get { return tipo; }
        set
        {
            if (value == "Individual" ||
                value == "Doble" ||
                value == "Suite")
            {
                tipo = value;
            }
            else
            {
                throw new ArgumentException("Tipo de habitación no válido.");
            }
        }
    }

    public double PrecioPorNoche
    {
        get { return precioPorNoche; }
        set
        {
            if (value > 0)
            {
                precioPorNoche = value;
            }
            else
            {
                throw new ArgumentException("El precio debe ser mayor a cero.");
            }
        }
    }

    public bool Disponible
    {
        get { return disponible; }
    }

    public string ClienteActual
    {
        get { return clienteActual; }
    }

    
    public HabitacionHotel(int numero, string tipo, double precioPorNoche)
    {
        this.numero = numero;
        Tipo = tipo;
        PrecioPorNoche = precioPorNoche;
        disponible = true;
        clienteActual = "";
    }

    
    public double Reservar(string nombreCliente, int noches)
    {
        if (disponible && !string.IsNullOrWhiteSpace(nombreCliente)
            && noches > 0)
        {
            disponible = false;
            clienteActual = nombreCliente;

            return precioPorNoche * noches;
        }

        return -1;
    }

    // Método Liberar
    public bool Liberar()
    {
        if (!disponible)
        {
            disponible = true;
            clienteActual = "";
            return true;
        }

        return false;
    }

    
    public string MostrarInfo()
    {
        string estado = disponible ? "Disponible" : "Ocupada";

        string informacion = "Habitación: " + numero +
            "\nTipo: " + tipo +
            "\nPrecio por noche: $" + precioPorNoche.ToString("N0") +
            "\nEstado: " + estado;

        if (!disponible)
        {
            informacion += "\nCliente actual: " + clienteActual;
        }

        return informacion;
    }

    
    public void AplicarDescuento(int porcentaje)
    {
        if (porcentaje >= 0 && porcentaje <= 100)
        {
            precioPorNoche = precioPorNoche *
                (1 - porcentaje / 100.0);
        }
        else
        {
            Console.WriteLine("Porcentaje de descuento no válido.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        HabitacionHotel habitacion101 =
            new HabitacionHotel(101, "Individual", 50000);

        HabitacionHotel habitacion202 =
            new HabitacionHotel(202, "Doble", 80000);

        HabitacionHotel habitacion303 =
            new HabitacionHotel(303, "Suite", 150000);

      
        Console.WriteLine("=== ESTADO INICIAL ===");
        Console.WriteLine(habitacion101.MostrarInfo());
        Console.WriteLine();
        Console.WriteLine(habitacion202.MostrarInfo());
        Console.WriteLine();
        Console.WriteLine(habitacion303.MostrarInfo());

        
        Console.WriteLine("\n=== OPERACIONES ===");

        double costo = habitacion101.Reservar("Samuel montiel", 3);

        Console.WriteLine("Reserva de Samuel montiel: $" +
            costo.ToString("N0"));

        
        double costoLuis = habitacion202.Reservar("Jordan quintero", 2);

        Console.WriteLine("Reserva de Jordan quintero: $" +
            costoLuis.ToString("N0"));

        
        double segundoIntento =
            habitacion101.Reservar("Otro cliente", 2);

        if (segundoIntento == -1)
        {
            Console.WriteLine(
                "La habitación 101 no está disponible.");
        }

        
        if (habitacion101.Liberar())
        {
            Console.WriteLine("Habitación 101 liberada correctamente.");
        }

        
        habitacion303.AplicarDescuento(10);

        Console.WriteLine(
            "Descuento del 10% aplicado a la habitación 303.");

        
        double costoCarlos =
            habitacion101.Reservar("Carlos Ruiz", 1);

        Console.WriteLine("Reserva de Carlos Ruiz: $" +
            costoCarlos.ToString("N0"));

        
        Console.WriteLine("\n=== ESTADO FINAL ===");
        Console.WriteLine(habitacion101.MostrarInfo());
        Console.WriteLine();
        Console.WriteLine(habitacion202.MostrarInfo());
        Console.WriteLine();
        Console.WriteLine(habitacion303.MostrarInfo());

        
        int ocupadas = 0;

        if (!habitacion101.Disponible)
            ocupadas++;

        if (!habitacion202.Disponible)
            ocupadas++;

        if (!habitacion303.Disponible)
            ocupadas++;

        Console.WriteLine("\nTotal de habitaciones ocupadas: " +
            ocupadas);

        Console.WriteLine("\nFIN DEL PROGRAMA...");
        Console.ReadKey();
    }
}


