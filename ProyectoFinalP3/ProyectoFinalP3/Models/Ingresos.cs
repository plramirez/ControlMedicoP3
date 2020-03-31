using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class Ingresos
    {
        [Key]
        public int IdIngreso { get; set; }
        public int IdPacientes { get; set; }
        [ForeignKey("IdPacientes")]
        public Pacientes Pacientes { get; set; }
        public int IdHabitaciones { get; set; }
        [ForeignKey("IdHabitaciones")]
        public Habitaciones Habitaciones { get; set; }
        public string FechaIngreso { get; set; }
    }
}