using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimarket.Backend.Data;
using Minimarket.Shared.Entities;
using System.Runtime.ConstrainedExecution;

namespace Minimarket.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductosController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<Producto> productos = new List<Producto>();
            productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var producto = await _context.Productos.SingleOrDefaultAsync(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(DbUpdateException ex)
            {               
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException!.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Producto producto)
        {
            if(id != producto.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException!.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            { 
                return NotFound();
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
