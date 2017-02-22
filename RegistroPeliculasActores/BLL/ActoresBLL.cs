using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RegistroPeliculasActores.BLL
{
    public class ActoresBLL
    {
        public static bool Guardar(Entidades.Actores actor)
            {
                using (var Conec = new DAL.PeliculaActorDb())
                {
                    try
                    {
                        Conec.Actor.Add(actor);
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

        public static bool Eliminar(Entidades.Actores actor)
            {
                using (var Conec = new DAL.PeliculaActorDb())
                {
                    try
                    {
                        Conec.Entry(actor).State = EntityState.Deleted;
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

        public static Entidades.Actores Buscar(int id)
            {
                Entidades.Actores actor = new Entidades.Actores();

                using (var Conec = new DAL.PeliculaActorDb())
                {
                    try
                    {
                        actor = Conec.Actor.Find(id);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                return actor;
            }

        public static List<Entidades.Actores> GetList()
            {
                using (var Conec = new DAL.PeliculaActorDb())
                {
                    try
                    {
                        return Conec.Actor.ToList();
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
