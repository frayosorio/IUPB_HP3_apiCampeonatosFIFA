using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.dominio.Dtos;
using apicampeonatosfifa.infraestructura.Persistencia;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public class GrupoRepositorio : IGrupoRepositorio
    {
        private readonly CampeonatosFIFAContext contexto;

        public GrupoRepositorio(CampeonatosFIFAContext contexto)
        {
            this.contexto = contexto;
        }
        public Task<Grupo> Agregar(Grupo Grupo)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoSeleccion> AgregarSeleccion(GrupoSeleccion GrupoSeleccion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarSeleccion(int IdGrupo, int IdSeleccion)
        {
            throw new NotImplementedException();
        }

        public Task<Grupo> Modificar(Grupo Grupo)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoSeleccion> ModificarSeleccion(GrupoSeleccion GrupoSeleccion)
        {
            throw new NotImplementedException();
        }

        public Task<Grupo> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Grupo>> ObtenerCampeonato(int IdCampeonato)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GrupoSeleccion>> ObtenerGrupo(int IdGrupo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TablaPosicionDto>> ObtenerPosiciones(int Id)
        {
            return await contexto.getTablaPosiciones(Id);
        }
    }
}
