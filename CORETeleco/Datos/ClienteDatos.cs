using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class ClienteDatos
    {
        public List<ClienteModel> ListarClientes()
        {
            var listaClientes = new List<ClienteModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarCliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaClientes.Add(new ClienteModel
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            nombreCliente = dr["nombreCliente"].ToString(),
                            direccionCliente = dr["direccionCliente"].ToString(),
                            telefonoCliente = dr["telefonoCliente"].ToString(),
                            correoCliente = dr["correoCliente"].ToString(),
                            cedulaCliente = dr["cedulaCliente"].ToString(),
                            passwordCliente = dr["passwordCliente"].ToString()
                        });
                    }
                }
            }

            return listaClientes;
        }

        public ClienteModel ObtenerCliente(int IdCliente)
        {
            var cliente = new ClienteModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerCliente", conexion); 
                cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                        cliente.nombreCliente = dr["nombreCliente"].ToString();
                        cliente.direccionCliente = dr["direccionCliente"].ToString();
                        cliente.telefonoCliente = dr["telefonoCliente"].ToString();
                        cliente.correoCliente = dr["correoCliente"].ToString();
                        cliente.cedulaCliente = dr["cedulaCliente"].ToString();
                        cliente.passwordCliente = dr["passwordCliente"].ToString();
                    }
                }
            }

            return cliente;
        }

        public bool InsertarCliente(ClienteModel cliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_InsertarCliente", conexion); 
                    cmd.Parameters.AddWithValue("nombreCliente", cliente.nombreCliente);
                    cmd.Parameters.AddWithValue("direccionCliente", cliente.direccionCliente);
                    cmd.Parameters.AddWithValue("telefonoCliente", cliente.telefonoCliente);
                    cmd.Parameters.AddWithValue("correoCliente", cliente.correoCliente);
                    cmd.Parameters.AddWithValue("cedulaCliente", cliente.cedulaCliente);
                    cmd.Parameters.AddWithValue("passwordCliente", cliente.passwordCliente);
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

        public bool ActualizarCliente(ClienteModel cliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ActualizarCliente", conexion); 
                    cmd.Parameters.AddWithValue("IdCliente", cliente.IdCliente);
                    cmd.Parameters.AddWithValue("nombreCliente", cliente.nombreCliente);
                    cmd.Parameters.AddWithValue("direccionCliente", cliente.direccionCliente);
                    cmd.Parameters.AddWithValue("telefonoCliente", cliente.telefonoCliente);
                    cmd.Parameters.AddWithValue("correoCliente", cliente.correoCliente);
                    cmd.Parameters.AddWithValue("cedulaCliente", cliente.cedulaCliente);
                    cmd.Parameters.AddWithValue("passwordCliente", cliente.passwordCliente);
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

        public bool EliminarCliente(int IdCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarCliente", conexion); 
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
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
