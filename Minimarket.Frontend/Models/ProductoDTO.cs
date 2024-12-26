using Microsoft.AspNetCore.Mvc.Rendering;
using Minimarket.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minimarket.Frontend.Models
{
    public class ProductoDTO : Producto
    {
        [NotMapped]
        public IEnumerable<SelectListItem>? Categorias { get; set; }
    }
}
