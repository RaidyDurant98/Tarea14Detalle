using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroPeliculasActores.Entidades
{
    public class Actores
    {
        [Key]
        public int ActorId { get; set; }
        public string Nombre { get; set; }

        public virtual List<Peliculas> Pelicula { get; set; }

        public Actores()
        {
            this.Pelicula = new List<Peliculas>();
        }
    }
}
