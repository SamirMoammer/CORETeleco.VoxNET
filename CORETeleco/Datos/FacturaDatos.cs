using CORETeleco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CORETeleco.Datos
{
    public class FacturaDatos
    {
        public List<FacturaModel> Listar()
        {
            var oLista = new List<FacturaModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarFacturas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new FacturaModel()
                        {
                            idFactura = Convert.ToInt32(dr["idFactura"]),
                            fechaFactura = Convert.ToDateTime(dr["fechaFactura"]),
                            metodoPagoFactura = dr["metodoPagoFactura"].ToString(),
                            impuestosFactura = Convert.ToDecimal(dr["impuestosFactura"]),
                            totalFactura = Convert.ToDecimal(dr["totalFactura"]),
                            cantidadFactura = Convert.ToInt32(dr["cantidadFactura"]),
                            idSucursal = Convert.ToInt32(dr["idSucursal"]),
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            idEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                            idTipoComprobante = Convert.ToInt32(dr["idTipoComprobante"])
                        });
                    }
                }
            }

            return oLista;
        }

        public FacturaModel Obtener(int idFactura)
        {
            var oFactura = new FacturaModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerFactura", conexion);
                cmd.Parameters.AddWithValue("idFactura", idFactura);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oFactura.idFactura = Convert.ToInt32(dr["idFactura"]);
                        oFactura.fechaFactura = Convert.ToDateTime(dr["fechaFactura"]);
                        oFactura.metodoPagoFactura = dr["metodoPagoFactura"].ToString();
                        oFactura.impuestosFactura = Convert.ToDecimal(dr["impuestosFactura"]);
                        oFactura.totalFactura = Convert.ToDecimal(dr["totalFactura"]);
                        oFactura.cantidadFactura = Convert.ToInt32(dr["cantidadFactura"]);
                        oFactura.idSucursal = Convert.ToInt32(dr["idSucursal"]);
                        oFactura.idCliente = Convert.ToInt32(dr["idCliente"]);
                        oFactura.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                        oFactura.idTipoComprobante = Convert.ToInt32(dr["idTipoComprobante"]);
                    }
                }
            }

            return oFactura;
        }

        public bool Guardar(FacturaModel oFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarFactura", conexion);
                    cmd.Parameters.AddWithValue("fechaFactura", oFactura.fechaFactura);
                    cmd.Parameters.AddWithValue("metodoPagoFactura", oFactura.metodoPagoFactura);
                    cmd.Parameters.AddWithValue("impuestosFactura", oFactura.impuestosFactura);
                    cmd.Parameters.AddWithValue("totalFactura", oFactura.totalFactura);
                    cmd.Parameters.AddWithValue("cantidadFactura", oFactura.cantidadFactura);
                    cmd.Parameters.AddWithValue("idSucursal", oFactura.idSucursal);
                    cmd.Parameters.AddWithValue("idCliente", oFactura.idCliente);
                    cmd.Parameters.AddWithValue("idEmpleado", oFactura.idEmpleado);
                    cmd.Parameters.AddWithValue("idTipoComprobante", oFactura.idTipoComprobante);
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

        public bool Editar(FacturaModel oFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarFactura", conexion);
                    cmd.Parameters.AddWithValue("idFactura", oFactura.idFactura);
                    cmd.Parameters.AddWithValue("fechaFactura", oFactura.fechaFactura);
                    cmd.Parameters.AddWithValue("metodoPagoFactura", oFactura.metodoPagoFactura);
                    cmd.Parameters.AddWithValue("impuestosFactura", oFactura.impuestosFactura);
                    cmd.Parameters.AddWithValue("totalFactura", oFactura.totalFactura);
                    cmd.Parameters.AddWithValue("cantidadFactura", oFactura.cantidadFactura);
                    cmd.Parameters.AddWithValue("idSucursal", oFactura.idSucursal);
                    cmd.Parameters.AddWithValue("idCliente", oFactura.idCliente);
                    cmd.Parameters.AddWithValue("idEmpleado", oFactura.idEmpleado);
                    cmd.Parameters.AddWithValue("idTipoComprobante", oFactura.idTipoComprobante);
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

        public bool Eliminar(int idFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarFactura", conexion);
                    cmd.Parameters.AddWithValue("idFactura", idFactura);
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
