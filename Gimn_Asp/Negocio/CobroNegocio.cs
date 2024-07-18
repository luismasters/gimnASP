﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CobroNegocio
    {
        private AccesoDatos DT;
        public CobroNegocio()
        {
            DT = new AccesoDatos();
        }

        public List<Cobro> listarCobros()
        {
            List<Cobro> cobros = new List<Cobro>();
            try
            {
                DT.setearConsulta("select ID,IDPersona,IDEmpleado,IDTipoMembresia,FechaCobro from Cobros");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    Cobro cobro = new Cobro();
                    cobro.ID = Convert.ToInt32(DT.Lector["ID"]);
                    cobro.Empleado.ID= Convert.ToInt32(DT.Lector["IDEmpleado"]);
                    cobro.IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]);
                    cobro.IDTipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]);
                    cobro.FechaCobro = Convert.ToDateTime(DT.Lector["FechaCobro"]);
                    cobros.Add(cobro);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DT.cerrarConexion();
            }
            return cobros;
        }



        public bool AgregarCobro(Cobro cobro)
        {
            try
            {
                // Establecer la consulta para insertar un nuevo cobro
                DT.setearConsulta("INSERT INTO Cobros (IDPersonas, IDTipoMembresia,IDEmpleado, FechaCobro) VALUES (@IDPersona, @IDTipoMembresia,@IDEmpleado, @FechaCobro)");

                // Agregar parámetros a la consulta
                DT.agregarParametro("@IDPersona", cobro.IDPersona);
                DT.agregarParametro("@IDTipoMembresia", cobro.IDTipoMembresia);
                DT.agregarParametro("@IDEmpleado", cobro.Empleado.ID);
                DT.agregarParametro("@FechaCobro", cobro.FechaCobro);

                // Ejecutar la acción de inserción y obtener el resultado
                bool resultado = DT.ejecutarAccion();

                // Registro de depuración
                Console.WriteLine($"AgregarCobro: IDPersona={cobro.IDPersona}, IDTipoMembresia={cobro.IDTipoMembresia}, FechaCobro={cobro.FechaCobro}, Resultado={resultado}");

                return resultado;
            }
            catch (Exception ex)
            {
                // Registro de error
                Console.WriteLine($"Error al agregar el cobro: {ex.Message}");
                throw new Exception("Error al agregar el cobro", ex);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                DT.cerrarConexion();
            }
        }
        public List<ResumenCobro> ObtenerResumenCobros(DateTime fecha)
        {
            List<ResumenCobro> resumenCobros = new List<ResumenCobro>();
            try
            {
                DT.setearConsulta("SELECT E.ID AS IDEmpleado, P.Nombre + ' ' + P.Apellido AS NombreCompleto, SUM(TM.Precio) AS MontoTotal " +
                                  "FROM Cobros C " +
                                  "INNER JOIN Empleados E ON C.IDEmpleado = E.ID " +
                                  "INNER JOIN Personas P ON E.IDPersona = P.ID " +
                                  "INNER JOIN TiposMembresias TM ON C.IDTipoMembresia = TM.ID " +
                                  "WHERE CAST(C.FechaCobro AS DATE) = @Fecha " +
                                  "GROUP BY E.ID, P.Nombre, P.Apellido");
                DT.agregarParametro("@Fecha", fecha);
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    ResumenCobro resumen = new ResumenCobro
                    {
                        IDEmpleado = Convert.ToInt32(DT.Lector["IDEmpleado"]),
                        NombreCompleto = DT.Lector["NombreCompleto"].ToString(),
                        MontoTotal = Convert.ToDecimal(DT.Lector["MontoTotal"])
                    };
                    resumenCobros.Add(resumen);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el resumen de cobros", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return resumenCobros;
        }

        public List<CobroDetalle> ObtenerDetalleCobros(int idEmpleado, DateTime fecha)
        {
            List<CobroDetalle> detalleCobros = new List<CobroDetalle>();
            try
            {
                DT.setearConsulta("SELECT C.ID, C.IDPersonas, C.IDTipoMembresia, C.FechaCobro, TM.Precio " +
                                  "FROM Cobros C " +
                                  "INNER JOIN TiposMembresias TM ON C.IDTipoMembresia = TM.ID " +
                                  "WHERE C.IDEmpleado = @IDEmpleado AND CAST(C.FechaCobro AS DATE) = @Fecha");
                DT.agregarParametro("@IDEmpleado", idEmpleado);
                DT.agregarParametro("@Fecha", fecha);
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    CobroDetalle cobro = new CobroDetalle
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        IDPersona = Convert.ToInt32(DT.Lector["IDPersonas"]),
                        IDTipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]),
                        FechaCobro = Convert.ToDateTime(DT.Lector["FechaCobro"]),
                        Precio = Convert.ToDecimal(DT.Lector["Precio"])
                    };
                    detalleCobros.Add(cobro);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el detalle de cobros", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return detalleCobros;
        }
    }

    public class ResumenCobro
    {
        public int IDEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public decimal MontoTotal { get; set; }
    }

    public class CobroDetalle
    {
        public int ID { get; set; }
        public int IDPersona { get; set; }
        public int IDTipoMembresia { get; set; }
        public DateTime FechaCobro { get; set; }
        public decimal Precio { get; set; }
    }
}