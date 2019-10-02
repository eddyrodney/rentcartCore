using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string TandaLabor { get; set; }
        public float PorcientoComision { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }
}
