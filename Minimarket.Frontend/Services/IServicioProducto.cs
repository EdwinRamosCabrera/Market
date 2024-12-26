using Minimarket.Frontend.Models;
using Minimarket.Shared.Entities;

namespace Minimarket.Frontend.Services
{
    public interface IServicioProducto
    {
        Task<String> ObtenerCodigo(); // Genera un codigo aleatorio autoincrementable
        Task<IEnumerable<Producto>> ObtenerProductosAsync(); 
        Task<ProductoDTO>? BuscarProductoAsync(int id); 
        Task<bool> ActualizarProductoAsync(Producto producto); 
        Task<bool> GuardarProductoAsync(Producto producto);
    }
}
