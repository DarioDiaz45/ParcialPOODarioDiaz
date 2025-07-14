using ParcialDario.Entidades;

namespace ParcialDario.Datos
{
    public class RepositorioArticulo : IRepositorioArticulos
    {
        private List<Articulos> _articulos;

        public RepositorioArticulo()
        {
            _articulos = new List<Articulos>
        {
            new Cuadernos("P0004", "Cuaderno Rivadavia tapa dura", 2200m, 40, 48,
                 "A4"),
                 new Cuadernos("P0005", "Cuaderno Gloria tapa blanda", 1800m, 30, 42,
                 "A5"),
                 new Cuadernos("P0006", "Cuaderno escolar económico", 1200m, 50, 24,
                 "17x24 cm"),
                 new Lapicera("P0007", "Lapicera Bic Cristal Azul", 400m, 100, "Azul",
                 true),
                 new Lapicera("P0008", "Lapicera Pilot negra", 650m, 80, "Negro",
                 false),
                 new Lapicera("P0009", "Lapicera gel roja", 550m, 60, "Rojo", true),
                 new Lapicera("P0010", "Lapicera Paper Mate verde", 500m, 70, "Verde",
                 false),
        };
        }

        public Articulos this[string codigo] => _articulos.FirstOrDefault(a => a.Codigo == codigo)!;

        public List<Articulos> ObtenerTodos() => _articulos;

        public void Agregar(Articulos articulo) => _articulos.Add(articulo);

        public Articulos BuscarPorCodigo(string codigo) =>
            _articulos.FirstOrDefault(a => a.Codigo == codigo)!;

        public void Eliminar(string codigo)
        {
            var art = BuscarPorCodigo(codigo);
            if (art != null) _articulos.Remove(art);
        }

        public bool Existe(Articulos articulo) =>
            _articulos.Any(a => a.Descripcion == articulo.Descripcion && a.GetType() == articulo.GetType());
    }
}

