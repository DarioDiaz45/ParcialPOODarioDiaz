using ParcialDario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDario.Datos
{
    public interface  IRepositorioArticulos
    {
        List<Articulos> ObtenerTodos();
        void Agregar(Articulos articulo);
        Articulos BuscarPorCodigo(string codigo);
        void Eliminar(string codigo);
        bool Existe(Articulos articulo);
        Articulos this[string codigo] { get; }
    }
}
