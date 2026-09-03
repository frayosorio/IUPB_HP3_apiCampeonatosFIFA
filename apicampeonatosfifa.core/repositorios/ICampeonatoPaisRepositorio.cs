using System;
using System.Collections.Generic;
using System.Text;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.core.repositorios
{
    public interface ICampeonatoPaisRepositorio
    {
        Task<IEnumerable<CampeonatoPais>> ObtenerCampeonato(int IdCampeonato);

        Task<CampeonatoPais> Obtener(int IdCampeonato, int IdPais);

        Task<CampeonatoPais> Agregar(CampeonatoPais CampeonatoPais);

        Task<CampeonatoPais> Modificar(CampeonatoPais CampeonatoPais);

        Task<bool> Eliminar(int Id);
    }
}
