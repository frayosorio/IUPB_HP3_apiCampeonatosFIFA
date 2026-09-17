using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public class EncuentroRepositorio : IEncuentroRepositorio
    {
        private readonly CampeonatosFIFAContext contexto;

        // Inyeccion de dependencias
        public EncuentroRepositorio(CampeonatosFIFAContext contexto)
        {
            this.contexto = contexto;
        }

        public Task<Encuentro> Agregar(Encuentro Encuentro)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Encuentro> Modificar(Encuentro Encuentro)
        {
            throw new NotImplementedException();
        }

        public Task<Encuentro> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Encuentro>> ObtenerCampeonato(int IdCampeonato)
        {
            return await contexto.Encuentros
                .Where(encuentro => encuentro.Campeonato.Id == IdCampeonato)
                .Include(encuentro => encuentro.Seleccion1)
                .Include(encuentro => encuentro.Seleccion2)
                .Include(encuentro => encuentro.Estadio)
                    .ThenInclude(estadio => estadio.Ciudad)
                .Include(encuentro => encuentro.Fase)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Encuentro>> ObtenerCampeonatoFase(int IdCampeonato, int IdFase)
        {
            return await contexto.Encuentros
                .Where(encuentro => encuentro.Campeonato.Id == IdCampeonato &&
                                    encuentro.Fase.Id == IdFase)
                .Include(encuentro => encuentro.Seleccion1)
                .Include(encuentro => encuentro.Seleccion2)
                .Include(encuentro => encuentro.Estadio)
                    .ThenInclude(estadio => estadio.Ciudad)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Encuentro>> ObtenerGrupo(int IdGrupo)
        {
            // obtener el ID del CAMPEONATO del GRUPO consultado
            int idCampeonato = contexto.Grupos
                .FirstOrDefault(grupo => grupo.Id == IdGrupo).IdCampeonato;

            return await contexto.Encuentros
                .Where(encuentro => encuentro.Fase.Id == 1 && encuentro.Campeonato.Id== idCampeonato)
                .Where(encuentro => contexto.GruposSelecciones
                   .Any(grupoSeleccion => grupoSeleccion.IdGrupo == IdGrupo &&
                             (grupoSeleccion.IdSeleccion == encuentro.IdSeleccion1 
                             || grupoSeleccion.IdSeleccion == encuentro.IdSeleccion2)))
                .Include(encuentro => encuentro.Seleccion1)
                .Include(encuentro => encuentro.Seleccion2)
                .Include(encuentro => encuentro.Estadio)
                    .ThenInclude(estadio => estadio.Ciudad)
                .ToArrayAsync();
        }
    }
}
