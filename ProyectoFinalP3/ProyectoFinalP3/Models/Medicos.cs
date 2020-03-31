using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class Medicos
    {
        [Key]
        public int IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Exequatur { get; set; }
        public string Especialidad { get; set; }
    }
}