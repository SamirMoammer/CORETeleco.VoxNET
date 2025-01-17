﻿using CORETeleco.Models;
using System.Data.SqlClient;
using System.Data;

namespace CORETeleco.Datos
{
    public class EmpleadoDatos
    {
        public List<EmpleadoModel> Listar()
        {
            var oLista = new List<EmpleadoModel>();
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
                        oLista.Add(new EmpleadoModel()
                        {
                            idEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                            nombreEmpleado = dr["nombreEmpleado"].ToString(),
                            apellidoEmpleado = dr["apellidoEmpleado"].ToString(),
                            passwordEmpleado = dr["passwordEmpleado"].ToString(),
                            idRol = Convert.ToInt32(dr["idRol"]),
                            nombreRol = dr["nombreRol"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public EmpleadoModel Obtener(int idEmpleado)
        {
            var oEmpleado = new EmpleadoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerEmpleado", conexion);
                cmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEmpleado.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                        oEmpleado.nombreEmpleado = dr["nombreEmpleado"].ToString();
                        oEmpleado.apellidoEmpleado = dr["apellidoEmpleado"].ToString();
                        oEmpleado.passwordEmpleado = dr["passwordEmpleado"].ToString();
                        oEmpleado.idRol = Convert.ToInt32(dr["idRol"]);
                        oEmpleado.nombreRol = dr["nombreRol"].ToString();
                    }
                }
            }

            return oEmpleado;
        }

        public bool Guardar(EmpleadoModel oEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarEmpleado", conexion);
                    cmd.Parameters.AddWithValue("nombreEmpleado", oEmpleado.nombreEmpleado);
                    cmd.Parameters.AddWithValue("apellidoEmpleado", oEmpleado.apellidoEmpleado);
                    cmd.Parameters.AddWithValue("passwordEmpleado", oEmpleado.passwordEmpleado);
                    cmd.Parameters.AddWithValue("idRol", oEmpleado.idRol);
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

        public bool Editar(EmpleadoModel oEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarEmpleado", conexion);
                    cmd.Parameters.AddWithValue("idEmpleado", oEmpleado.idEmpleado);
                    cmd.Parameters.AddWithValue("nombreEmpleado", oEmpleado.nombreEmpleado);
                    cmd.Parameters.AddWithValue("apellidoEmpleado", oEmpleado.apellidoEmpleado);
                    cmd.Parameters.AddWithValue("passwordEmpleado", oEmpleado.passwordEmpleado);
                    cmd.Parameters.AddWithValue("idRol", oEmpleado.idRol);
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

        public bool Eliminar(int idEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarEmpleado", conexion);
                    cmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
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
