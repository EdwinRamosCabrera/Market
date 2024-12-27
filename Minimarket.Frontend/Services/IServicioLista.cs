using Microsoft.AspNetCore.Mvc.Rendering;
using Minimarket.Shared.Entities;

namespace Minimarket.Frontend.Services
{
    public interface IServicioLista
    {
        Task<IEnumerable<SelectListItem>> GetListaCategorias();
    }
}
