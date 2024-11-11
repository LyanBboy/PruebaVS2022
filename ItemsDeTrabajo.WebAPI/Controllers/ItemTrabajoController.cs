namespace ItemsDeTrabajo.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ItemsDeTrabajo.Servicios.Interfaces;
    using ItemsDeTrabajo.Entidad.Dto;

    [Route("api/[controller]")]
    [ApiController]
    public class ItemTrabajoController : Controller
    {
        private readonly IItemTrabajoServicio _servicio;


        public ItemTrabajoController(IItemTrabajoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ObtenerItemTareas")]
        public async Task<ActionResult> ObtenerItemTareas()
        {
            try
            {
               var datos = await _servicio.ObtenerItemTareas();

                return Ok(datos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CrearItem")]
        public async Task<ActionResult> CrearItem([FromBody] DtoItemTrabajoRegistro item)
        {
            try
            {
                var respuesta = await _servicio.CrearItemAsync(item);

                if (respuesta == -1)
                {
                    return BadRequest("Relevancia solo puede ser alta y baja");
                }
                else if (respuesta == -2)
                {
                    return BadRequest("Fecha entrega no puede ser menor o igual a la actual");
                }

                return Ok("Item de trabajo registrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CrearYDistribuirItem")]
        public async Task<ActionResult> CrearYDistribuirItem([FromBody] DtoItemTrabajoRegistro item)
        {
            try
            {
                var respuesta = await _servicio.CrearYDistribuirItemAsync(item);

                if (respuesta == -1)
                {
                    return BadRequest("Relevancia solo puede ser alta y baja");
                }
                else if (respuesta == -2)
                {
                    return BadRequest("Fecha entrega no puede ser menor o igual a la actual");
                }

                return Ok("Item de trabajo registrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Distribuir")]
        public async Task<ActionResult> Distribuir()
        {
            try
            {
                await _servicio.DistribuirItemsAsync();

                return Ok("Distribución completa");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("FinalizarItem")]
        public async Task<ActionResult> FinalizarItem([FromBody] DtoItemTrabajoTermina item)
        {
            try
            {
                var respuesta = await _servicio.FinalizarItemAsync(item);

                if (respuesta == -1)
                {
                    return BadRequest("Codigo requerido");
                }
                else if (respuesta == -2)
                {
                    return BadRequest("Item de trabajo ya fue finalizado");
                }

                return Ok("Item de trabajo finalizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}