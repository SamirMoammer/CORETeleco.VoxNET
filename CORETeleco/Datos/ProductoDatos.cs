using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class ProductoDatos
    {
        public List<ProductoModel> ListarProductos()
        {
            var listaProductos = new List<ProductoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarProductos", conexion); 
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaProductos.Add(new ProductoModel
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            nombreProducto = dr["nombreProducto"].ToString(),
                            descripcionProducto = dr["descripcionProducto"].ToString(),
                            precioProducto = Convert.ToDecimal(dr["precioProducto"]),
                            disponibilidadProducto = Convert.ToBoolean(dr["disponibilidadProducto"]),
                            IdCategoriaProducto = Convert.ToInt32(dr["idCategoriaProducto"])  
                        });
                    }
                }
            }

            return listaProductos;
        }

        public ProductoModel ObtenerProducto(int IdProducto)
        {
            var producto = new ProductoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerProducto", conexion); 
                cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        producto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        producto.nombreProducto = dr["nombreProducto"].ToString();
                        producto.descripcionProducto = dr["descripcionProducto"].ToString();
                        producto.precioProducto = Convert.ToDecimal(dr["precioProducto"]);
                        producto.disponibilidadProducto = Convert.ToBoolean(dr["disponibilidadProducto"]);
                        producto.IdCategoriaProducto = Convert.ToInt32(dr["idCategoriaProducto"]);
                    }
                }
            }

            return producto;
        }

        public bool InsertarProducto(ProductoModel producto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_InsertarProducto", conexion); 
                    cmd.Parameters.AddWithValue("nombreProducto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("descripcionProducto", producto.descripcionProducto);
                    cmd.Parameters.AddWithValue("precioProducto", producto.precioProducto);
                    cmd.Parameters.AddWithValue("disponibilidadProducto", producto.disponibilidadProducto);
                    cmd.Parameters.AddWithValue("idCategoriaProducto", producto.IdCategoriaProducto);
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

        public bool ActualizarProducto(ProductoModel producto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ActualizarProducto", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", producto.IdProducto);
                    cmd.Parameters.AddWithValue("nombreProducto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("descripcionProducto", producto.descripcionProducto);
                    cmd.Parameters.AddWithValue("precioProducto", producto.precioProducto);
                    cmd.Parameters.AddWithValue("disponibilidadProducto", producto.disponibilidadProducto);
                    cmd.Parameters.AddWithValue("idCategoriaProducto", producto.IdCategoriaProducto);
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

        public bool EliminarProducto(int IdProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
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
