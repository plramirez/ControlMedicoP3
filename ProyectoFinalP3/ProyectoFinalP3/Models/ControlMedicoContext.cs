using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProyectoFinalP3.Models
{
    public class ControlMedicoContext:DbContext
    {
        public ControlMedicoContext()
                     : base("Cadena1")
                {
                }
                public DbSet<Medicos> Medicos { get; set; }
                public DbSet<Pacientes> Pacientes { get; set; }
                public DbSet<Habitaciones> Habitaciones { get; set; }
                public DbSet<CitasMedicas> CitasMedicas { get; set; }
                public DbSet<Ingresos> Ingresos { get; set; }
                public DbSet<AltasMedicas> AltasMedicas { get; set; }
    }
}