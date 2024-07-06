using CORETeleco.Models;
using System.Data.SqlClient;
using System.Data;

namespace CORETeleco.Datos
{
    public class SucursalDatos
    {
        public List<SucursalModel> Listar()
        {
            var oLista = new List<SucursalModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarSucursales", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new SucursalModel()
                        {
                            idSucursal = Convert.ToInt32(dr["idSucursal"]),
                            nombreSucursal = dr["nombreSucursal"].ToString(),
                            direccionSucursal = dr["direccionSucursal"].ToString(),
                            telefonoSucursal = dr["telefonoSucursal"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public SucursalModel Obtener(int idSucursal)
        {
            var oSucursal = new SucursalModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerSucursal", conexion);
                cmd.Parameters.AddWithValue("idSucursal", idSucursal);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oSucursal.idSucursal = Convert.ToInt32(dr["idSucursal"]);
                        oSucursal.nombreSucursal = dr["nombreSucursal"].ToString();
                        oSucursal.direccionSucursal = dr["direccionSucursal"].ToString();
                        oSucursal.telefonoSucursal = dr["telefonoSucursal"].ToString();
                    }
                }
            }

            return oSucursal;
        }

        public bool Guardar(SucursalModel oSucursal)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarSucursal", conexion);
                    cmd.Parameters.AddWithValue("nombreSucursal", oSucursal.nombreSucursal);
                    cmd.Parameters.AddWithValue("direccionSucursal", oSucursal.direccionSucursal);
                    cmd.Parameters.AddWithValue("telefonoSucursal", oSucursal.telefonoSucursal);
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

        public bool Editar(SucursalModel oSucursal)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarSucursal", conexion);
                    cmd.Parameters.AddWithValue("idSucursal", oSucursal.idSucursal);
                    cmd.Parameters.AddWithValue("nombreSucursal", oSucursal.nombreSucursal);
                    cmd.Parameters.AddWithValue("direccionSucursal", oSucursal.direccionSucursal);
                    cmd.Parameters.AddWithValue("telefonoSucursal", oSucursal.telefonoSucursal);
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

        public bool Eliminar(int idSucursal)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarSucursal", conexion);
                    cmd.Parameters.AddWithValue("idSucursal", idSucursal);
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
