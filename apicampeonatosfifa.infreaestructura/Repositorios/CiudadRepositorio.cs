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

        public Task<IEnumerable<Ciudad>> Buscar(int IndiceDato, string Texto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Ciudad> Modificar(Ciudad Ciudad)
        {
            throw new NotImplementedException();
        }

        public Task<Ciudad> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ciudad>> ObtenerPais(int IdPais)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ciudad>> ObtenerTodos()
        {
            return await contexto.Ciudades

                .ToArrayAsync();
        }
    }
}
