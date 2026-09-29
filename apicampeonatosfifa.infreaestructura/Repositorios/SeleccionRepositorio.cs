using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public class SeleccionRepositorio : ISeleccionRepositorio
    {
        private readonly CampeonatosFIFAContext contexto;

        public SeleccionRepositorio(CampeonatosFIFAContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Seleccion> Agregar(Seleccion Seleccion)
        {
            contexto.Selecciones.Add(Seleccion);
            await contexto.SaveChangesAsync();
            return Seleccion;
        }

        public async Task<IEnumerable<Seleccion>> Buscar(int IndiceDato, string Texto)
        {
            return await contexto.Selecciones
            .Where(seleccion => (IndiceDato == 1 && seleccion.Nombre.Contains(Texto)) ||
            IndiceDato == 2 && seleccion.Entidad.Contains(Texto))
                .OrderBy(seleccion => seleccion.Nombre)
            .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var SeleccionExistente = await contexto.Selecciones.FindAsync(Id);
            if (SeleccionExistente == null)
            {
                return false;
            }
            try
            {
                contexto.Selecciones.Remove(SeleccionExistente);
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Seleccion> Modificar(Seleccion Seleccion)
        {
            var SeleccionExistente = await contexto.Selecciones.FindAsync(Seleccion.Id);
            if (SeleccionExistente == null)
            {
                return null;
            }
            contexto.Entry(SeleccionExistente).CurrentValues.SetValues(Seleccion);
            await contexto.SaveChangesAsync();
            return SeleccionExistente;
        }

        public async Task<Seleccion> Obtener(int Id)
        {
            return await contexto.Selecciones.FindAsync(Id);
        }

        public async Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            return await contexto.Selecciones
                .OrderBy(seleccion => seleccion.Nombre)
                .ToArrayAsync();
        }
    }
}
