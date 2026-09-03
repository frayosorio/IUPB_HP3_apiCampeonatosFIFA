using System;
using System.Collections.Generic;
using System.Text;
using apicampeonatosfifa.dominio;
using apicampeonatosfifa.core.;

namespace apicampeonatosfifa.infraestructura.Repositorios
{
    public class SeleccionRepositorio: ISeleccionRepositorio
    {
        Task<IEnumerable<Seleccion>> ObtenerTodos()
        {

        }

        Task<Seleccion> Obtener(int Id)
        {

        }

        Task<IEnumerable<Seleccion>> Buscar(int IndiceDato, string Texto)
        {

        }

        Task<Seleccion> Agregar(Seleccion Seleccion)
        {

        }

        Task<Seleccion> Modificar(Seleccion Seleccion)
        {

        }

        Task<bool> Eliminar(int Id)
        {

        }
    }
}
