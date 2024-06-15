using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class HorarioClaseNegocio
    {
        private AccesoDatos DT;

        public HorarioClaseNegocio()
        {
            DT = new AccesoDatos();
        }


        public bool AgregarHorarioClase(HorarioClase horarioClase, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("INSERT INTO HorariosClases(IDClaseSalon, Fecha, HoraInicio, HoraFin) OUTPUT INSERTED.ID VALUES (@IDClaseSalon, @Fecha, @HoraInicio, @HoraFin)");
                DT.agregarParametro("@IDClaseSalon", horarioClase.claseSalon.ID);
                DT.agregarParametro("@Fecha", horarioClase.Fecha);
                DT.agregarParametro("@HoraInicio", horarioClase.HoraInicio);
                DT.agregarParametro("@HoraFin", horarioClase.HoraFin);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar agregar el horario de la clase: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

    }
}
