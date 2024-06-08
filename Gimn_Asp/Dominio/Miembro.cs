using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Miembro:Persona
    {
        public int IDMiembro { get; set; }
        public int TipoMembresia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool EstadoActivo { get; set; }





    }
}
