using System.Collections.Generic;
using System.Linq;
using DAO.Models;

namespace DAO.Data
{
    public class DAOSubActor
    {
        #region Property

        DataContext ctx = null;

        #endregion //end declare property

        #region Methods

        /// <summary>
        /// Getting all infomation of all actors in database
        /// </summary>
        /// <returns></returns>
        public List<SubActor> GetAllInfoSubActor()
        {
            return ctx.SubActors.ToList();
        }

        /// <summary>
        /// Getting all infomation of a actor via id in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SubActor GetSubActorById(int id)
        {
            return ctx.SubActors.Where(t => t.ActorID == id).FirstOrDefault();
        }
        
        /// <summary>
        /// Add a actor to Database
        /// </summary>
        /// <param name="subActor"></param>
        /// <returns>the row count affected</returns>
        public int AddSubActor(SubActor subActor)
        {
            ctx.SubActors.Add(subActor);
            return ctx.SaveChanges();
        }

        /// <summary>
        /// Delete a Actor from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns> 
        /// *the row affected
        /// *results  = -1 is fail (Now this fail is the item equal null)
        /// </return>
        public int DeleteActor(int id)
        {
            var item = ctx.SubActors.Find(id);
            if (item != null)
            {
                ctx.SubActors.Remove(item);
                return ctx.SaveChanges();
            }
            return -1;
        }

        #endregion //end declare methods

        #region Contructor
        public DAOSubActor()
        {
            ctx = new DataContext();
        }
        #endregion //end declare Contructor
    }
}
