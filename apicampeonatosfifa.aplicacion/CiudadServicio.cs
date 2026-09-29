using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.aplicacion
{
    public class CiudadServicio : ICiudadServicio
    {
        private readonly ICiudadRepositorio repositorio;

        public CiudadServicio(ICiudadRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Ciudad> Agregar(Ciudad Ciudad)
        {
            return await repositorio.Agregar(Ciudad);
        }

        public async Task<IEnumerable<Ciudad>> Buscar(int IndiceDato, string Texto)
        {
            return await repositorio.Buscar(IndiceDato, Texto);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Ciudad> Modificar(Ciudad Ciudad)
        {
            return await repositorio.Modificar(Ciudad);
        }

        public async Task<Ciudad> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Ciudad>> ObtenerPais(int IdPais)
        {
            return await repositorio.ObtenerPais(IdPais);
        }

        public async Task<IEnumerable<Ciudad>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
