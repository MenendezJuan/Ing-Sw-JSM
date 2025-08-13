using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Inventario;
using MPPs.Negocio;
using System;
using System.Collections.Generic;

namespace BLLs.Negocio
{
	public class BLL_AJUSTESTOCK
	{
		private readonly MPP_AJUSTESTOCK _repo;
		private readonly MPP_PRODUCTO _productoRepo;

		public BLL_AJUSTESTOCK()
		{
			_repo = new MPP_AJUSTESTOCK();
			_productoRepo = new MPP_PRODUCTO();
		}

		public int RegistrarSolicitud(int productoId, decimal cantidad, TipoAjuste tipo, string motivo, int? usuarioSolicitanteId)
		{
			if (productoId <= 0) throw new ArgumentException("Producto inválido", nameof(productoId));
			if (cantidad <= 0) throw new ArgumentException("Cantidad debe ser mayor a cero", nameof(cantidad));
			if (string.IsNullOrWhiteSpace(motivo)) throw new ArgumentException("Motivo es obligatorio", nameof(motivo));

			var ajuste = new AjusteStock
			{
				ProductoId = productoId,
				Cantidad = cantidad,
				Tipo = tipo,
				Motivo = motivo,
				Fecha = DateTime.Now,
				UsuarioSolicitanteId = usuarioSolicitanteId,
				Estado = EstadoAjuste.Pendiente
			};

			return _repo.InsertarSolicitud(ajuste);
		}

		public void Aprobar(int ajusteId, int usuarioAprobadorId)
		{
			if (ajusteId <= 0) throw new ArgumentException("Ajuste inválido", nameof(ajusteId));
			if (usuarioAprobadorId <= 0) throw new ArgumentException("Usuario aprobador inválido", nameof(usuarioAprobadorId));

			_repo.Aprobar(ajusteId, usuarioAprobadorId);
		}

		public void Rechazar(int ajusteId, int usuarioAprobadorId, string motivo)
		{
			if (ajusteId <= 0) throw new ArgumentException("Ajuste inválido", nameof(ajusteId));
			if (usuarioAprobadorId <= 0) throw new ArgumentException("Usuario aprobador inválido", nameof(usuarioAprobadorId));
			if (string.IsNullOrWhiteSpace(motivo)) throw new ArgumentException("Motivo de rechazo es obligatorio", nameof(motivo));

			_repo.Rechazar(ajusteId, usuarioAprobadorId, motivo);
		}

		public List<AjusteStock> ListarPendientes()
		{
			return _repo.ListarPendientes();
		}
	}
}

