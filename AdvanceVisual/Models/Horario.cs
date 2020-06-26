using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceVisual.Models
{
    public class Horario
    {
        [Key]
        public int HorarioId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int ClienteId { get; set; }
        public int ClaseId { get; set; }
        //public Cliente Cliente { get; set; }
        //public Clase Clase { get; set; }
    }
}
