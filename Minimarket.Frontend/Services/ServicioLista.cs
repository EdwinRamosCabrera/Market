using Microsoft.AspNetCore.Mvc.Rendering;
using Minimarket.Shared.Entities;
using Newtonsoft.Json;

namespace Minimarket.Frontend.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly HttpClient _httpClient;

        public ServicioLista(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7087/");
        }
        public async Task<IEnumerable<SelectListItem>> GetListaCategorias()
        {
            var response = await _httpClient.GetAsync("/api/Categorias");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categorias = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(content);
                var lista = categorias!.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nombre
                }).ToList();

                lista.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = "Seleccione la categoria"
                });
                return lista;
            }

            return [];
        }
    }
}
