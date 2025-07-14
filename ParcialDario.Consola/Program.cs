using ParcialDario.Entidades;
using ParcialDario.Servicios;

namespace ParcialDario.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var servicio = new ServiciosArticulos();
            string opcion;
            do
            {
                Console.WriteLine("--- Menú Librería ---");
                Console.WriteLine("1. Listar todos los artículos");
                Console.WriteLine("2. Buscar artículo por código");
                Console.WriteLine("3. Agregar nuevo artículo");
                Console.WriteLine("4. Eliminar artículo");
                Console.WriteLine("5. Listar por tipo");
                Console.WriteLine("6. Listar con stock bajo");
                Console.WriteLine("7. Salir");
                Console.Write("Opción: ");
                opcion = Console.ReadLine()!;

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            servicio.ObtenerTodos().ForEach(a => Console.WriteLine(a.MostrarDatos()));
                            break;
                        case "2":
                            Console.Write("Código: ");
                            var cod = Console.ReadLine();
                            var art = servicio.BuscarPorCodigo(cod);
                            Console.WriteLine(art != null ? art.MostrarDatos() : "No se encontró.");
                            break;
                        case "3":
                            Console.Write("Tipo (cuaderno/lapicera): ");
                            var tipo = Console.ReadLine()!.ToLower();
                            Console.Write("Código: "); var c = Console.ReadLine();
                            Console.Write("Descripción: "); var d = Console.ReadLine();
                            Console.Write("Precio: "); var p = decimal.Parse(Console.ReadLine()!);
                            Console.Write("Stock: "); var s = int.Parse(Console.ReadLine()!);

                            if (tipo == "cuaderno")
                            {
                                Console.Write("Tamaño: "); var t = Console.ReadLine();
                                Console.Write("Cantidad de hojas: "); var h = int.Parse(Console.ReadLine()!);
                                servicio.AgregarArticulo(new Cuadernos(c, d, p, s, h, t));
                            }
                            else if (tipo == "lapicera")
                            {
                                Console.Write("Color: "); var col = Console.ReadLine();
                                Console.Write("¿Trazo fino? (s/n): "); var tf = Console.ReadLine().ToLower() == "s";
                                servicio.AgregarArticulo(new Lapicera(c, d, p, s, col, tf));
                            }
                            break;
                        case "4":
                            Console.Write("Código a eliminar: ");
                            var codE = Console.ReadLine();
                            servicio.EliminarArticulo(codE);
                            Console.WriteLine("Artículo eliminado.");
                            break;
                        case "5":
                            Console.Write("Tipo (cuaderno/lapicera): ");
                            var tFil = Console.ReadLine();
                            servicio.ListarPorTipo(tFil).ForEach(a => Console.WriteLine(a.MostrarDatos()));
                            break;
                        case "6":
                            Console.Write("Umbral: ");
                            var u = int.Parse(Console.ReadLine());
                            servicio.ListarStockBajo(u).ForEach(a => Console.WriteLine(a.MostrarDatos()));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (opcion != "7");
        }
    }
}
