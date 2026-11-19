using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.dominio;


namespace apicampeonatosfifa.aplicacion
{
    public class CampeonatoServicio : ICampeonatoServicio
    {
        private readonly ICampeonatoRepositorio repositorio;

        public CampeonatoServicio(ICampeonatoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<Campeonato> Agregar(Campeonato Campeonato)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Campeonato>> Buscar(int IndiceDato, string Texto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Campeonato> Modificar(Campeonato Campeonato)
        {
            throw new NotImplementedException();
        }

        public Task<Campeonato> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Campeonato>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
