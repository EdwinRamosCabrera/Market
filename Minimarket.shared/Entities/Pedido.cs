using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket.Shared.Entities
{
	[Table("pedidos")]
	public class Pedido
	{
		public int Id { get; set; }

		public Usuario? Usuario { get; set; }

		public Producto? Producto { get; set; }

		public int Cantidad { get; set; }

		[DataType(DataType.MultilineText)]
		[MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		public string? Comentario { get; set; }

		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal Total => Producto == null ? 0 : (decimal)Cantidad * Producto.Precio;
	}
}
