using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
