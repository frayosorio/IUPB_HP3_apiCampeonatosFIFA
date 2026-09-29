using System;
using System.Collections.Generic;
using System.Text;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.dominio.Dtos;

namespace apicampeonatosfifa.core.repositorios
{
    public interface IGrupoRepositorio
    {
        Task<IEnumerable<Grupo>> ObtenerCampeonato(int IdCampeonato);

        Task<Grupo> Obtener(int Id);

        Task<Grupo> Agregar(Grupo Grupo);

        Task<Grupo> Modificar(Grupo Grupo);

        Task<bool> Eliminar(int Id);

        // Selecciones
        Task<IEnumerable<GrupoSeleccion>> ObtenerGrupo(int IdGrupo);

        Task<GrupoSeleccion> AgregarSeleccion(GrupoSeleccion GrupoSeleccion);

        Task<GrupoSeleccion> ModificarSeleccion(GrupoSeleccion GrupoSeleccion);

        Task<bool> EliminarSeleccion(int IdGrupo, int IdSeleccion);

        // Tabla de Posiciones
        Task<IEnumerable<TablaPosicionDto>> ObtenerPosiciones(int Id);

    }
}
