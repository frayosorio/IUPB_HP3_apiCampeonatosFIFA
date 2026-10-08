using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.dominio.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace presentacion.Controladores
{
    [Route("api/grupos")]
    [ApiController]
    public class GrupoControlador : Controller
    {
        private readonly IGrupoServicio servicio;

        public GrupoControlador(IGrupoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("posiciones/{IdGrupo:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TablaPosicionDto>))]
        public async Task<ActionResult<IEnumerable<TablaPosicionDto>>> ObtenerPosiciones(int IdGrupo)
        {
            var lista = await servicio.ObtenerPosiciones(IdGrupo);
            return Ok(lista);
        }
    }
}
