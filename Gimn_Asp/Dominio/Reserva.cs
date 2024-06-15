using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reserva
    {

        public int ID { get; set; }
        public ClaseSalon claseSalon { get; set; }

        public Salon salon { get; set; }

        public Miembro miembro { get; set; }

        public  HorarioClase horarioClase { get; set; }



    }
}
