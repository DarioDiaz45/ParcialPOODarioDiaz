using ParcialDario.Datos;
using ParcialDario.Entidades;
using System.Text;
using static ParcialDario.Datos.RepositorioArticulo;

namespace ParcialDario.Servicios
{
    public class ServiciosArticulos: IServiciosArticulos
    {
        private readonly IRepositorioArticulos _repositorio;

        public Articulos this[string codigo] => throw new NotImplementedException();

        public ServiciosArticulos(IRepositorioArticulos repositorio)
        {
            _repositorio = repositorio;
        }

       

        public List<Articulos> ObtenerTodos() => _repositorio.ObtenerTodos();

        public void AgregarArticulo(Articulos articulo)
        {
            if (_repositorio.Existe(articulo))
                throw new Exception("Ya existe un artículo con esa descripción y tipo.");

            _repositorio.Agregar(articulo);
        }

        public void EliminarArticulo(string codigo)
        {
            if (!_repositorio.ObtenerTodos().Any(a => a.Codigo == codigo))
                throw new Exception("No se encontró el artículo.");
            _repositorio.Eliminar(codigo);
        }

        public List<Articulos> ListarPorTipo(string tipoArticulo) =>
            _repositorio.ObtenerTodos().Where(a => a.GetType().Name.ToLower() == tipoArticulo.ToLower()).ToList();

        public List<Articulos> ListarStockBajo(int umbral) =>
            _repositorio.ObtenerTodos().Where(a => a.Stock <= umbral).ToList();

        public bool ExisteArticulo(string codigo) =>
            _repositorio.BuscarPorCodigo(codigo) != null;

        public Articulos BuscarPorCodigo(string codigo) =>
            _repositorio.BuscarPorCodigo(codigo);

       
    }
}
