using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public class EstadioRepositorio : IEstadioRepositorio
    {

        private readonly CampeonatosFIFAContext contexto;

        public EstadioRepositorio(CampeonatosFIFAContext contexto)
        {
            this.contexto = contexto;
        }
        public async Task<Estadio> Agregar(Estadio Estadio)
        {
            // agregar elemento al DbSet
            contexto.Estadios.Add(Estadio);
            // llevar los cambios a la base de datos
            await contexto.SaveChangesAsync();
            //retornar registro agregado
            return contexto.Estadios.FirstOrDefault(estadio => estadio.Id == Estadio.Id);
        }

        public async Task<IEnumerable<Estadio>> Buscar(int IndiceDato, string Texto)
        {

            return await contexto.Estadios
            .Where(estadio => IndiceDato == 1 && estadio.Nombre.Contains(Texto))
            .Include(estadio => estadio.Ciudad)
                .OrderBy(estadio => estadio.Nombre)
            .ToArrayAsync();
        }

        public  async Task<bool> Eliminar(int Id)
        {
            var EstadioExistente = await contexto.Estadios.FindAsync(Id);
            if (EstadioExistente == null)
            {
                return false;
            }
            try
            {
                //quitar elemento del dbset
                contexto.Estadios.Remove(EstadioExistente);
                // llevar los cambios a la base de datos
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Estadio> Modificar(Estadio Estadio)
        {
            //buscar el elemento en el dbset
            var EstadioExistente = await contexto.Estadios.FindAsync(Estadio.Id);
            if (EstadioExistente == null)
            {
                return null;
            }
            //cambiar los datos en el elemento del dbset
            contexto.Entry(EstadioExistente).CurrentValues.SetValues(Estadio);
            // llevar los cambios a la base de datos
            await contexto.SaveChangesAsync();

            //retornar registro modificado
            return contexto.Estadios.FirstOrDefault(estadio => estadio.Id == Estadio.Id);
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
