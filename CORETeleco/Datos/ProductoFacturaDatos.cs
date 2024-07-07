using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public bool Guardar(ProductoFacturaModel oProductoFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarProductoFactura", conexion);
                    cmd.Parameters.AddWithValue("idFactura", oProductoFactura.idFactura);
                    cmd.Parameters.AddWithValue("idProducto", oProductoFactura.idProducto);
                    cmd.Parameters.AddWithValue("cantidad", oProductoFactura.cantidad);
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

        public bool Editar(ProductoFacturaModel oProductoFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarProductoFactura", conexion);
                    cmd.Parameters.AddWithValue("idFactura", oProductoFactura.idFactura);
                    cmd.Parameters.AddWithValue("idProducto", oProductoFactura.idProducto);
                    cmd.Parameters.AddWithValue("cantidad", oProductoFactura.cantidad);
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

        public bool Eliminar(int idFactura, int idProducto)
        {
            bool rpta;

            try
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
