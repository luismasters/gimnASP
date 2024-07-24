using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado : Persona
    {
        public int ID { get; set; }
        public CargoEmpleado cargoEmpleado { get; set; }
        public Rol rol { get; set; }
        public bool EstadoActivo { get; set; }

        public Usuario usuario { get; set; }

        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }
    }
}