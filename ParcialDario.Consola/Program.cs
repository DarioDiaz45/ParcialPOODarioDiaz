using ParcialDario.Datos;
using ParcialDario.Entidades;
using ParcialDario.Servicios;

namespace ParcialDario.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepositorioArticulos repo = new RepositorioArticulo();
            ServiciosArticulos serviciosArticulos = new(repo);
            string opcion;

            do
            {
                Console.WriteLine("\n--- Menú Librería ---");
                Console.WriteLine("1. Listar artículos");
                Console.WriteLine("2. Buscar por código");
                Console.WriteLine("3. Agregar artículo");
                Console.WriteLine("4. Eliminar artículo");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");
                opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            foreach (var a in ((IServiciosArticulos)serviciosArticulos).ObtenerTodos())
                                Console.WriteLine(a.MostrarDatos());
                            break;
                        case "2":
                            Console.Write("Código: ");
                            var cod = Console.ReadLine();
                            var art = ((IServiciosArticulos)serviciosArticulos).BuscarPorCodigo(cod);
                            Console.WriteLine(art != null ? art.MostrarDatos() : "No se encontró.");
                            break;
                        case "3":
                            Console.Write("Tipo (cuaderno/lapicera): ");
                            var tipo = Console.ReadLine().ToLower();
                            Console.Write("Código: "); var c = Console.ReadLine();
                            Console.Write("Descripción: "); var d = Console.ReadLine();
                            Console.Write("Precio: "); var p = decimal.Parse(Console.ReadLine()!);
                            Console.Write("Stock: "); var s = int.Parse(Console.ReadLine()!);

                            if (tipo == "cuaderno")
                            {
                                Console.Write("Tamaño: "); var t = Console.ReadLine();
                                Console.Write("Cantidad de hojas: "); var h = int.Parse(Console.ReadLine()!);
                                ((IServiciosArticulos)serviciosArticulos).AgregarArticulo(new Cuadernos(c, d, p, s, h, t));
                            }
                            else if (tipo == "lapicera")
                            {
                                Console.Write("Color: "); var col = Console.ReadLine();
                                Console.Write("¿Trazo fino? (s/n): "); var tf = Console.ReadLine()!.ToLower() == "s";
                                ((IServiciosArticulos)serviciosArticulos).AgregarArticulo(new Lapicera(c, d, p, s, col, tf));
                            }
                            break;
                        case "4":
                            Console.Write("Código: ");
                            var codE = Console.ReadLine();
                            ((IServiciosArticulos)serviciosArticulos).EliminarArticulo(codE);
                            Console.WriteLine("Eliminado.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            } while (opcion != "5");
        }
    }
}
