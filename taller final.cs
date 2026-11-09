using System;
using System.Collections.Generic;

class HelloWorld
{
    class HabitacionHotel
    {
        // Atributos privados
        private int numero;
        private string tipo;
        private decimal precioPorNoche;
        private bool disponible;
        private string clienteActual;

        // Propiedades
        public int Numero
        {
            get { return numero; }
        }

        public string Tipo
        {
            get { return tipo; }
        }

        public decimal PrecioPorNoche
        {
            get { return precioPorNoche; }
        }

        public bool Disponible
        {
            get { return disponible; }
        }

        public string ClienteActual
        {
            get { return clienteActual; }
        }

        // Constructor
        public HabitacionHotel(int numero, string tipo, decimal precio)
        {
            this.numero = numero;
            this.tipo = tipo;

            if (precio > 0)
            {
                precioPorNoche = precio;
            }
            else
            {
                precioPorNoche = 50000;
            }

            disponible = true;
            clienteActual = "Ninguno";
        }

        // Metodo para reservar
        public void Reservar(string cliente)
        {
            if (disponible)
            {
                clienteActual = cliente;
                disponible = false;
                Console.WriteLine("Reserva realizada correctamente.");
            }
            else
            {
                Console.WriteLine("La habitacion esta ocupada.");
            }
        }

        // Metodo para liberar
        public void Liberar()
        {
            if (!disponible)
            {
                disponible = true;
                clienteActual = "Ninguno";
                Console.WriteLine("Habitacion liberada.");
            }
            else
            {
                Console.WriteLine("La habitacion ya esta libre.");
            }
        }

        // Metodo solicitado en el taller para aplicar descuento
        public void AplicarDescuento(int porcentaje)
        {
            decimal nuevoPrecio;

            if (porcentaje > 0 && porcentaje < 100)
            {
                nuevoPrecio = precioPorNoche -
                (precioPorNoche * porcentaje / 100);

                if (nuevoPrecio > 0)
                {
                    precioPorNoche = nuevoPrecio;
                    Console.WriteLine("Descuento aplicado correctamente.");
                }
                else
                {
                    Console.WriteLine("El precio no puede ser cero o negativo.");
                }
            }
            else
            {
                Console.WriteLine("Porcentaje no valido. Debe estar entre 1 y 99.");
            }
        }

        // Metodo solicitado en el taller para mostrar un resumen
        public string ObtenerDatosResumen()
        {
            return "[" + numero + "] " + tipo +
            " - $" + precioPorNoche +
            " - " + (disponible ? "Libre" :
            "Ocupada por: " + clienteActual);
        }

        // Metodo para mostrar informacion
        public void MostrarInfo()
        {
            Console.WriteLine(ObtenerDatosResumen());
        }
    }

    static void Main(string[] args)
    {
        // Lista de habitaciones
        List<HabitacionHotel> habitaciones =
        new List<HabitacionHotel>();

        habitaciones.Add(new HabitacionHotel(101, "Individual", 80000));
        habitaciones.Add(new HabitacionHotel(202, "Doble", 120000));
        habitaciones.Add(new HabitacionHotel(303, "Suite", 200000));

        // Reservas iniciales
        habitaciones[0].Reservar("Samuel Montiel");
        habitaciones[1].Reservar("jordan quintero");
        habitaciones[2].Reservar("dunga monsalvo");

        // Aplicar descuento
        habitaciones[2].AplicarDescuento(10);

        int opcion = 0;

        // Menu principal
        while (opcion != 5)
        {
            Console.WriteLine("\n===== HOTEL NOMADAS DEL CARIBE =====");
            Console.WriteLine("1. Mostrar habitaciones");
            Console.WriteLine("2. Liberar habitacion");
            Console.WriteLine("3. Aplicar descuento");
            Console.WriteLine("4. Mostrar resumen y estadisticas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un numero valido.");
                opcion = 0;
                continue;
            }

            switch (opcion)
            {
                case 1:
                    foreach (HabitacionHotel h in habitaciones)
                    {
                        h.MostrarInfo();
                    }
                    break;

                case 2:
                    Console.Write("Ingrese numero de habitacion: ");
                    int numero = int.Parse(Console.ReadLine());

                    foreach (HabitacionHotel h in habitaciones)
                    {
                        if (h.Numero == numero)
                        {
                            h.Liberar();
                        }
                    }
                    break;

                case 3:
                    Console.Write("Ingrese numero de habitacion: ");
                    int num = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese porcentaje de descuento: ");
                    int descuento = int.Parse(Console.ReadLine());

                    foreach (HabitacionHotel h in habitaciones)
                    {
                        if (h.Numero == num)
                        {
                            h.AplicarDescuento(descuento);
                        }
                    }
                    break;

                case 4:
                    int libres = 0;
                    int ocupadas = 0;
                    decimal suma = 0;

                    foreach (HabitacionHotel h in habitaciones)
                    {
                        if (h.Disponible)
                        {
                            libres++;
                        }
                        else
                        {
                            ocupadas++;
                        }

                        suma += h.PrecioPorNoche;
                        h.MostrarInfo();
                    }

                    decimal promedio = suma / habitaciones.Count;

                    Console.WriteLine("\n===== ESTADISTICAS =====");
                    Console.WriteLine("Habitaciones libres: " + libres);
                    Console.WriteLine("Habitaciones ocupadas: " + ocupadas);
                    Console.WriteLine("Precio promedio: $" + promedio);

                    break;

                case 5:
                    Console.WriteLine("Gracias por utilizar el sistema.");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }
    }
}
