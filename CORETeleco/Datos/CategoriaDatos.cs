using CORETeleco.Models;
using System.Data.SqlClient;
using System.Data;

namespace CORETeleco.Datos
{
    public class CategoriaDatos
    {
        public List<CategoriaModel> Listar()
        {
            var oLista = new List<CategoriaModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarCategorias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new CategoriaModel()
                        {
                            idCategoriaProducto = Convert.ToInt32(dr["idCategoriaProducto"]),
                            categoriaProducto = dr["categoriaProducto"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public CategoriaModel Obtener(int idCategoriaProducto)
        {
            var oCategoria = new CategoriaModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerCategoria", conexion);
                cmd.Parameters.AddWithValue("idCategoriaProducto", idCategoriaProducto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCategoria.idCategoriaProducto = Convert.ToInt32(dr["idCategoriaProducto"]);
                        oCategoria.categoriaProducto = dr["categoriaProducto"].ToString();
                    }
                }
            }

            return oCategoria;
        }

        public bool Guardar(CategoriaModel oCategoria)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarCategoria", conexion);
                    cmd.Parameters.AddWithValue("categoriaProducto", oCategoria.categoriaProducto);
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

        public bool Editar(CategoriaModel oCategoria)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarCategoria", conexion);
                    cmd.Parameters.AddWithValue("idCategoriaProducto", oCategoria.idCategoriaProducto);
                    cmd.Parameters.AddWithValue("categoriaProducto", oCategoria.categoriaProducto);
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

        public bool Eliminar(int idCategoriaProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarCategoria", conexion);
                    cmd.Parameters.AddWithValue("idCategoriaProducto", idCategoriaProducto);
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
