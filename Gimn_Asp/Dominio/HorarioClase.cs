using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class HorarioClase
    {

        public int ID { get; set; }
        public ClaseSalon claseSalon { get; set; }
        public DateTime Fecha { get; set; }
        public  TimeSpan HoraInicio { get; set; }
        public TimeSpan  HoraFin { get; set; }
    }
}
