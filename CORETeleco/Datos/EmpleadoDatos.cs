using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class EmpleadoDatos
    {
        public List<EmpleadoModel> ListarEmpleados()
        {
            var listaEmpleados = new List<EmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarEmpleados", conexion); 
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaEmpleados.Add(new EmpleadoModel
                        {
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            nombreEmpleado = dr["nombreEmpleado"].ToString(),
                            apellidoEmpleado = dr["apellidoEmpleado"].ToString(),
                            passwordEmpleado = dr["passwordEmpleado"].ToString(),
                            IdRol = Convert.ToInt32(dr["IdRol"])  
                        });
                    }
                }
            }

            return listaEmpleados;
        }

        public EmpleadoModel ObtenerEmpleado(int IdEmpleado)
        {
            var empleado = new EmpleadoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerEmpleado", conexion); 
                cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        empleado.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                        empleado.nombreEmpleado = dr["nombreEmpleado"].ToString();
                        empleado.apellidoEmpleado = dr["apellidoEmpleado"].ToString();
                        empleado.passwordEmpleado = dr["passwordEmpleado"].ToString();
                        empleado.IdRol = Convert.ToInt32(dr["IdRol"]);  
                    }
                }
            }

            return empleado;
        }

        public bool InsertarEmpleado(EmpleadoModel empleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_InsertarEmpleado", conexion); 
                    cmd.Parameters.AddWithValue("nombreEmpleado", empleado.nombreEmpleado);
                    cmd.Parameters.AddWithValue("apellidoEmpleado", empleado.apellidoEmpleado);
                    cmd.Parameters.AddWithValue("passwordEmpleado", empleado.passwordEmpleado);
                    cmd.Parameters.AddWithValue("IdRol", empleado.IdRol);
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

        public bool ActualizarEmpleado(EmpleadoModel empleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ActualizarEmpleado", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", empleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("nombreEmpleado", empleado.nombreEmpleado);
                    cmd.Parameters.AddWithValue("apellidoEmpleado", empleado.apellidoEmpleado);
                    cmd.Parameters.AddWithValue("passwordEmpleado", empleado.passwordEmpleado);
                    cmd.Parameters.AddWithValue("IdRol", empleado.IdRol);
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

        public bool EliminarEmpleado(int IdEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarEmpleado", conexion); 
                    cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);
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
