using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDario.Entidades
{
    public class Cuadernos : Articulos
    {
        public Cuadernos(string codigo, string descripcion, decimal precio, int stock, int cantHojas, string tamaño)
             : base(codigo, descripcion, precio, stock)
        {
            CantidadHojas = cantHojas;
            Tamaño = tamaño;
        }

        public Cuadernos(string codigo, string descripcion, decimal precio, int cantHojas, string tamaño)
            : base(codigo, descripcion, precio)
        {
            CantidadHojas = cantHojas;
            Tamaño = tamaño;
        }



        public string Tamaño { get; set; }
        public  int  CantidadHojas { get; set; }
        public override decimal CalcularPrecioConIva()
        {
            return base.CalcularPrecioConIva();

        }
        public override string MostrarDatos()
        {
           return $"codigo :{Codigo} Descripcion:{Descripcion} Precio:{Precio} Stock:{Stock} CantidadHojas:{CantidadHojas} Tamaño:{Tamaño} Precio con IVA: {CalcularPrecioConIva()}";


        }

    }
}
