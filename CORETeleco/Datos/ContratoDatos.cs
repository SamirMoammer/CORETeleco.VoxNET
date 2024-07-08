using CORETeleco.Models;
using System.Data.SqlClient;
using System.Data;

namespace CORETeleco.Datos
{
    public class ContratoDatos
    {
        public List<ContratoModel> Listar()
        {
            var oLista = new List<ContratoModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarContratos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContratoModel()
                        {
                            idContrato = Convert.ToInt32(dr["idContrato"]),
                            fechaInicioContrato = Convert.ToDateTime(dr["fechaInicioContrato"]),
                            fechaFinContrato = Convert.ToDateTime(dr["fechaFinContrato"]),
                            descripcionContrato = dr["descripcionContrato"].ToString(),
                            estadoContrato = Convert.ToBoolean(dr["estadoContrato"]),
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            idServicio = Convert.ToInt32(dr["idServicio"])
                        });
                    }
                }
            }

            return oLista;
        }

        public ContratoModel Obtener(int idContrato)
        {
            var oContrato = new ContratoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerContrato", conexion);
                cmd.Parameters.AddWithValue("idContrato", idContrato);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContrato.idContrato = Convert.ToInt32(dr["idContrato"]);
                        oContrato.fechaInicioContrato = Convert.ToDateTime(dr["fechaInicioContrato"]);
                        oContrato.fechaFinContrato = Convert.ToDateTime(dr["fechaFinContrato"]);
                        oContrato.descripcionContrato = dr["descripcionContrato"].ToString();
                        oContrato.estadoContrato = Convert.ToBoolean(dr["estadoContrato"]);
                        oContrato.idCliente = Convert.ToInt32(dr["idCliente"]);
                        oContrato.idServicio = Convert.ToInt32(dr["idServicio"]);
                    }
                }
            }

            return oContrato;
        }

        public bool Guardar(ContratoModel oContrato)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarContrato", conexion);
                    cmd.Parameters.AddWithValue("fechaInicioContrato", oContrato.fechaInicioContrato);
                    cmd.Parameters.AddWithValue("fechaFinContrato", oContrato.fechaFinContrato);
                    cmd.Parameters.AddWithValue("descripcionContrato", oContrato.descripcionContrato);
                    cmd.Parameters.AddWithValue("estadoContrato", oContrato.estadoContrato);
                    cmd.Parameters.AddWithValue("idCliente", oContrato.idCliente);
                    cmd.Parameters.AddWithValue("idServicio", oContrato.idServicio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(ContratoModel oContrato)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarContrato", conexion);
                    cmd.Parameters.AddWithValue("idContrato", oContrato.idContrato);
                    cmd.Parameters.AddWithValue("fechaInicioContrato", oContrato.fechaInicioContrato);
                    cmd.Parameters.AddWithValue("fechaFinContrato", oContrato.fechaFinContrato);
                    cmd.Parameters.AddWithValue("descripcionContrato", oContrato.descripcionContrato);
                    cmd.Parameters.AddWithValue("estadoContrato", oContrato.estadoContrato);
                    cmd.Parameters.AddWithValue("idCliente", oContrato.idCliente);
                    cmd.Parameters.AddWithValue("idServicio", oContrato.idServicio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int idContrato)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarContrato", conexion);
                    cmd.Parameters.AddWithValue("idContrato", idContrato);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
