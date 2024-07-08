using CORETeleco.Models;
using System.Data.SqlClient;
using System.Data;

namespace CORETeleco.Datos
{
    public class ProductoFacturaDatos
    {
        private string cadenaSQL = "Server=localhost;Database=CORETeleco;User Id=SA;Password=SSrm2823;";

        public List<ProductoFacturaModel> Listar()
        {
            var oLista = new List<ProductoFacturaModel>();

            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarProductosFactura", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar parámetro idFactura si es necesario
                // cmd.Parameters.AddWithValue("@idFactura", valorIdFactura);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ProductoFacturaModel()
                        {
                            idFactura = Convert.ToInt32(dr["idFactura"]),
                            idProducto = Convert.ToInt32(dr["idProducto"]),
                            cantidad = Convert.ToInt32(dr["cantidad"])
                        });
                    }
                }
            }
            return oLista;
        }

        public ProductoFacturaModel Obtener(int idFactura, int idProducto)
        {
            var oProductoFactura = new ProductoFacturaModel();

            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerProductoFactura", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idFactura", idFactura);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oProductoFactura.idFactura = Convert.ToInt32(dr["idFactura"]);
                        oProductoFactura.idProducto = Convert.ToInt32(dr["idProducto"]);
                        oProductoFactura.cantidad = Convert.ToInt32(dr["cantidad"]);
                    }
                }
            }
            return oProductoFactura;
        }

        public bool Guardar(ProductoFacturaModel oProductoFactura)
        {
            bool respuesta;

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarProductoFactura", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idFactura", oProductoFactura.idFactura);
                    cmd.Parameters.AddWithValue("@idProducto", oProductoFactura.idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", oProductoFactura.cantidad);
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public bool Editar(ProductoFacturaModel oProductoFactura)
        {
            bool respuesta;

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarProductoFactura", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idFactura", oProductoFactura.idFactura);
                    cmd.Parameters.AddWithValue("@idProducto", oProductoFactura.idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", oProductoFactura.cantidad);
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar(int idFactura, int idProducto)
        {
            bool respuesta;

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarProductoFactura", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}
