using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket.Shared.Entities
{
	[Table("categorias")]
	public class Categoria
	{
		public int Id { get; set; }

		[MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Nombre { get; set; } = null!;
	}
}
