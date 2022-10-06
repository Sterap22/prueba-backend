using Microsoft.AspNetCore.Mvc;
using Tareas.Models;
using Tareas.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerServices _seller;

        public SellerController(ISellerServices seller)
        {
            _seller = seller;
        }

        [HttpGet("TraerClientes")]
        public async Task<IActionResult> Get()
        {
            var respuesta = _seller.Get();
            return Ok(respuesta);
        }
        [HttpPost("CrearCliente")]
        public async Task<IActionResult> PostCliente([FromBody] Seller value)
        {
            var respuesta = _seller.Save(value);
            return Ok(respuesta.Result);
        }
        [HttpPut("ActualizarCliente")]
        public async Task<IActionResult> Put([FromBody] Seller value)
        {
            var respuesta = _seller.Update(value);
            return Ok(respuesta.Result);
        }
        [HttpDelete("EliminarCliente/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var respuesta = _seller.Delete(id);
            return Ok(respuesta.Result);
        }
    }
}
