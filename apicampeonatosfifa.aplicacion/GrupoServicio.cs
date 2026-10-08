using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.dominio.Dtos;

namespace apicampeonatosfifa.aplicacion
{
    public  class GrupoServicio:IGrupoServicio
    {
        private readonly IGrupoRepositorio repositorio;

        public GrupoServicio(IGrupoRepositorio repositorio)
        {
            this.repositorio = repositorio;
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

        public Task<bool> EliminarSeleccion(int Id)
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


        //***** Tabla de Posiciones *****

        public async Task<IEnumerable<TablaPosicionDto>> ObtenerPosiciones(int IdGrupo)
        {
            return await repositorio.ObtenerPosiciones(IdGrupo);
        }
    }
}
