using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class ServicioDatos
    {
        public List<ServicioModel> ListarServicios()
        {
            var listaServicios = new List<ServicioModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarServicios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaServicios.Add(new ServicioModel
                        {
                            IdServicio = Convert.ToInt32(dr["IdServicio"]),
                            nombreServicio = dr["nombreServicio"].ToString(),
                            descripcionServicio = dr["descripcionServicio"].ToString(),
                            precioServicio = Convert.ToDecimal(dr["precioServicio"])
                        });
                    }
                }
            }

            return listaServicios;
        }

        public ServicioModel ObtenerServicio(int IdServicio)
        {
            var servicio = new ServicioModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerServicio", conexion);
                cmd.Parameters.AddWithValue("IdServicio", IdServicio);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        servicio.IdServicio = Convert.ToInt32(dr["IdServicio"]);
                        servicio.nombreServicio = dr["nombreServicio"].ToString();
                        servicio.descripcionServicio = dr["descripcionServicio"].ToString();
                        servicio.precioServicio = Convert.ToDecimal(dr["precioServicio"]);
                    }
                }
            }

            return servicio;
        }

        public bool InsertarServicio(ServicioModel servicio)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_InsertarServicio", conexion); 
                    cmd.Parameters.AddWithValue("nombreServicio", servicio.nombreServicio);
                    cmd.Parameters.AddWithValue("descripcionServicio", servicio.descripcionServicio);
                    cmd.Parameters.AddWithValue("precioServicio", servicio.precioServicio);
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

        public bool ActualizarServicio(ServicioModel servicio)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ActualizarServicio", conexion); 
                    cmd.Parameters.AddWithValue("IdServicio", servicio.IdServicio);
                    cmd.Parameters.AddWithValue("nombreServicio", servicio.nombreServicio);
                    cmd.Parameters.AddWithValue("descripcionServicio", servicio.descripcionServicio);
                    cmd.Parameters.AddWithValue("precioServicio", servicio.precioServicio);
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

        public bool EliminarServicio(int IdServicio)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetcadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarServicio", conexion); 
                    cmd.Parameters.AddWithValue("IdServicio", IdServicio);
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
