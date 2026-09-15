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
        public Task<Ciudad> Agregar(Ciudad Ciudad)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ciudad>> Buscar(int IndiceDato, string Texto)
        {

            return await contexto.Ciudades
            .Where(ciudad => IndiceDato == 1 && ciudad.Nombre.Contains(Texto))
            .Include(ciudad => ciudad.Pais)
                .OrderBy(ciudad => ciudad.Nombre)
            .ToArrayAsync();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Ciudad> Modificar(Ciudad Ciudad)
        {
            throw new NotImplementedException();
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
