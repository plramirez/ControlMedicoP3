using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class Habitaciones
    {
        [Key]
        public int IdHabitacion { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
    }
}