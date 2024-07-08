using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class ClienteDatos
    {
        private string connectionString = "Server=localhost;Database=CORETeleco;User Id=SA;Password=SSrm2823;";

        public List<ClienteModel> Listar()
        {
            var listaClientes = new List<ClienteModel>();

            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente", conexion);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var cliente = new ClienteModel
                        {
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            nombreCliente = dr["nombreCliente"].ToString(),
                            direccionCliente = dr["direccionCliente"].ToString(),
                            telefonoCliente = dr["telefonoCliente"].ToString(),
                            correoCliente = dr["correoCliente"].ToString(),
                            cedulaCliente = dr["cedulaCliente"].ToString(),
                            passwordCliente = dr["passwordCliente"].ToString()
                        };
                        listaClientes.Add(cliente);
                    }
                }
            }

            return listaClientes;
        }

        public ClienteModel Obtener(int idCliente)
        {
            ClienteModel cliente = null;

            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente WHERE idCliente = @IdCliente", conexion);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        cliente = new ClienteModel
                        {
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            nombreCliente = dr["nombreCliente"].ToString(),
                            direccionCliente = dr["direccionCliente"].ToString(),
                            telefonoCliente = dr["telefonoCliente"].ToString(),
                            correoCliente = dr["correoCliente"].ToString(),
                            cedulaCliente = dr["cedulaCliente"].ToString(),
                            passwordCliente = dr["passwordCliente"].ToString()
                        };
                    }
                }
            }

            return cliente;
        }

        public bool Guardar(ClienteModel cliente)
        {
            bool resultado = false;

            try
            {
                using (var conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Cliente (nombreCliente, direccionCliente, telefonoCliente, correoCliente, cedulaCliente, passwordCliente) " +
                                                    "VALUES (@NombreCliente, @DireccionCliente, @TelefonoCliente, @CorreoCliente, @CedulaCliente, @PasswordCliente)", conexion);
                    cmd.Parameters.AddWithValue("@NombreCliente", cliente.nombreCliente);
                    cmd.Parameters.AddWithValue("@DireccionCliente", cliente.direccionCliente);
                    cmd.Parameters.AddWithValue("@TelefonoCliente", cliente.telefonoCliente);
                    cmd.Parameters.AddWithValue("@CorreoCliente", cliente.correoCliente);
                    cmd.Parameters.AddWithValue("@CedulaCliente", cliente.cedulaCliente);
                    cmd.Parameters.AddWithValue("@PasswordCliente", cliente.passwordCliente);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }

        public bool Editar(ClienteModel cliente)
        {
            bool resultado = false;

            try
            {
                using (var conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Cliente SET nombreCliente = @NombreCliente, direccionCliente = @DireccionCliente, " +
                                                    "telefonoCliente = @TelefonoCliente, correoCliente = @CorreoCliente, cedulaCliente = @CedulaCliente, " +
                                                    "passwordCliente = @PasswordCliente WHERE idCliente = @IdCliente", conexion);
                    cmd.Parameters.AddWithValue("@NombreCliente", cliente.nombreCliente);
                    cmd.Parameters.AddWithValue("@DireccionCliente", cliente.direccionCliente);
                    cmd.Parameters.AddWithValue("@TelefonoCliente", cliente.telefonoCliente);
                    cmd.Parameters.AddWithValue("@CorreoCliente", cliente.correoCliente);
                    cmd.Parameters.AddWithValue("@CedulaCliente", cliente.cedulaCliente);
                    cmd.Parameters.AddWithValue("@PasswordCliente", cliente.passwordCliente);
                    cmd.Parameters.AddWithValue("@IdCliente", cliente.idCliente);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }

        public bool Eliminar(int idCliente)
        {
            bool resultado = false;

            try
            {
                using (var conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Cliente WHERE idCliente = @IdCliente", conexion);
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }
    }
}
