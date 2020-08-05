using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceVisual.Models
{
    public class Clase
    {
        [Key]
        public int ClaseId { get; set; }
        public String Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadClases { get; set; }
        public int Cupo { get; set; }
    }
}
