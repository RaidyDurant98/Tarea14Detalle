using RegistroPeliculasActores.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RegistroPeliculasActores.DAL
{
    public class PeliculaActorDb : DbContext
    {
        public PeliculaActorDb() : base("ConStr")
        {

        }

        public DbSet<Peliculas> Pelicula { get; set; }
        public DbSet<Actores> Actor { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actores>()
                .HasMany(actor => actor.Pelicula)
                .WithMany(pelicula => pelicula.Actor)
                .Map(peliculasactores =>
                {
                    peliculasactores.MapLeftKey("PeliculaId");
                    peliculasactores.MapRightKey("ActorId");
                    peliculasactores.ToTable("peliculasActores");
                }
                );
        }
    }
}
