using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimarket.Shared.Enums;

namespace Minimarket.Shared.Entities
{
	[Table("ventas")]
    public class Venta
	{
		public int Id { get; set; }

		public DateTime Fecha { get; set; } = DateTime.Now;

		public Usuario? Usuario { get; set; }

		[DataType(DataType.MultilineText)]
		[MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		public string? Comentario { get; set; }

		public EstadoPedido EstadoPedido { get; set; }

		public ICollection<DetalleVenta>? DetallesVenta { get; set; }

		public int Cantidad => DetallesVenta == null ? 0 : DetallesVenta.Sum(sd => sd.Cantidad);

		[DisplayFormat(DataFormatString = "{0:C2}")]
		[Display(Name = "Total")]
		public decimal Total => DetallesVenta == null ? 0 : DetallesVenta.Sum(sd => sd.Total);
	}
}
