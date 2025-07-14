using ParcialDario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDario.Servicios
{
    public interface IServiciosArticulos
    {
        List<Articulos> ObtenerTodos();
        void AgregarArticulo(Articulos articulo);
        void EliminarArticulo(string codigo);
        List<Articulos> ListarPorTipo(string tipoArticulo);
        List<Articulos> ListarStockBajo(int umbral);
        bool ExisteArticulo(string codigo);
        Articulos BuscarPorCodigo(string codigo);
     
    }
}
