using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using apicampeonatosfifa.dominio;

namespace apicampeonatosfifa.infraestructura.Persistencia
{
    public class CampeonatosFIFAContext : DbContext
    {
        public DbSet<Seleccion> Selecciones { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Encuentro> Encuentros { get; set; }
        public DbSet<CampeonatoPais> CampeonatosPaises { get; set; }
        public DbSet<GrupoSeleccion> GruposSelecciones { get; set; }

        protected override void onModelCreating(ModelBuilder constructor)
        {
            constructor.Entity<Seleccion>(entidadSeleccion =>
            {
                entidadSeleccion.HasKey(e => e.Id);
                entidadSeleccion.HasIndex(e => e.Nombre).IsUnique();
            }
                );

            constructor.Entity<Campeonato>(entidadCampeonato =>
            {
                entidadCampeonato.HasKey(e => e.Id);
                entidadCampeonato.HasIndex(e => e.Nombre).IsUnique();
            });

            constructor.Entity<CampeonatoPais>(entidadCampeonatoPais =>
            {
                entidadCampeonatoPais.HasKey(e => new { e.IdCampeonato, e.IdPais });
            }
                );

            constructor.Entity<CampeonatoPais>()
                .HasOne(e => e.Campeonato)
                .WithMany()
                .HasForeignKey(e => e.IdCampeonato);

            constructor.Entity<CampeonatoPais>()
                .HasOne(e => e.Pais)
                .WithMany()
                .HasForeignKey(e => e.IdPais);

            constructor.Entity<GrupoSeleccion>(entidadGrupoSeleccion =>
            {
                entidadGrupoSeleccion.HasKey(e => new { e.IdGrupo, e.IdSeleccion });
            }
                );

            constructor.Entity<GrupoSeleccion>()
                .HasOne(e => e.Grupo)
                .WithMany()
                .HasForeignKey(e => e.IdGrupo);

            constructor.Entity<GrupoSeleccion>()
                .HasOne(e => e.Seleccion)
                .WithMany()
                .HasForeignKey(e => e.IdSeleccion);

        }
    }
}
