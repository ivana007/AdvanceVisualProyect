using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceVisual.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Dni { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Clave { get; set; }
    }
}
