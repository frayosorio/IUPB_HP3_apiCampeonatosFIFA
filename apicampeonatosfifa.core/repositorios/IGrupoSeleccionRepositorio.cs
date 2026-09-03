using System;
using System.Collections.Generic;
using System.Text;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.core.repositorios
{
    public  interface IGrupoSeleccionRepositorio
    {
        Task<IEnumerable<GrupoSeleccion>> ObtenerGrupo(int IdGrupo);

        Task<GrupoSeleccion> Agregar(GrupoSeleccion GrupoSeleccion);

        Task<GrupoSeleccion> Modificar(GrupoSeleccion GrupoSeleccion);

        Task<bool> Eliminar(int Id);
    }
}
