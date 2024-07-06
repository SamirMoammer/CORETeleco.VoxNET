using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class ServicioDatos
    {
        public List<ServicioModel> Listar()
        {
            var oLista = new List<ServicioModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarServicios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ServicioModel()
                        {
                            idServicio = Convert.ToInt32(dr["idServicio"]),
                            nombreServicio = dr["nombreServicio"].ToString(),
                            descripcionServicio = dr["descripcionServicio"].ToString(),
                            precioServicio = Convert.ToDecimal(dr["precioServicio"])
                        });
                    }
                }
            }

            return oLista;
        }

        public ServicioModel Obtener(int idServicio)
        {
            var oServicio = new ServicioModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerServicio", conexion);
                cmd.Parameters.AddWithValue("idServicio", idServicio);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oServicio.idServicio = Convert.ToInt32(dr["idServicio"]);
                        oServicio.nombreServicio = dr["nombreServicio"].ToString();
                        oServicio.descripcionServicio = dr["descripcionServicio"].ToString();
                        oServicio.precioServicio = Convert.ToDecimal(dr["precioServicio"]);
                    }
                }
            }

            return oServicio;
        }

        public bool Guardar(ServicioModel oServicio)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarServicio", conexion);
                    cmd.Parameters.AddWithValue("nombreServicio", oServicio.nombreServicio);
                    cmd.Parameters.AddWithValue("descripcionServicio", oServicio.descripcionServicio);
                    cmd.Parameters.AddWithValue("precioServicio", oServicio.precioServicio);
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

        public bool Editar(ServicioModel oServicio)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarServicio", conexion);
                    cmd.Parameters.AddWithValue("idServicio", oServicio.idServicio);
                    cmd.Parameters.AddWithValue("nombreServicio", oServicio.nombreServicio);
                    cmd.Parameters.AddWithValue("descripcionServicio", oServicio.descripcionServicio);
                    cmd.Parameters.AddWithValue("precioServicio", oServicio.precioServicio);
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

        public bool Eliminar(int idServicio)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarServicio", conexion);
                    cmd.Parameters.AddWithValue("idServicio", idServicio);
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
