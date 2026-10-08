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

        [HttpGet("{IndiceDato:int}/{Texto}")]
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
            try
            {
                var nuevaCiudad = await servicio.Agregar(Ciudad);
                return CreatedAtAction(nameof(Obtener), new { Id = nuevaCiudad.Id }, nuevaCiudad);
            }
            catch(Exception ex)
            {
                return Conflict(new
                {
                    mensaje = ex.Message
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ciudad))]
        public async Task<ActionResult<Ciudad>> Modificar([FromBody] Ciudad Ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var modificado = await servicio.Modificar(Ciudad);
            if (modificado == null)
            {
                return NotFound(new { mensaje = $"No se encontró la selección con ID {Ciudad.Id} para modificar." });
            }

            return Ok(modificado);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Eliminar(int Id)
        {
            var eliminado = await servicio.Eliminar(Id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = $"No se pudo eliminar la Selección con ID {Id}" });
            }

            return NoContent();
        }
    }
}
