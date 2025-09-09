using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        public abstract class Mascota
        {
            private string nombre, especie, raza, nombreDueno;
            private int edad;

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

            //Constructor
            public Mascota(string nombre, string especie, string raza, string nombreDueno, int edad)
            {
                Nombre = nombre;
                Especie = especie;
                Raza = raza;
                NombreDueno = nombreDueno;
                Edad = edad;
            }
            //Metodo abstracto
            public abstract String RegistrarConsulta(string Motivo);
            public abstract String MostrarInformacion();
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
    }
}
