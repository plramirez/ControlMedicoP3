using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class AltasMedicas
    {
        [Key]
        public int IdAltaMedica { get; set; }
        public string Paciente { get; set; }       
        public int IdIngresos { get; set; }
        [ForeignKey("IdIngresos")]
        public Ingresos Ingresos { get; set; }
        public string Habitacion { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaSalido { get; set; }
        public int PrecioTotal { get; set; }
    }
}