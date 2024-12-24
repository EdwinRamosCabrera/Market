using Microsoft.AspNetCore.Mvc;
using Minimarket.Shared.Entities;
using Newtonsoft.Json;
using System.Text;

namespace Minimarket.Frontend.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoriaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7087/");
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/Categorias");
            if(response.IsSuccessStatusCode) // Se espera una respuesta 200
            {
                var content = await response.Content.ReadAsStringAsync();
                var categorias = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(content);
                return View("Index", categorias);
            }
            return View(new List<Categoria>()); // Si la respuesta no es 200 nos devulve una lista vacia
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(categoria);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/Categorias/", content);

                if(response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "La categoria " + categoria.Nombre + " se ha creado exitosamente";
                    return RedirectToAction("Index", "Categoria");
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["ErrorMessage"] = "No se pudo agregar la categoria " + categoria.Nombre + " porque ya existe una categoria con ese nombre.";
                    return RedirectToAction("Index", "Categoria");
                }
                else
                {
                    TempData["ErrorMessage"] = "Error al crear una nueva categoria!!!";
                    return RedirectToAction("Index", "Categoria");
                }
            }         
            return View(categoria);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Categorias/{id}");
            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Error al obtener la categoria.";
                return RedirectToAction("Index");
            }

            var content = await response.Content.ReadAsStringAsync();
            var categoria = JsonConvert.DeserializeObject<Categoria>(content);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(categoria);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"/api/Categorias/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "La categoria se ha actualizado exitosamente";
                    return RedirectToAction("Index", "Categoria");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["ErrorMessage"] = "No se pudo actualizar el nombre de la categoria a : " + categoria.Nombre + " porque ya existe una categoria con ese nombre";
                    return RedirectToAction("Index", "Categoria");
                }
                else
                {
                    TempData["ErrorMessage"] = "Error al editar la categoria!!!";
                    return RedirectToAction("Index", "Categoria");
                }
            }
            return View(categoria);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Categorias/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Categoria eliminada exitosamente!!!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Error al eliminar la categoria.";
                return RedirectToAction("Index");
            }
        }
    }
}
