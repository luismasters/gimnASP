using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public  class Usuario
    {

        public int ID { get; set; }
        public int IDPersona { get; set; }
        public int IDRol { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }

    }
}
