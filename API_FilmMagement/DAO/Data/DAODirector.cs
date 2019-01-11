using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Data
{
    public class DAODirector
    {
        DataContext database = null;

        public DAODirector()
        {
            database = new DataContext();
        }

        public List<Director> GetAllDirectors()
        {
            return database.Directors.ToList();
        }

        public Director GetDirectorByID(int id)
        {
            return database.Directors.Where(d => d.DirectorID == id).FirstOrDefault();
        }

        public int AddNewDirector(Director director)
        {
            database.Directors.Add(director);
            return database.SaveChanges();
        }

        public int RemoveDirector(Director director)
        {
            database.Directors.Remove(director);
            return database.SaveChanges();
        }

        public int UpdateDirector(int id, Director director)
        {
            Director directorSource = database.Directors.Find(id);

            directorSource.DirectorID = director.DirectorID;
            directorSource.DirectorName = director.DirectorName;
            directorSource.DirectorBirthday = director.DirectorBirthday;
            directorSource.DirectorGender = director.DirectorGender;
            directorSource.DirectorDescribe = director.DirectorDescribe;
            directorSource.DirectorStatus = director.DirectorStatus;
            directorSource.DirectorImg = director.DirectorImg;

            return database.SaveChanges();
        }
    }
}
