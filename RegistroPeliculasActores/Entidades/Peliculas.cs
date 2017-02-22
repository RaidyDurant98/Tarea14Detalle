using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroPeliculasActores.Entidades
{
    public class Peliculas
    {
        [Key]
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEstreno { get; set; }
        public int ActorId { get; set; }

        public virtual List<Actores> Actor { get; set; }

        public Peliculas()
        {
            this.Actor = new List<Actores>();
        }
    }
}
