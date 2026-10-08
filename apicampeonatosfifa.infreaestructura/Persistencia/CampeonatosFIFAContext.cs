using apicampeonatosfifa.dominio;
using apicampeonatosfifa.dominio.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace apicampeonatosfifa.infraestructura.Persistencia
{
    public class CampeonatosFIFAContext : DbContext
    {
        public CampeonatosFIFAContext(DbContextOptions<CampeonatosFIFAContext> opciones) : base(opciones)
        {

        }

        public DbSet<Seleccion> Selecciones { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Encuentro> Encuentros { get; set; }
        public DbSet<CampeonatoPais> CampeonatosPaises { get; set; }
        public DbSet<GrupoSeleccion> GruposSelecciones { get; set; }

        public DbSet<TablaPosicionDto> TablaPosiciones { get; set; }

        protected override void OnModelCreating(ModelBuilder constructor)
        {
            // Tabla PAIS
            constructor.Entity<Seleccion>(entidadSeleccion =>
            {
                entidadSeleccion.HasKey(e => e.Id); // Clave primaria
                entidadSeleccion.HasIndex(e => e.Nombre).IsUnique(); // Indice
            }
                );

            // Tabla CAMPEONATO
            constructor.Entity<Campeonato>(entidadCampeonato =>
            {
                entidadCampeonato.HasKey(e => e.Id); // Clave primaria
                entidadCampeonato.HasIndex(e => e.Nombre).IsUnique(); // Indice
            });

            // Tabla CAMPEONATO-PAIS

            constructor.Entity<CampeonatoPais>(entidadCampeonatoPais =>
            {
                entidadCampeonatoPais.HasKey(e => new { e.IdCampeonato, e.IdPais }); // Clave primaria
            }
                );

            constructor.Entity<CampeonatoPais>()
                .HasOne(e => e.Campeonato)
                .WithMany()
                .HasForeignKey(e => e.IdCampeonato); // Clave foránea

            constructor.Entity<CampeonatoPais>()
                .HasOne(e => e.Pais)
                .WithMany()
                .HasForeignKey(e => e.IdPais); // Clave foránea

            // Tabla GRUPOPAIS
            constructor.Entity<GrupoSeleccion>(entidadGrupoSeleccion =>
            {
                entidadGrupoSeleccion.HasKey(e => new { e.IdGrupo, e.IdSeleccion }); // Clave primaria
            }
                );

            constructor.Entity<GrupoSeleccion>()
                .HasOne(e => e.Grupo)
                .WithMany()
                .HasForeignKey(e => e.IdGrupo); // Clave foránea

            constructor.Entity<GrupoSeleccion>()
                .HasOne(e => e.Seleccion)
                .WithMany()
                .HasForeignKey(e => e.IdSeleccion); // Clave foránea

            // Tabla CIUDAD
            constructor.Entity<Ciudad>(entidadCiudad =>
            {
                entidadCiudad.HasKey(e => e.Id); // Clave primaria
                entidadCiudad.HasIndex(e => new { e.IdPais, e.Nombre }).IsUnique(); // Indice
            }
                );

            constructor.Entity<Ciudad>()
                .HasOne(e => e.Pais)
                .WithMany()
                .HasForeignKey(e => e.IdPais); // Clave foránea

            // Tabla ESTADIO
            constructor.Entity<Estadio>(entidadEstadio =>
            {
                entidadEstadio.HasKey(e => e.Id); // Clave primaria
                entidadEstadio.HasIndex(e => e.Nombre).IsUnique(); // Indice
            }
                );

            constructor.Entity<Estadio>()
                .HasOne(e => e.Ciudad)
                .WithMany()
                .HasForeignKey(e => e.IdCiudad); // Clave foránea

            //DTOs

            constructor.Entity<TablaPosicionDto>().HasNoKey();

        }

        public async Task<IEnumerable<TablaPosicionDto>> getTablaPosiciones(int IdGrupo)
        {
            return await this.Set<TablaPosicionDto>()
                .FromSqlRaw("SELECT * FROM fTablaPosicionesGrupo(@IdGrupo) ORDER BY Puntos DESC",
                new SqlParameter("@IdGrupo", IdGrupo))
                .ToListAsync();
        }
    }
}
