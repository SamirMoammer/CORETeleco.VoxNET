using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class ComprobanteDatos
    {
        public List<ComprobanteModel> Listar()
        {
            var oLista = new List<ComprobanteModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarComprobantes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ComprobanteModel()
                        {
                            idTipoComprobante = Convert.ToInt32(dr["idTipoComprobante"]),
                            tipoComprobante = dr["tipoComprobante"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public ComprobanteModel Obtener(int idTipoComprobante)
        {
            var oComprobante = new ComprobanteModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerComprobante", conexion);
                cmd.Parameters.AddWithValue("idTipoComprobante", idTipoComprobante);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oComprobante.idTipoComprobante = Convert.ToInt32(dr["idTipoComprobante"]);
                        oComprobante.tipoComprobante = dr["tipoComprobante"].ToString();
                    }
                }
            }

            return oComprobante;
        }

        public bool Guardar(ComprobanteModel oComprobante)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarComprobante", conexion);
                    cmd.Parameters.AddWithValue("tipoComprobante", oComprobante.tipoComprobante);
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

        public bool Editar(ComprobanteModel oComprobante)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarComprobante", conexion);
                    cmd.Parameters.AddWithValue("idTipoComprobante", oComprobante.idTipoComprobante);
                    cmd.Parameters.AddWithValue("tipoComprobante", oComprobante.tipoComprobante);
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

        public bool Eliminar(int idTipoComprobante)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarComprobante", conexion);
                    cmd.Parameters.AddWithValue("idTipoComprobante", idTipoComprobante);
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
