using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class CitasMedicas
    {
        [Key]
        public int IdCitas { get; set; }

        public int IdPacientes { get; set; }
        [ForeignKey("IdPacientes")]
        public Pacientes Pacientes { get; set; }

        public int IdMedicos { get; set; }
        [ForeignKey("IdMedicos")]
        public Medicos Medicos { get; set; }

        public string Fecha { get; set; }
        public string Hora { get; set; }
    }
}