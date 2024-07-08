using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class CategoriaDatos
    {
        private readonly string connectionString;

        public CategoriaDatos()
        {
            connectionString = "Server=localhost;Database=CORETeleco;User Id=SA;Password=SSrm2823;";
        }

        public List<CategoriaModel> Listar()
        {
            List<CategoriaModel> categorias = new List<CategoriaModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT idCategoriaProducto, categoriaProducto FROM Categoria", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategoriaModel categoria = new CategoriaModel
                    {
                        idCategoriaProducto = Convert.ToInt32(reader["idCategoriaProducto"]),
                        categoriaProducto = reader["categoriaProducto"].ToString()
                    };
                    categorias.Add(categoria);
                }
            }

            return categorias;
        }

        public CategoriaModel Obtener(int id)
        {
            CategoriaModel categoria = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT idCategoriaProducto, categoriaProducto FROM Categoria WHERE idCategoriaProducto = @IdCategoria", connection);
                cmd.Parameters.AddWithValue("@IdCategoria", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    categoria = new CategoriaModel
                    {
                        idCategoriaProducto = Convert.ToInt32(reader["idCategoriaProducto"]),
                        categoriaProducto = reader["categoriaProducto"].ToString()
                    };
                }
            }

            return categoria;
        }

        public bool Guardar(CategoriaModel categoria)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Categoria (categoriaProducto) VALUES (@NombreCategoria)", connection);
                    cmd.Parameters.AddWithValue("@NombreCategoria", categoria.categoriaProducto);
                    int rows = cmd.ExecuteNonQuery();
                    respuesta = rows > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar el error según tu lógica de aplicación
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }

        public bool Editar(CategoriaModel categoria)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Categoria SET categoriaProducto = @NombreCategoria WHERE idCategoriaProducto = @IdCategoria", connection);
                    cmd.Parameters.AddWithValue("@IdCategoria", categoria.idCategoriaProducto);
                    cmd.Parameters.AddWithValue("@NombreCategoria", categoria.categoriaProducto);
                    int rows = cmd.ExecuteNonQuery();
                    respuesta = rows > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar el error según tu lógica de aplicación
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Producto WHERE idProducto = @IdProducto", connection);
                    cmd.Parameters.AddWithValue("@IdProducto", id);
                    int rows = cmd.ExecuteNonQuery();
                    respuesta = rows > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar el error según tu lógica de aplicación
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }
    }
}
