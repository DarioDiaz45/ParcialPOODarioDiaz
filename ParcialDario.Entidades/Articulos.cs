namespace ParcialDario.Entidades
{
    public abstract class Articulos
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        protected Articulos(string codigo, string descripcion, decimal precio, int stock)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }

        protected Articulos(string codigo, string descripcion, decimal precio)
            : this(codigo, descripcion, precio, 10) { }

        public virtual decimal CalcularPrecioConIva()
        {
            return Precio * 1.21m;
        }

        public abstract string MostrarDatos();
    }
}

