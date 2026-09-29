using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public class CiudadRepositorio : ICiudadRepositorio
    {

        private readonly CampeonatosFIFAContext contexto;

        public CiudadRepositorio(CampeonatosFIFAContext contexto)
        {
            this.contexto = contexto;
        }
        public async Task<Ciudad> Agregar(Ciudad Ciudad)
        {
            contexto.Ciudades.Add(Ciudad);
            await contexto.SaveChangesAsync();
            return Ciudad;
        }

        public async Task<IEnumerable<Ciudad>> Buscar(int IndiceDato, string Texto)
        {
            return await contexto.Ciudades
            .Where(ciudad => IndiceDato == 1 && ciudad.Nombre.Contains(Texto))
            .Include(ciudad => ciudad.Pais)
                .OrderBy(ciudad => ciudad.Nombre)
            .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var CiudadExistente = await contexto.Ciudades.FindAsync(Id);
            if (CiudadExistente == null)
            {
                return false;
            }
            try
            {
                contexto.Ciudades.Remove(CiudadExistente);
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Ciudad> Modificar(Ciudad Ciudad)
        {
            var CiudadExistente = await contexto.Ciudades.FindAsync(Ciudad.Id);
            if (CiudadExistente == null)
            {
                return null;
            }
            contexto.Entry(CiudadExistente).CurrentValues.SetValues(Ciudad);
            await contexto.SaveChangesAsync();
            return CiudadExistente;
        }

        public async Task<Ciudad> Obtener(int Id)
        {
            return await contexto.Ciudades
                .Include(ciudad => ciudad.Pais)
                .FirstOrDefaultAsync(ciudad => ciudad.Id == Id);
        }

        public async Task<IEnumerable<Ciudad>> ObtenerPais(int IdPais)
        {
            return await contexto.Ciudades
                .Where(ciudad => ciudad.IdPais == IdPais)
                .Include(ciudad => ciudad.Pais)
                .OrderBy(ciudad => ciudad.Nombre)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Ciudad>> ObtenerTodos()
        {
            return await contexto.Ciudades
                .Include(ciudad => ciudad.Pais)
                .OrderBy(ciudad => ciudad.Nombre)
                .ToArrayAsync();
        }
    }
}
