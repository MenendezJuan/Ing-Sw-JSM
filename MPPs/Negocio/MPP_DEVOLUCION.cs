using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Inventario;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs.Negocio
{
	public class MPP_DEVOLUCION
	{
		private readonly Conexion oCnx;

		public MPP_DEVOLUCION()
		{
			oCnx = Conexion.Instance;
		}

		public int Insertar(Devolucion devolucion)
		{
			var parametros = new Hashtable
			{
				{"@Origen", (int)devolucion.Origen},
				{"@VentaId", devolucion.VentaId},
				{"@CompraId", devolucion.CompraId},
				{"@ProductoId", devolucion.ProductoId},
				{"@Cantidad", devolucion.Cantidad},
				{"@Motivo", devolucion.Motivo ?? string.Empty},
				{"@AptoParaVenta", devolucion.AptoParaVenta},
				{"@Fecha", devolucion.Fecha},
				{"@UsuarioId", devolucion.UsuarioId}
			};

			return Convert.ToInt32(oCnx.GuardarConRetorno("InsertarDevolucion", parametros));
		}

		public List<Devolucion> Listar()
		{
			DataTable dt = oCnx.Leer("ListarDevoluciones", null);
			var lista = new List<Devolucion>();
			foreach (DataRow row in dt.Rows)
			{
				lista.Add(Map(row));
			}
			return lista;
		}

		private static Devolucion Map(DataRow row)
		{
			return new Devolucion
			{
				Id = Convert.ToInt32(row["Id"]),
				Origen = (OrigenDevolucion)Convert.ToInt32(row["Origen"]),
				VentaId = row["VentaId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["VentaId"]),
				CompraId = row["CompraId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["CompraId"]),
				ProductoId = Convert.ToInt32(row["ProductoId"]),
				Cantidad = Convert.ToDecimal(row["Cantidad"]),
				Motivo = row["Motivo"].ToString(),
				AptoParaVenta = Convert.ToBoolean(row["AptoParaVenta"]),
				Fecha = Convert.ToDateTime(row["Fecha"]),
				UsuarioId = row["UsuarioId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["UsuarioId"]) 
			};
		}
	}
}

