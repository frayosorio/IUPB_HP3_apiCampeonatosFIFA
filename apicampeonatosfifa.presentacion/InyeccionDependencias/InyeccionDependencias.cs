using apicampeonatosfifa.aplicacion;
using apicampeonatosfifa.core.repositorios;
using apicampeonatosfifa.core.servicios;
using apicampeonatosfifa.infraestructura.Persistencia;
using apicampeonatosfifa.infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace presentacion.InyeccionDependencias
{
    public static class InyeccionDependencias
    {

        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
                                                IConfiguration configuracion
                                                )
        {
            // agregar el DBContext
            servicios.AddDbContext<CampeonatosFIFAContext>(opciones =>
            {
                opciones.UseSqlServer(configuracion.GetConnectionString("CampeonatosFIFA"));
            });

            // agregar los repositorios
            servicios.AddTransient<ISeleccionRepositorio, SeleccionRepositorio>();
            servicios.AddTransient<ICiudadRepositorio, CiudadRepositorio>();

            // agregar los servicios
            servicios.AddTransient<ISeleccionServicio, SeleccionServicio>();
            servicios.AddTransient<ICiudadServicio, CiudadServicio>();


            return servicios;
        }
    }
}
