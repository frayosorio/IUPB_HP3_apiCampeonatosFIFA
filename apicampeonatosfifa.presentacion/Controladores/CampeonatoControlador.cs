using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.dominio;
using Microsoft.AspNetCore.Mvc;

namespace presentacion.Controladores
{

    [Route("api/campeonatos")]
    [ApiController]
    public class CampeonatoControlador : ControllerBase
    {

        private readonly ICampeonatoServicio servicio;

        public CampeonatoControlador(ICampeonatoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Campeonato>))]
        public async Task<ActionResult<IEnumerable<Campeonato>>> ObtenerTodos()
        {
            var lista = await servicio.ObtenerTodos();
            return Ok(lista);
        }

    }
}
