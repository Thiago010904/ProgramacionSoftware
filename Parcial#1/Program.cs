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
            private List<string> historialConsultas;
            private List<string> citasSeguimiento;

            public List<string> HistorialConsultas
            {
                get => historialConsultas;
                set => historialConsultas = value;
            }
            public List<string> CitasSeguimiento
            {
                get => citasSeguimiento;
                set => citasSeguimiento = value;
            }
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
            public Mascota(string nombre, string especie, string raza, string nombreDueno, int edad)
            {
                Nombre = nombre;
                Especie = especie;
                Raza = raza;
                NombreDueno = nombreDueno;
                Edad = edad;
                EstadoSalud = EstadoSalud.Saludable; //Estado inicial
                HistorialConsultas = new List<string>();
                CitasSeguimiento = new List<string>();

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
            public Perro(string nombre, string especie, string raza, string nombreDueno, int edad, double peso, double tamaño)
                : base(nombre, especie, raza, nombreDueno, edad)
            {
                this.peso = peso;
                this.tamaño = tamaño;
            }
            //Implementacion de los metodos abstractos
            public override string RegistrarConsulta(string Motivo)
            {
                string consulta = $"Consulta registrada para el perro {Nombre} por el motivo: {Motivo}";
                HistorialConsultas.Add(consulta);
                AuditarAccion("Consulta", consulta);
                return consulta;
            }
            public override string MostrarInformacion()
            {
                return $"PERRO             : \n" +
                            $"Nombre            : {Nombre}\n" +
                            $"Especie           : {Especie}\n" +
                            $"Raza              : {Raza}\n" +
                            $"Dueño             : {NombreDueno}\n" +
                            $"Edad              : {Edad}\n" +
                            $"Tamaño            : {tamaño} cm\n" +
                            $"Peso              : {peso} kg\n" +
                            $"Estado de Salud   : {EstadoSalud}\n";
            }        
        }
        public class Gato : Mascota
        {
            private double peso, tamaño;
            //Constructor
            public Gato(string nombre, string especie, string raza, string nombreDueno, int edad, double peso, double tamaño)
                : base(nombre, especie, raza, nombreDueno, edad)
            {
                this.peso = peso;
                this.tamaño = tamaño;

            }
            //Implementacion de los metodos abstractos
            public override string RegistrarConsulta(string Motivo)
            {
                string consulta = $"Consulta registrada para el gato {Nombre} por el motivo: {Motivo}";
                HistorialConsultas.Add(consulta);
                AuditarAccion("Consulta", consulta);
                return consulta;
            }
            public override string MostrarInformacion()
            {
                return      $"GATO              : \n" +
                            $"Nombre            : {Nombre}\n" +
                            $"Especie           : {Especie}\n" +
                            $"Raza              : {Raza}\n" +
                            $"Dueño             : {NombreDueno}\n" +
                            $"Edad              : {Edad}\n" +
                            $"Tamaño            : {tamaño} cm\n" +
                            $"Peso              : {peso} kg\n" +
                            $"Estado de Salud   : {EstadoSalud}\n";
            }
        }
        public class Ave : Mascota
        {
            private double peso, tamaño;
            public Ave(string nombre, string especie, string raza, string nombreDueno, int edad, double peso, double tamaño)
                : base(nombre, especie, raza, nombreDueno, edad)
            {
                this.peso = peso;
                this.tamaño = tamaño;
            }

            public override string RegistrarConsulta(string Motivo)
            {
                string consulta = $"Consulta registrada para el Ave {Nombre} por el motivo: {Motivo}";
                HistorialConsultas.Add(consulta);
                AuditarAccion("Consulta", consulta);
                return consulta;
            }
            public override string MostrarInformacion()
            {
                return      $"AVE               : \n" +
                            $"Nombre            : {Nombre}\n" +
                            $"Especie           : {Especie}\n" +
                            $"Raza              : {Raza}\n" +
                            $"Dueño             : {NombreDueno}\n" +
                            $"Edad              : {Edad}\n" +
                            $"Tamaño            : {tamaño} cm\n" +
                            $"Peso              : {peso} kg\n" +
                            $"Estado de Salud   : {EstadoSalud}\n";
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
            if (!int.TryParse(Console.ReadLine().Trim(), out int edad) || edad < 0)
            {
                Console.WriteLine("Edad invalida. Debe ser un numero entero no negativo.");
                return;
            }
            Console.Write("Nombre del dueño: ");
            string nombreDueño = Console.ReadLine().Trim();

            Console.Write("Peso (kg): ");
            if (!double.TryParse(Console.ReadLine().Trim(), out double peso))  // ← Línea donde se lee el peso
            {
                Console.WriteLine("Peso no válido");
                return;
            }
            Console.Write("Tamaño (cm): ");
            if (!double.TryParse(Console.ReadLine().Trim(), out double tamaño))  // ← Línea donde se lee el tamaño
            {
                Console.WriteLine("Tamaño no válido");
                return;
            }
            Mascota nuevaMascota = null;

            switch (tipo.ToLower())
            {
                case "perro":
                    nuevaMascota = new Perro(nombre, "Canino", raza, nombreDueño, edad, peso, tamaño);
                    break;
                case "gato":
                    nuevaMascota = new Gato(nombre, "Felino", raza, nombreDueño, edad, peso, tamaño);
                    break;
                case "ave":
                    nuevaMascota = new Ave(nombre, "Ave", raza, nombreDueño, edad, peso, tamaño);
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
                string cita = $"Cita programada para {nombre}: {desc}";
                mascota.CitasSeguimiento.Add(cita);
                mascota.AuditarAccion("Cita", $"Cita programada para {nombre}: {desc}");
            }
            else
            {
                Console.WriteLine("Mascota no encontrada.");
            }
        }

        static void MostrarInformacion()
        {
            if (mascotas.Count == 0)
            {
                Console.WriteLine("No hay mascotas registradas.");
                return;
            }
            foreach (var mascota in mascotas)
            {
                Console.WriteLine(mascota.MostrarInformacion());
            }
        }
    }
}




