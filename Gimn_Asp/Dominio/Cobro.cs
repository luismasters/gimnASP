using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cobro
    {
        public int ID { get; set; }
        public int IDPersona { get; set; }

        public int IDTipoMembresia { get; set; }

        public DateTime FechaCobro { get; set; }

        public Empleado Empleado { get; set; }

    }
}
