using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket.Shared.Entities
{
	[Table("productos")]
	public class Producto
	{
		public int Id { get; set; }

		[DisplayName("Código")]
		[MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string codigo { get; set; } = null!;

		[MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Nombre { get; set; } = null!;

		[DataType(DataType.MultilineText)]
		[MaxLength(500, ErrorMessage = "El campo {0} debe tener maximo {1} carácteres.")]
		public string? Descripcion { get; set; }

		[Column(TypeName = "decimal(10,2")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public decimal Precio { get; set; }

		[DisplayName("Unidades Disponibles")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public int Stock { get; set; }

		[Display(Name = "Imagen")]
		public string? URLImagen { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Estado { get; set; } = null!;

		public Categoria? Categoria { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar una categoria.")]
		public int CategoriaId { get; set; }
	}
}
