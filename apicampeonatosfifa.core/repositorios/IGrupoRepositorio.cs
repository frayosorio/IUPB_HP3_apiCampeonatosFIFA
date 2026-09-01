using System;
using System.Collections.Generic;
using System.Text;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.core.repositorios
{
    public interface IGrupoRepositorio
    {
        Task<IEnumerable<Grupo>> ObtenerCampeonato(int IdCampeonato);

        Task<Grupo> Obtener(int Id);

        Task<Grupo> Agregar(Grupo Grupo);

        Task<Grupo> Modificar(Grupo Grupo);

        Task<bool> Eliminar(int Id);

        // Tabla de Posiciones
        Task<IEnumerable<TablaPosicionDto>> ObtenerPosiciones(int Id);

    }
}
