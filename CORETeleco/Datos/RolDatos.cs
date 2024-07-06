using CORETeleco.Models;
using System.Data.SqlClient;
using System.Data;

namespace CORETeleco.Datos
{
    public class RolDatos
    {
        public List<RolModel> Listar()
        {
            var oLista = new List<RolModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarRoles", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new RolModel()
                        {
                            idRol = Convert.ToInt32(dr["idRol"]),
                            nombreRol = dr["nombreRol"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public RolModel Obtener(int idRol)
        {
            var oRol = new RolModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerRol", conexion);
                cmd.Parameters.AddWithValue("idRol", idRol);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oRol.idRol = Convert.ToInt32(dr["idRol"]);
                        oRol.nombreRol = dr["nombreRol"].ToString();
                    }
                }
            }

            return oRol;
        }

        public bool Guardar(RolModel oRol)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarRol", conexion);
                    cmd.Parameters.AddWithValue("nombreRol", oRol.nombreRol);
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

        public bool Editar(RolModel oRol)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarRol", conexion);
                    cmd.Parameters.AddWithValue("idRol", oRol.idRol);
                    cmd.Parameters.AddWithValue("nombreRol", oRol.nombreRol);
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

        public bool Eliminar(int idRol)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarRol", conexion);
                    cmd.Parameters.AddWithValue("idRol", idRol);
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
