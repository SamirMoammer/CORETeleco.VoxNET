using CORETeleco.Models;
using System.Data.SqlClient;

public class ProductoDatos
{
    private readonly string connectionString;

    public ProductoDatos()
    {
        connectionString = "Server=localhost;Database=CORETeleco;User Id=SA;Password=SSrm2823;";
    }

    public List<ProductoModel> Listar()
    {
        List<ProductoModel> productos = new List<ProductoModel>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT p.idProducto, p.nombreProducto, p.descripcionProducto, p.precioProducto, p.disponibilidadProducto, p.idCategoriaProducto, c.categoriaProducto FROM Producto p INNER JOIN Categoria c ON p.idCategoriaProducto = c.idCategoriaProducto", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ProductoModel producto = new ProductoModel
                {
                    idProducto = Convert.ToInt32(reader["idProducto"]),
                    nombreProducto = reader["nombreProducto"].ToString(),
                    descripcionProducto = reader["descripcionProducto"].ToString(),
                    precioProducto = Convert.ToDecimal(reader["precioProducto"]),
                    disponibilidadProducto = Convert.ToInt32(reader["disponibilidadProducto"]),
                    idCategoriaProducto = Convert.ToInt32(reader["idCategoriaProducto"]),
                    Categoria = new CategoriaModel
                    {
                        idCategoriaProducto = Convert.ToInt32(reader["idCategoriaProducto"]),
                        categoriaProducto = reader["categoriaProducto"].ToString()
                    }
                };
                productos.Add(producto);
            }
        }

        return productos;
    }

    public ProductoModel Obtener(int id)
    {
        ProductoModel producto = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT p.idProducto, p.nombreProducto, p.descripcionProducto, p.precioProducto, p.disponibilidadProducto, p.idCategoriaProducto, c.categoriaProducto FROM Producto p INNER JOIN Categoria c ON p.idCategoriaProducto = c.idCategoriaProducto WHERE p.idProducto = @IdProducto", connection);
            cmd.Parameters.AddWithValue("@IdProducto", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                producto = new ProductoModel
                {
                    idProducto = Convert.ToInt32(reader["idProducto"]),
                    nombreProducto = reader["nombreProducto"].ToString(),
                    descripcionProducto = reader["descripcionProducto"].ToString(),
                    precioProducto = Convert.ToDecimal(reader["precioProducto"]),
                    disponibilidadProducto = Convert.ToInt32(reader["disponibilidadProducto"]),
                    idCategoriaProducto = Convert.ToInt32(reader["idCategoriaProducto"]),
                    Categoria = new CategoriaModel
                    {
                        idCategoriaProducto = Convert.ToInt32(reader["idCategoriaProducto"]),
                        categoriaProducto = reader["categoriaProducto"].ToString()
                    }
                };
            }
        }

        return producto;
    }

    public bool Guardar(ProductoModel producto)
    {
        bool respuesta = false;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Producto (nombreProducto, descripcionProducto, precioProducto, disponibilidadProducto, idCategoriaProducto) VALUES (@nombreProducto, @descripcionProducto, @precioProducto, @disponibilidadProducto, @idCategoriaProducto)", connection);
                cmd.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                cmd.Parameters.AddWithValue("@descripcionProducto", producto.descripcionProducto);
                cmd.Parameters.AddWithValue("@precioProducto", producto.precioProducto);
                cmd.Parameters.AddWithValue("@disponibilidadProducto", producto.disponibilidadProducto);
                cmd.Parameters.AddWithValue("@idCategoriaProducto", producto.idCategoriaProducto);
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

    public bool Editar(ProductoModel producto)
    {
        bool respuesta = false;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Producto SET nombreProducto = @nombreProducto, descripcionProducto = @descripcionProducto, precioProducto = @precioProducto, disponibilidadProducto = @disponibilidadProducto, idCategoriaProducto = @idCategoriaProducto WHERE idProducto = @idProducto", connection);
                cmd.Parameters.AddWithValue("@idProducto", producto.idProducto);
                cmd.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                cmd.Parameters.AddWithValue("@descripcionProducto", producto.descripcionProducto);
                cmd.Parameters.AddWithValue("@precioProducto", producto.precioProducto);
                cmd.Parameters.AddWithValue("@disponibilidadProducto", producto.disponibilidadProducto);
                cmd.Parameters.AddWithValue("@idCategoriaProducto", producto.idCategoriaProducto);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM Producto WHERE idProducto = @idProducto", connection);
                cmd.Parameters.AddWithValue("@idProducto", id);
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



    public List<CategoriaModel> ObtenerCategorias()
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
}
