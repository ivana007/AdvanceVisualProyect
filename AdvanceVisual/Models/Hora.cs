using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceVisual.Models
{
    public class Hora
    {
        public Hora(int hora, int minuto, int segundo, int nano)
        {
            this.Hour = hora;
            this.Minuto = minuto;
            this.NanoS = nano;
            this.Segundo = segundo;
        }
        public int Hour { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public int NanoS { get; set; }
        
    }
}
