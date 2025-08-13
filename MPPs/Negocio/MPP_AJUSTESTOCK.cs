using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Inventario;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs.Negocio
{
	public class MPP_AJUSTESTOCK
	{
		private readonly Conexion oCnx;

		public MPP_AJUSTESTOCK()
		{
			oCnx = Conexion.Instance;
		}

		public int InsertarSolicitud(AjusteStock ajuste)
		{
			var parametros = new Hashtable
			{
				{"@ProductoId", ajuste.ProductoId},
				{"@Cantidad", ajuste.Cantidad},
				{"@Tipo", (int)ajuste.Tipo},
				{"@Motivo", ajuste.Motivo ?? string.Empty},
				{"@Fecha", ajuste.Fecha},
				{"@UsuarioSolicitanteId", ajuste.UsuarioSolicitanteId},
				{"@Estado", (int)EstadoAjuste.Pendiente}
			};

			return Convert.ToInt32(oCnx.GuardarConRetorno("InsertarAjusteStock", parametros));
		}

		public void Aprobar(int ajusteId, int usuarioAprobadorId)
		{
			var parametros = new Hashtable
			{
				{"@AjusteId", ajusteId},
				{"@UsuarioAprobadorId", usuarioAprobadorId}
			};
			oCnx.Guardar("AprobarAjusteStock", parametros);
		}

		public void Rechazar(int ajusteId, int usuarioAprobadorId, string motivo)
		{
			var parametros = new Hashtable
			{
				{"@AjusteId", ajusteId},
				{"@UsuarioAprobadorId", usuarioAprobadorId},
				{"@Motivo", motivo ?? string.Empty}
			};
			oCnx.Guardar("RechazarAjusteStock", parametros);
		}

		public List<AjusteStock> ListarPendientes()
		{
			DataTable dt = oCnx.Leer("ListarAjustesPendientes", null);
			var lista = new List<AjusteStock>();
			foreach (DataRow row in dt.Rows)
			{
				lista.Add(Map(row));
			}
			return lista;
		}

		private static AjusteStock Map(DataRow row)
		{
			return new AjusteStock
			{
				Id = Convert.ToInt32(row["Id"]),
				ProductoId = Convert.ToInt32(row["ProductoId"]),
				Cantidad = Convert.ToDecimal(row["Cantidad"]),
				Tipo = (TipoAjuste)Convert.ToInt32(row["Tipo"]),
				Motivo = row["Motivo"].ToString(),
				Fecha = Convert.ToDateTime(row["Fecha"]),
				UsuarioSolicitanteId = row["UsuarioSolicitanteId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["UsuarioSolicitanteId"]),
				UsuarioAprobadorId = row["UsuarioAprobadorId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["UsuarioAprobadorId"]),
				Estado = (EstadoAjuste)Convert.ToInt32(row["Estado"]) 
			};
		}
	}
}

