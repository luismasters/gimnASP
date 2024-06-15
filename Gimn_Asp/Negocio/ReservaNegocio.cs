using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ReservaNegocio
    {


        private AccesoDatos DT;

        public ReservaNegocio()
        {
            DT = new AccesoDatos();
        }

        public bool AgregarReserva(Reserva reserva, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("INSERT INTO Reservas(IDClaseSalon, IDSalone, IDMiembro, IDHorarioClase) OUTPUT INSERTED.ID VALUES (@IDClaseSalon, @IDSalone, @IDMiembro, @IDHorarioClase)");
                DT.agregarParametro("@IDClaseSalon", reserva.claseSalon.ID);
                DT.agregarParametro("@IDSalone", reserva.salon.ID);
                DT.agregarParametro("@IDMiembro", reserva.miembro.IDMiembro);
                DT.agregarParametro("@IDHorarioClase", reserva.horarioClase.ID);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar agregar la reserva: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }
    }
}
