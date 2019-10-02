using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Inspeccion
    {
        public int Id { get; set; }
        public bool Ralladuras { get; set; }
        public string CantidadCombustible { get; set; }
        public bool GomaRepuesta { get; set; }
        public bool Gato { get; set; }
        public bool RoturaCristal { get; set; }
        public bool GomaSupDerecha { get; set; }
        public bool GomaSupIzquierda { get; set; }
        public bool GomaTraseraDerecha { get; set; }
        public bool GomaTraseraIzquierda { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }

        public int IdRenta { get; set; }
        public Renta Renta { get; set; }
    }
}
