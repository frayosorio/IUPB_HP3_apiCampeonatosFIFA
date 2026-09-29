using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.aplicacion
{
    public class SeleccionServicio : ISeleccionServicio
    {
        private readonly ISeleccionRepositorio repositorio;

        public SeleccionServicio(ISeleccionRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Seleccion> Agregar(Seleccion Seleccion)
        {
            return await repositorio.Agregar(Seleccion);
        }

        public async Task<IEnumerable<Seleccion>> Buscar(int IndiceDato, string Texto)
        {
            return await repositorio.Buscar(IndiceDato, Texto);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Seleccion> Modificar(Seleccion Seleccion)
        {
            return await repositorio.Modificar(Seleccion);
        }

        public async Task<Seleccion> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
