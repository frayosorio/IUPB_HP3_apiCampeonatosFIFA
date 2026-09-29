using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.dominio;
using Microsoft.AspNetCore.Mvc;

namespace presentacion.Controladores
{
    [Route("api/ciudades")]
    [ApiController]
    public class CiudadControlador : Controller
    {
        private readonly ICiudadServicio servicio;

        public CiudadControlador(ICiudadServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Ciudad>))]
        public async Task<ActionResult<IEnumerable<Ciudad>>> ObtenerTodos()
        {
            var lista = await servicio.ObtenerTodos();
            return Ok(lista);
        }

        [HttpGet("pais/{IdPais:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Ciudad>))]
        public async Task<ActionResult<IEnumerable<Ciudad>>> ObtenerPais(int IdPais)
        {
            var lista = await servicio.ObtenerPais(IdPais);
            return Ok(lista);
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ciudad))]
        public async Task<ActionResult<Ciudad>> Obtener(int Id)
        {
            var Ciudad = await servicio.Obtener(Id);
            if (Ciudad != null)
            {
                return NotFound(new { mensaje = $"No se encontró la Selección con ID= {Id}" });
            }
            return Ok(Ciudad);
        }

        [HttpGet("/{IndiceDato:int}/{Texto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Ciudad>))]
        public async Task<ActionResult<IEnumerable<Ciudad>>> Buscar(int IndiceDato, string Texto)
        {
            var lista = await servicio.Buscar(IndiceDato, Texto);
            return Ok(lista);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ciudad))]
        public async Task<ActionResult<Ciudad>> Agregar([FromBody] Ciudad Ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nuevaCiudad = await servicio.Agregar(Ciudad);
            return CreatedAtAction(nameof(Obtener), nuevaCiudad);
        }



    }
}
