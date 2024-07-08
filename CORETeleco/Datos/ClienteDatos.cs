using CORETeleco.Models;
using System.Data.SqlClient;
using System.Data;

namespace CORETeleco.Datos
{
    public class ClienteDatos
    {
        public List<ClienteModel> Listar()
        {
            var oLista = new List<ClienteModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarClientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClienteModel()
                        {
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            nombreCliente = dr["nombreCliente"].ToString(),
                            direccionCliente = dr["direccionCliente"].ToString(),
                            telefonoCliente = dr["telefonoCliente"].ToString(),
                            correoCliente = dr["correoCliente"].ToString(),
                            cedulaCliente = dr["cedulaCliente"].ToString(),
                            passwordCliente = dr["passwordCliente"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public ClienteModel Obtener(int idCliente)
        {
            var oCliente = new ClienteModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerCliente", conexion);
                cmd.Parameters.AddWithValue("idCliente", idCliente);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCliente.idCliente = Convert.ToInt32(dr["idCliente"]);
                        oCliente.nombreCliente = dr["nombreCliente"].ToString();
                        oCliente.direccionCliente = dr["direccionCliente"].ToString();
                        oCliente.telefonoCliente = dr["telefonoCliente"].ToString();
                        oCliente.correoCliente = dr["correoCliente"].ToString();
                        oCliente.cedulaCliente = dr["cedulaCliente"].ToString();
                        oCliente.passwordCliente = dr["passwordCliente"].ToString();
                    }
                }
            }

            return oCliente;
        }

        public bool Guardar(ClienteModel oCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarCliente", conexion);
                    cmd.Parameters.AddWithValue("nombreCliente", oCliente.nombreCliente);
                    cmd.Parameters.AddWithValue("direccionCliente", oCliente.direccionCliente);
                    cmd.Parameters.AddWithValue("telefonoCliente", oCliente.telefonoCliente);
                    cmd.Parameters.AddWithValue("correoCliente", oCliente.correoCliente);
                    cmd.Parameters.AddWithValue("cedulaCliente", oCliente.cedulaCliente);
                    cmd.Parameters.AddWithValue("passwordCliente", oCliente.passwordCliente);
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

        public bool Editar(ClienteModel oCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarCliente", conexion);
                    cmd.Parameters.AddWithValue("idCliente", oCliente.idCliente);
                    cmd.Parameters.AddWithValue("nombreCliente", oCliente.nombreCliente);
                    cmd.Parameters.AddWithValue("direccionCliente", oCliente.direccionCliente);
                    cmd.Parameters.AddWithValue("telefonoCliente", oCliente.telefonoCliente);
                    cmd.Parameters.AddWithValue("correoCliente", oCliente.correoCliente);
                    cmd.Parameters.AddWithValue("cedulaCliente", oCliente.cedulaCliente);
                    cmd.Parameters.AddWithValue("passwordCliente", oCliente.passwordCliente);
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

        public bool Eliminar(int idCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarCliente", conexion);
                    cmd.Parameters.AddWithValue("idCliente", idCliente);
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
