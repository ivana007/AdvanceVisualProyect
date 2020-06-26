using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceVisual.Models
{
    public class Cuota
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public int ClienteId { get; set; }
        public int ClaseId { get; set; }
        public Cliente Cliente{ get; set; }
        public Clase Clase { get; set; }
    }
}
