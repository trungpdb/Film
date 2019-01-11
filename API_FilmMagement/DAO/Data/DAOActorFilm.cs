using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Models;

namespace DAO.Data
{
    public class DAOActorFilm
    {
        #region Property
        public DataContext ctx = null;
        #endregion

        #region Method
        /// <summary>
        /// this method will help getting all infomation of actors in Database 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Actor> GetAllInfoActor()
        {
            return ctx.Actors.ToList();
        }

        /// <summary>
        /// this method will help getting the infomation of a actor in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Actor GetActorById(int id)
        {
            return ctx.Actors.Where(t => t.ActorID == id).FirstOrDefault();
        }

        /// <summary>
        /// add a actor to database
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public int AddNew(Actor actor)
        {
            ctx.Actors.Add(actor);
            return ctx.SaveChanges();
        }

        /// <summary>
        /// Delete a Actor in Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteActor(int id)
        {
            var item = ctx.Actors.Find(id);
            if(item != null)
            {
                ctx.Actors.Remove(item);
                return ctx.SaveChanges();
            }
            return -1;
        }
        #endregion

        #region Contructor

        public DAOActorFilm()
        {
            this.ctx = new DataContext();
        }

        #endregion
    }
}
