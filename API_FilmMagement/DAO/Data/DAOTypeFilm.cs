using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Data
{
    public class DAOTypeFilm
    {
        DataContext dtx = null;

        public DAOTypeFilm()
        {
            dtx = new DataContext();
        }

        //Detail List Type
        public List<TypeFilm> GetAllList()
        {
            return dtx.TypeFilms.ToList();
        }

        public TypeFilm GetId(int id)
        {
            return dtx.TypeFilms.Where(t => t.TypeID == id).FirstOrDefault();
        }

        //Create Type
        public int AddNew(TypeFilm typeFilm)
        {
            dtx.TypeFilms.Add(typeFilm);
            return dtx.SaveChanges();
        }


    }
}
