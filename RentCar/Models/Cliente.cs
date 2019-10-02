using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string NoTarjetaCredito { get; set; }
        public float LimiteCredito { get; set; }
        public string TipoPersona { get; set; }
        public bool Estado { get; set; }
    }
}
