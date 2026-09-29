using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.core.servicios
{
    public interface ICiudadServicio
    {
        Task<IEnumerable<Ciudad>> ObtenerTodos();

        Task<IEnumerable<Ciudad>> ObtenerPais(int IdPais);

        Task<Ciudad> Obtener(int Id);

        Task<IEnumerable<Ciudad>> Buscar(int IndiceDato, string Texto);

        Task<Ciudad> Agregar(Ciudad Ciudad);

        Task<Ciudad> Modificar(Ciudad Ciudad);

        Task<bool> Eliminar(int Id);
    }
}
