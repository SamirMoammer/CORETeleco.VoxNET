using CORETeleco.Models;
using System.Data.SqlClient;
using System.Data;

namespace CORETeleco.Datos
{
    public class ProductoFacturaDatos
    {
        public List<ProductoFacturaModel> Listar(int idFactura)
        {
            var oLista = new List<ProductoFacturaModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarProductosFactura", conexion);
                cmd.Parameters.AddWithValue("idFactura", idFactura);
                cmd.CommandType = CommandType.StoredProcedure;

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

        public void Guardar(int idFactura, int idProducto, int cantidad)
        {
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_GuardarProductoFactura", conexion);
                cmd.Parameters.AddWithValue("idFactura", idFactura);
                cmd.Parameters.AddWithValue("idProducto", idProducto);
                cmd.Parameters.AddWithValue("cantidad", cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idFactura, int idProducto)
        {
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_EliminarProductoFactura", conexion);
                cmd.Parameters.AddWithValue("idFactura", idFactura);
                cmd.Parameters.AddWithValue("idProducto", idProducto);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
