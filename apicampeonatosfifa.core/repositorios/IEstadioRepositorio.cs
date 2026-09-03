using System;
using System.Collections.Generic;
using System.Text;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.core.repositorios
{
    public interface IEstadioRepositorio
    {
        Task<IEnumerable<Estadio>> ObtenerTodos();

        Task<IEnumerable<Estadio>> ObtenerPais(int IdPais);

        Task<IEnumerable<Estadio>> ObtenerCiudad(int IdCiudad);

        Task<IEnumerable<Estadio>> ObtenerCampeonato(int IdCampeonato);

        Task<Estadio> Obtener(int Id);

        Task<IEnumerable<Estadio>> Buscar(int IndiceDato, string Texto);

        Task<Estadio> Agregar(Estadio Estadio);

        Task<Estadio> Modificar(Estadio Estadio);

        Task<bool> Eliminar(int Id);
    }
}
