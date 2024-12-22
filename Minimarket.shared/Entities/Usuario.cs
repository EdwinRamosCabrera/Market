using Minimarket.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket.Shared.Entities
{
	[Table("usuarios")]
	public class Usuario
	{
		public int Id { get; set; }

		[Display(Name = "DNI")]
		[MaxLength(10, ErrorMessage = "El campo {0} debe tener maximo {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string DNI { get; set; } = null!;

		[MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Nombre { get; set; } = null!;

		[MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Apellido { get; set; } = null!;

		[MaxLength(200, ErrorMessage = "El campo {0} debe tener maximo {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Correo { get; set; } = null!;

		[MaxLength(256, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Password { get; set; } = null!;

		[Display(Name = "Dirección")]
		[MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Direccion { get; set; } = null!;

		[Display(Name = "Teléfono")]
		[MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Telefono { get; set; } = null!;

		[Display(Name = "Foto")]
		public string? URLFoto { get; set; }

		public Rol Rol { get; set; }

		public string Estado { get; set; } = null!;

		public bool SesionActiva { get; set; }
	}
}
