using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace presentacion.Controladores
{
    [Route("api/selecciones")]
    [ApiController]
    public class SeleccionControlador : ControllerBase
    {

        private readonly ISeleccionServicio servicio;

        public SeleccionControlador(ISeleccionServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Seleccion>))]
        public async Task<ActionResult<IEnumerable<Seleccion>>> ObtenerTodos()
        {
            var lista = await servicio.ObtenerTodos();
            return Ok(lista);
        }


        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Seleccion))]
        public async Task<ActionResult<Seleccion>> Obtener(int Id)
        {
            var seleccion = await servicio.Obtener(Id);
            if (seleccion != null)
            {
                return NotFound(new { mensaje = $"No se encontró la Selección con ID= {Id}" });
            }
            return Ok(seleccion);
        }

        [HttpGet("{IndiceDato:int}/{Texto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Seleccion>))]
        public async Task<ActionResult<IEnumerable<Seleccion>>> Buscar(int IndiceDato, string Texto)
        {
            var lista = await servicio.Buscar(IndiceDato, Texto);
            return Ok(lista);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Seleccion))]
        public async Task<ActionResult<Seleccion>> Agregar([FromBody] Seleccion Seleccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nuevaSeleccion = await servicio.Agregar(Seleccion);
            return CreatedAtAction(nameof(Obtener), new { Id = nuevaSeleccion.Id }, nuevaSeleccion);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Seleccion))]
        public async Task<ActionResult<Seleccion>> Modificar([FromBody] Seleccion Seleccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var modificado = await servicio.Modificar(Seleccion);
            if (modificado == null)
            {
                return NotFound(new { mensaje = $"No se encontró la selección con ID {Seleccion.Id} para modificar." });
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
