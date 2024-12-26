using Minimarket.Frontend.Models;
using Minimarket.Shared.Entities;
using Newtonsoft.Json;
using System.Text;

namespace Minimarket.Frontend.Services
{
    public class ServicioProducto : IServicioProducto
    {
        private readonly HttpClient _httpClient;

        public ServicioProducto(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7087/");
        }

        public async Task<bool> ActualizarProductoAsync(Producto producto)
        {
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Productos/{producto.Id}", content);
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<ProductoDTO>? BuscarProductoAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Productos/{id}");
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var producto = JsonConvert.DeserializeObject<ProductoDTO>(content);
                    return producto;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Json parsin error: {ex.Message}");
            }
            return null;
        }

        public async Task<bool> GuardarProductoAsync(Producto producto)
        {
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Productos/", content);
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<string> ObtenerCodigo()
        {
            var response = await _httpClient.GetAsync("/api/Productos");
            var content = await response.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<IEnumerable<Producto>>(content);
            var lastCodigo = productos!.OrderByDescending(x => x.Id).Select(p => p.Codigo).FirstOrDefault();
            int lastNumber = 0;
            if (!string.IsNullOrEmpty(lastCodigo) && lastCodigo.Length > 2)
            {
                int.TryParse(lastCodigo.Substring(2), out lastNumber);
            }
            var codigo = $"P-{(lastNumber + 1).ToString("D5")}"; // El formato D5 nos agrega ceros
            return codigo;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
        {
            var response = await _httpClient.GetAsync("/api/Productos");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Producto>>(content)!;
            }
            return [];
        }
    }
}
    
       

