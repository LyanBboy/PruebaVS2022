namespace ItemsDeTrabajo.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ItemsDeTrabajo.Servicios.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServicio _servicio;

        public UsuarioController(IUsuarioServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ObtenerUsuarios")]
        public ActionResult ObtenerUsuarios()
        {
            try
            {
                var datos = _servicio.ObtenerUsuarios();

                return Ok(datos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerItemsTrabajo")]
        public async Task<ActionResult> ObtenerItemsTrabajo()
        {
            try
            {
                var datos = await _servicio.ObtenerItemsTrabajo();

                return Ok(datos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
