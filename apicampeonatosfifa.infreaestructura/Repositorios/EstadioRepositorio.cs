using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public  class EstadioRepositorio:IEstadioRepositorio
    {

        private readonly CampeonatosFIFAContext contexto;

        public EstadioRepositorio(CampeonatosFIFAContext contexto)
        {
            this.contexto = contexto;
        }
        public Task<Estadio> Agregar(Estadio Estadio)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Estadio>> Buscar(int IndiceDato, string Texto)
        {

            return await contexto.Estadios
            .Where(estadio => IndiceDato == 1 && estadio.Nombre.Contains(Texto))
            .Include(estadio => estadio.Ciudad)
                .OrderBy(estadio => estadio.Nombre)
            .ToArrayAsync();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Estadio> Modificar(Estadio Estadio)
        {
            throw new NotImplementedException();
        }

        public async Task<Estadio> Obtener(int Id)
        {
            return await contexto.Estadios
                .Include(estadio => estadio.Ciudad)
                .FirstOrDefaultAsync(estadio => estadio.Id == Id);
        }

        public async Task<IEnumerable<Estadio>> ObtenerCiudad(int IdCiudad)
        {
            return await contexto.Estadios
                .Where(estadio => estadio.IdCiudad == IdCiudad)
                .Include(estadio => estadio.Ciudad)
                .OrderBy(estadio => estadio.Nombre)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Estadio>> ObtenerPais(int IdPais)
        {
            return await contexto.Estadios
                .Where(estadio => estadio.Ciudad.IdPais == IdPais)
                .Include(estadio => estadio.Ciudad)
                .OrderBy(estadio => estadio.Nombre)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Estadio>> ObtenerCampeonato(int IdCampeonato)
        {
            return await contexto.Estadios
                //por completar
                .Include(estadio => estadio.Ciudad)
                .OrderBy(estadio => estadio.Nombre)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Estadio>> ObtenerTodos()
        {
            return await contexto.Estadios
                .Include(estadio => estadio.Ciudad)
                .OrderBy(estadio => estadio.Nombre)
                .ToArrayAsync();
        }
    }
}
