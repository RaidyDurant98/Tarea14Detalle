using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroPeliculasActores.BLL
{
    public class PeliculasBLL
    {
        public static bool Guardar(Entidades.Peliculas pelicula)
        {
            using(var Conec = new DAL.PeliculaActorDb())
            {
                try
                {
                    Conec.Pelicula.Add(pelicula);

                    foreach (var cat in pelicula.Actor)
                    {
                        Conec.Entry(cat).State = EntityState.Unchanged;
                    }

                    Conec.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    //throw;
                }
            }

            return false;
        }

        public static bool Eliminar(Entidades.Peliculas pelicula)
        {
            using(var Conec = new DAL.PeliculaActorDb())
            {
                try
                {
                    Conec.Entry(pelicula).State = EntityState.Deleted;
                    Conec.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static Entidades.Peliculas Buscar(int id)
        {
            Entidades.Peliculas pelicula = new Entidades.Peliculas();

            using(var Conec = new DAL.PeliculaActorDb())
            {
                try
                {
                    pelicula = Conec.Pelicula.Find(id);
                    pelicula.Actor.Count();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    //throw;
                }
            }

            return pelicula;
        }

        public static List<Entidades.Peliculas> GetList()
        {
            using (var Conec = new DAL.PeliculaActorDb())
            {
                try
                {
                    return Conec.Pelicula.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return null;
        }

        public static List<Entidades.Peliculas> GetListFecha(DateTime desde, DateTime hasta)
        {
            using (var Conec = new DAL.PeliculaActorDb())
            {
                try
                {
                    return Conec.Pelicula.Where(p => p.FechaEstreno >= desde.Date && p.FechaEstreno <= hasta.Date).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return null;
        }
    }
}
