using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1
{
    internal class Program
    {
        static List<Mascota> mascotas = new List<Mascota>();
        static void Main(string[] args)
        {
            menu();
        }
        

        // Enumeracion para estado de salud
        public enum EstadoSalud
        {
            Saludable,
            EnTratamiento,
            Urgencia
        }

        //Clase  de la Interfaz Auditable
        public interface IAuditable
        {
            void AuditarAccion(string tipo, string descripcion);
        }

        public abstract class Mascota : IAuditable
        {
            private string nombre, especie, raza, nombreDueno;
            private int edad;
            private EstadoSalud estadoSalud;


            public string Nombre
            {
                get => nombre;
                set => nombre = value;
            }

            public string Especie
            {
                get => especie;
                set => especie = value;
            }
            public string Raza
            {
                get => raza;
                set => raza = value;
            }
            public string NombreDueno
            {
                get => nombreDueno;
                set => nombreDueno = value;
            }
            public int Edad
            {
                get => edad;
                set => edad = value;
            }

            public EstadoSalud EstadoSalud
            {
                get => estadoSalud;
                set => estadoSalud = value;
            }

            //Constructor
            public Mascota(string nombre, string especie, string raza, string nombreDueño, int edad)
            {
                Nombre = nombre;
                Especie = especie;
                Raza = raza;
                NombreDueno = nombreDueno;
                Edad = edad;
                EstadoSalud = EstadoSalud.Saludable; //Estado inicial

            }
            //Metodo abstracto
            public abstract String RegistrarConsulta(string Motivo);
            public abstract String MostrarInformacion();

            //Implementacion de la interfaz IAuditable
            public void AuditarAccion(string tipo, string descripcion)
            {
                string mensajeAuditoria = $"[{DateTime.Now}] {tipo}: {descripcion}";
                Console.WriteLine($"AUDITORIA: {mensajeAuditoria}");
            }
        }

        public class Perro : Mascota
        {
            private double peso, tamaño;

            //Constructor
            public Perro(string nombre, string especie, string raza, string nombreDueno, int edad, double tamaño, double peso)
                : base(nombre, especie, raza, nombreDueno, edad)
            {
                this.tamaño = tamaño;
                this.peso = peso;
            }
            //Implementacion de los metodos abstractos
            public override string RegistrarConsulta(string Motivo)
            {
                return $"Consulta registrada para el perro {Nombre} por el motivo: {Motivo}";
            }
            public override string MostrarInformacion()
            {
                return $"Perro: {Nombre}, Especie: {Especie}, Raza: {Raza}, Dueño: {NombreDueno}, Edad: {Edad}, Tamaño: {tamaño}, Peso: {peso}";
            }
        }
        public class Gato : Mascota
        {
            private double peso, tamaño;
            //Constructor
            public Gato(string nombre, string especie, string raza, string nombreDueno, int edad, double tamaño, double peso)
                : base(nombre, especie, raza, nombreDueno, edad)
            {
                this.tamaño = tamaño;
                this.peso = peso;

            }
            //Implementacion de los metodos abstractos
            public override string RegistrarConsulta(string Motivo)
            {
                return $"Consulta registrada para el gato {Nombre} por el motivo: {Motivo}";
            }
            public override string MostrarInformacion()
            {
                return $"Gato: {Nombre}, Especie: {Especie}, Raza: {Raza}, Dueño: {NombreDueno}, Edad: {Edad}, Tamaño: {tamaño}, Peso: {peso}";
            }
        }
        public class Ave : Mascota
        {
            private double peso, tamaño;
            public Ave(string nombre, string especie, string raza, string nombreDueno, int edad, double peso, double tamaño)
                : base(nombre, especie, raza, nombreDueno, edad)
            {
                this.tamaño = tamaño;
                this.peso = peso;
            }

            public override string RegistrarConsulta(string Motivo)
            {
                return $"Consulta registrada para el Ave {Nombre} por el motivo: {Motivo}";
            }
            public override string MostrarInformacion()
            {
                return $"Ave: {Nombre}, Especie: {Especie}, Raza: {Raza}, Dueño: {NombreDueno}, Edad: {Edad}, Tamaño: {tamaño}, Peso: {peso}";
            }

        }

        static void menu()
        {            
                int opcion;
                do
                {
                    Console.WriteLine("\n MENU CLINICA VETERINARIA:");
                    Console.WriteLine("1. Registrar nueva mascota");
                    Console.WriteLine("2. Registrar consulta");
                    Console.WriteLine("3. Programar cita de seguimiento");
                    Console.WriteLine("4. mostrar informacion de mascotas");
                    Console.WriteLine("5. Salir");
                    Console.Write("Seleccione una opción: ");

               
                    if (!int.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.WriteLine("ingrese un numero valido");
                    continue;
                }

                switch (opcion)
                    {
                        case 1:
                            RegistrarNuevaMascota();
                            break;
                        case 2:
                            RegistrarConsulta();
                            break;
                        case 3:
                            ProgramarCita();

                            break;
                        case 4:
                            MostrarInformacion();
                            break;
                        case 5:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("ingrese un numero valido");
                            break;
                    }
                } while (opcion != 5);
            }
        static void RegistrarNuevaMascota()
        {
            Console.WriteLine("\n--- Registrar Nueva Mascota ---");
            Console.Write("Tipo de mascota (Perro/Gato/Ave): ");
            string tipo = Console.ReadLine().Trim().ToLower();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine().Trim();

            Console.Write("Raza: ");
            string raza = Console.ReadLine().Trim().ToLower();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine().Trim());

            Console.Write("Nombre del dueño: ");
            string nombreDueño = Console.ReadLine().Trim();

            Console.Write("Peso (kg): ");
            double peso = double.Parse(Console.ReadLine().Trim());

            Console.Write("Tamaño (cm): ");
            double tamaño = double.Parse(Console.ReadLine().Trim());

            Mascota nuevaMascota = null;

            switch (tipo.ToLower())
            {
                case "perro":
                    nuevaMascota = new Perro(nombre, "Canino", raza, nombreDueño, edad, tamaño, peso);
                    break;
                case "gato":
                    nuevaMascota = new Gato(nombre, "Felino", raza, nombreDueño, edad, tamaño, peso);
                    break;
                case "ave":
                    nuevaMascota = new Ave(nombre, "Aviar", raza, nombreDueño, edad, tamaño, peso);
                    break;
                default:
                    Console.WriteLine("Tipo de mascota no reconocido.");
                    return;
            }
            mascotas.Add(nuevaMascota);
            nuevaMascota.AuditarAccion("Registro", $"Mascota {nombre} registrada exitosamente.");
            Console.WriteLine("Mascota registrada exitosamente");
        }

        static void RegistrarConsulta()
        {
            Console.Write("Nombre de la mascota: ");
            string nombre = Console.ReadLine();
            var mascota = mascotas.Find(M => M.Nombre == nombre);
            if (mascota != null)
            {
                Console.Write("Motivo de la consulta: ");
                string motivo = Console.ReadLine();
                mascota.RegistrarConsulta(motivo);
            }
            else
            {
                Console.WriteLine("Mascota no encontrada.");
            }
        }

        static void ProgramarCita()
        {
            Console.Write("Nombre de la mascota: ");
            string nombre = Console.ReadLine();
            var mascota = mascotas.Find(m => m.Nombre == nombre);
            if (mascota != null)
            {
                Console.Write("Descripción de la cita: ");
                string desc = Console.ReadLine();
                mascota.AuditarAccion("Cita", $"Cita programada para {nombre}: {desc}");
            }
            else
            {
                Console.WriteLine("Mascota no encontrada.");
            }
        }

        static void MostrarInformacion()
        {
            foreach (var mascota in mascotas)
            {
                Console.WriteLine(mascota.MostrarInformacion());
            }
        }
    }
}




