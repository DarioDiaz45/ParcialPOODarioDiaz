using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDario.Entidades
{
    public  class Lapicera:Articulos
    {
        public Lapicera(string codigo, string descripcion, decimal precio, int stock, string colorTinta, bool trazoFino)
           : base(codigo, descripcion, precio, stock)
        {
            ColorTinta = colorTinta;
            TrazoFino = trazoFino;
        }

        public Lapicera(string codigo, string descripcion, decimal precio, string colorTinta, bool trazoFino)
            : base(codigo, descripcion, precio)
        {
            ColorTinta = colorTinta;
            TrazoFino = trazoFino;
        }

        public string? ColorTinta  { get; set; }
        public bool TrazoFino{ get; set; }

        public override string MostrarDatos()
        {
            return $"Codigo: {Codigo}, Descripcion: {Descripcion}, Precio: {Precio}, Stock: {Stock}, Trazo Fino: {TrazoFino}, Color Tinta: {ColorTinta}, Precio con IVA: {CalcularPrecioConIva()}";
        }
           
        
    }
}
