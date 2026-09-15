using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public class CampeonatoRepositorio : ICampeonatoRepositorio
    {
        private CampeonatosFIFAContext contexto;

        public Task<Campeonato> Agregar(Campeonato Campeonato)
        {
            throw new NotImplementedException();
        }

        public Task<CampeonatoPais> AgregarPais(CampeonatoPais CampeonatoPais)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Campeonato>> Buscar(int IndiceDato, string Texto)
        {
            if(IndiceDato<=2)
            return await contexto.Campeonatos
                .Where(campeonato => (IndiceDato == 1 && campeonato.Nombre.Contains(Texto)
                || (IndiceDato == 2 && campeonato.Año == int.Parse(Texto))))
                .ToArrayAsync();
        else
                return await contexto.CampeonatosPaises
                .Where(campeonatopais => IndiceDato == 3 && campeonatopais.Pais.Nombre.Contains(Texto))
                .Select(campeonatopais => campeonatopais.Campeonato)
                .ToArrayAsync();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarPais(int IdCampeonato, int IdPais)
        {
            throw new NotImplementedException();
        }

        public Task<Campeonato> Modificar(Campeonato Campeonato)
        {
            throw new NotImplementedException();
        }

        public Task<CampeonatoPais> ModificarPais(CampeonatoPais CampeonatoPais)
        {
            throw new NotImplementedException();
        }

        public async Task<Campeonato> Obtener(int Id)
        {
            return await contexto.Campeonatos.FindAsync(Id);
        }

        public Task<IEnumerable<CampeonatoPais>> ObtenerCampeonato(int IdCampeonato)
        {
            throw new NotImplementedException();
        }

        public Task<CampeonatoPais> ObtenerPais(int IdCampeonato, int IdPais)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Campeonato>> ObtenerTodos()
        {
            return await contexto.Campeonatos
                .OrderBy(campeonato => campeonato.Nombre)
                .ToArrayAsync();
        }
    }
}
