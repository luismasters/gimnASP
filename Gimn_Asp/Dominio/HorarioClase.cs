using System;

namespace Dominio
{
    public class HorarioClase
    {
        public int ID { get; set; }
        public ClaseSalon claseSalon { get; set; }
        public Salon salon { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public Empleado Instructor { get; set; }
        public int CapacidadRestante { get; set; }
        public int IDClaseSalon { get; set; } // Nueva propiedad
        public int IDSalon { get; set; } // Nueva propiedad
    }
}
