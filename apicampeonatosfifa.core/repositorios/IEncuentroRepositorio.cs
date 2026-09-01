using System;
using System.Collections.Generic;
using System.Text;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.core.repositorios
{
    public  interface IEncuentroRepositorio
    {
        Task<IEnumerable<Encuentro>> ObtenerCampeonato(int IdCampeonato);

        Task<IEnumerable<Encuentro>> ObtenerCampeonatoFase(int IdCampeonato, int IdFase);

        Task<IEnumerable<Encuentro>> ObtenerGrupo(int IdGrupo);

        Task<Encuentro> Obtener(int Id);

        Task<Encuentro> Agregar(Encuentro Encuentro);

        Task<Encuentro> Modificar(Encuentro Encuentro);

        Task<bool> Eliminar(int Id);
    }
}
