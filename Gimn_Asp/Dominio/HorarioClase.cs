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
        public string HoraInicio { get; set; }  // Cambiado a string
        public string HoraFin { get; set; }     // Cambiado a string
        public  Salon salon { get; set; }

    }
}
