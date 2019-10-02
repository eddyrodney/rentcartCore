using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Renta
    {
        public int Id { get; set; }
        public int NoRenta { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public float MontoXDia { get; set; }
        public int CantidadDia { get; set; }
        public string Comentario { get; set; }
        public bool Estado { get; set; }
        public int EmpleadoId { get; set; }
        public int VehiculoId { get; set; }
        public int ClienteId { get; set; }

        public Empleado Empleado { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Cliente Cliente { get; set; }
    }
}
