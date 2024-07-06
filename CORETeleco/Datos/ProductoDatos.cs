using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class ProductoDatos
    {
        public List<ProductoModel> Listar()
        {
            var oLista = new List<ProductoModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarProductos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ProductoModel()
                        {
                            idProducto = Convert.ToInt32(dr["idProducto"]),
                            nombreProducto = dr["nombreProducto"].ToString(),
                            descripcionProducto = dr["descripcionProducto"].ToString(),
                            precioProducto = Convert.ToDecimal(dr["precioProducto"]),
                            disponibilidadProducto = Convert.ToBoolean(dr["disponibilidadProducto"]),
                            idCategoriaProducto = Convert.ToInt32(dr["idCategoriaProducto"])
                        });
                    }
                }
            }

            return oLista;
        }

        public ProductoModel Obtener(int idProducto)
        {
            var oProducto = new ProductoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerProducto", conexion);
                cmd.Parameters.AddWithValue("idProducto", idProducto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oProducto.idProducto = Convert.ToInt32(dr["idProducto"]);
                        oProducto.nombreProducto = dr["nombreProducto"].ToString();
                        oProducto.descripcionProducto = dr["descripcionProducto"].ToString();
                        oProducto.precioProducto = Convert.ToDecimal(dr["precioProducto"]);
                        oProducto.disponibilidadProducto = Convert.ToBoolean(dr["disponibilidadProducto"]);
                        oProducto.idCategoriaProducto = Convert.ToInt32(dr["idCategoriaProducto"]);
                    }
                }
            }

            return oProducto;
        }

        public bool Guardar(ProductoModel oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarProducto", conexion);
                    cmd.Parameters.AddWithValue("nombreProducto", oProducto.nombreProducto);
                    cmd.Parameters.AddWithValue("descripcionProducto", oProducto.descripcionProducto);
                    cmd.Parameters.AddWithValue("precioProducto", oProducto.precioProducto);
                    cmd.Parameters.AddWithValue("disponibilidadProducto", oProducto.disponibilidadProducto);
                    cmd.Parameters.AddWithValue("idCategoriaProducto", oProducto.idCategoriaProducto);
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

        public bool Editar(ProductoModel oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarProducto", conexion);
                    cmd.Parameters.AddWithValue("idProducto", oProducto.idProducto);
                    cmd.Parameters.AddWithValue("nombreProducto", oProducto.nombreProducto);
                    cmd.Parameters.AddWithValue("descripcionProducto", oProducto.descripcionProducto);
                    cmd.Parameters.AddWithValue("precioProducto", oProducto.precioProducto);
                    cmd.Parameters.AddWithValue("disponibilidadProducto", oProducto.disponibilidadProducto);
                    cmd.Parameters.AddWithValue("idCategoriaProducto", oProducto.idCategoriaProducto);
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

        public bool Eliminar(int idProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", conexion);
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
