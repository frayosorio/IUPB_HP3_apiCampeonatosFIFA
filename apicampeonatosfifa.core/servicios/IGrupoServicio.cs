using System;
using System.Collections.Generic;
using System.Text;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.core.servicios
{
    public interface IGrupoServicio
    {
        Task<IEnumerable<Grupo>> ObtenerCampeonato(int IdCampeonato);

        Task<Grupo> Obtener(int Id);

        Task<Grupo> Agregar(Grupo Grupo);

        Task<Grupo> Modificar(Grupo Grupo);

        Task<bool> Eliminar(int Id);

        // Selecciones
        Task<IEnumerable<GrupoSeleccion>> ObtenerGrupo(int IdGrupo);

        Task<GrupoSeleccion> Agregar(GrupoSeleccion GrupoSeleccion);

        Task<GrupoSeleccion> Modificar(GrupoSeleccion GrupoSeleccion);

        Task<bool> Eliminar(int Id);

        // Tabla de Posiciones
        Task<IEnumerable<TablaPosicionDto>> ObtenerPosiciones(int Id);
    }
}
