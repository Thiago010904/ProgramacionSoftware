using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto28
{
    //BackUp
    public enum EstadoPedido
    {
        Pendiente,
        EnPreparacion,
        Completado
    }

    public interface IAuditable
    {
        void AuditarPedido(string estado, decimal total);
    }

    public abstract class Pedido
    {
        public int NumPedido { get; set; }
        public String Cliente { get; set; }
        public List<(string Plato, decimal Precio)> Platos { get; set; }
        public decimal Total { get; protected set; }


        public Pedido()
        {
            Platos = new List<(string Plato, decimal)>();
        }

        public abstract void AgregarPlato(string plato, decimal precio);
        public abstract void CalcularTotal();
        public abstract void MostrarInformacion();
    }

    public class PedidoRestaurante : Pedido, IAuditable
    {
        public EstadoPedido Estado { get; set; }

        public PedidoRestaurante(int numPedido, string cliente)
        {
            NumPedido = numPedido;
            Cliente = cliente;
            Estado = EstadoPedido.Pendiente;
        }
        public override void AgregarPlato(string plato, decimal precio)
        {
            Platos.Add((plato, precio));
            Console.WriteLine($"Se agrego el plato {plato} con exito, y tiene un precio de {precio}");
        }
        public override void CalcularTotal()
        {
            Total = 0;
            foreach (var plato in Platos)
            {
                Total += plato.Precio;
            }
            Console.WriteLine($"Total calculado: {Total:C}");
        }
        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n Pedido #: {NumPedido}");
            Console.WriteLine($"Cliente: {Cliente}");
            Console.WriteLine("Platos:");
            foreach (var plato in Platos)
            {
                Console.WriteLine($"- {plato.Plato}: {plato.Precio:C}");
            }
            Console.WriteLine($"Total: {Total:C}");
            Console.WriteLine($"Estado: {Estado}");
        }
        public void AuditarPedido(string estado, decimal total)
        {
            Console.WriteLine($"[AUDITORIA] Pedido {NumPedido} - Estado: {estado}, Total: {total:C}");
        }


    }

    class Program
    {
        static void Main()
        {
            List<PedidoRestaurante> pedidos = new List<PedidoRestaurante>();
            int conPedidos = 1;
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n MENÚ DE OPCIONES");
                Console.WriteLine("1. Registrar nuevo pedido");
                Console.WriteLine("2. Agregar platos al pedido");
                Console.WriteLine("3. Calcular total del pedido");
                Console.WriteLine("4. cambiar estado del pedido");
                Console.WriteLine("5. Mostrar información del pedido");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del cliente: ");
                        string cliente = Console.ReadLine();
                        var nuevoPedido = new PedidoRestaurante(conPedidos++, cliente);
                        pedidos.Add(nuevoPedido);
                        Console.WriteLine($"Pedido #{nuevoPedido.NumPedido} registrado para {cliente}.");
                        break;


                    case "2":
                        Console.Write("Ingrese el número del pedido: ");
                        int numPedidoPlato = int.Parse(Console.ReadLine());
                        var pedidoPlato = pedidos.Find(p => p.NumPedido == numPedidoPlato);
                        if (pedidoPlato != null)
                        {
                            Console.Write("Nombre del plato: ");
                            string plato = Console.ReadLine();
                            Console.Write("Precio del plato: ");
                            decimal precio = decimal.Parse(Console.ReadLine());
                            pedidoPlato.AgregarPlato(plato, precio);
                        }
                        else
                        {
                            Console.WriteLine("Pedido no encontrado.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingrese el número del pedido: ");
                        int numPedidoTotal = int.Parse(Console.ReadLine());
                        var pedidoTotal = pedidos.Find(p => p.NumPedido == numPedidoTotal);
                        if (pedidoTotal != null)
                        {
                            pedidoTotal.CalcularTotal();
                        }
                        else
                        {
                            Console.WriteLine("Pedido no encontrado.");
                        }
                        break;

                    case "4":
                        Console.Write("Ingrese el número del pedido: ");
                        int numPedidoEstado = int.Parse(Console.ReadLine());
                        var pedidoEstado = pedidos.Find(p => p.NumPedido == numPedidoEstado);
                        if (pedidoEstado != null)
                        {
                            Console.WriteLine("Seleccione estado: 0 = Pendiente, 1 = EnPreparacion, 2 = Entregado");
                            int estado = int.Parse(Console.ReadLine());
                            pedidoEstado.Estado = (EstadoPedido)estado;
                            pedidoEstado.AuditarPedido(pedidoEstado.Estado.ToString(), pedidoEstado.Total);
                        }
                        else
                        {
                            Console.WriteLine("Pedido no encontrado.");
                        }
                        break;

                    case "5":
                        Console.Write("Ingrese el número del pedido: ");
                        int numPedidoInfo = int.Parse(Console.ReadLine());
                        var pedidoInfo = pedidos.Find(p => p.NumPedido == numPedidoInfo);
                        if (pedidoInfo != null)
                        {
                            pedidoInfo.MostrarInformacion();
                        }
                        else
                        {
                            Console.WriteLine("Pedido no encontrado.");
                        }
                        break;

                    case "6":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            }



        }
    }


}
