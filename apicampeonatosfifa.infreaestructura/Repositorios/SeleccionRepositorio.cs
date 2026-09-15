using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public class SeleccionRepositorio : ISeleccionRepositorio
    {
        public Task<Seleccion> Agregar(Seleccion Seleccion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seleccion>> Buscar(int IndiceDato, string Texto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Seleccion> Modificar(Seleccion Seleccion)
        {
            throw new NotImplementedException();
        }

        public Task<Seleccion> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
