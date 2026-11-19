using apicampeonatosfifa.dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace apicampeonatosfifa.core.servicios
{
    public interface ICampeonatoServicio
    {
        Task<IEnumerable<Campeonato>> ObtenerTodos();

        Task<Campeonato> Obtener(int Id);

        Task<IEnumerable<Campeonato>> Buscar(int IndiceDato, string Texto);

        Task<Campeonato> Agregar(Campeonato Campeonato);

        Task<Campeonato> Modificar(Campeonato Campeonato);

        Task<bool> Eliminar(int Id);
    }
}
