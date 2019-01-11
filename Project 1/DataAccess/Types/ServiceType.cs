using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;
using DataObject.EF;
using DataObject.Models;

namespace DataAccess.Types
{
    
    /// <summary>
    /// kế thừa interface Type
    /// </summary>
    public class ServiceType : InterfaceType
    {
        FilmDataContext db = null;

        ///<summary>
        /// Khởi tạo chuỗi kết nối
        ///</summary>
        public ServiceType()
        {
            db = new FilmDataContext();
        }

        ///<summary>
        /// Thêm mới
        ///</summary>
        public int AddNewType(TypeFilmModel typeFilm)
        {
            if (typeFilm == null)
            {
                return -1;
            }
            //Create actor
            DataObject.EF.TypeFilm _tType = new DataObject.EF.TypeFilm()
            {
                NameType = typeFilm.NameType,
                TypeID = typeFilm.TypeID
            };
            db.TypeFilms.Add(_tType);
            return db.SaveChanges();
        }

        ///<summary>
        /// Xóa
        ///</summary>
        public int DeleteType(int id)
        {
            var select = db.TypeFilms.Where(t => t.TypeID == id).FirstOrDefault();

            if (select != null)
            {
                db.TypeFilms.Remove(select);
                return db.SaveChanges();
                
            }
            return 0;
        }

        ///<summary>
        /// Sửa
        ///</summary>
        public int EditType(int id, TypeFilmModel typeFilm)
        {
            var select = db.TypeFilms.Where(f => f.TypeID == typeFilm.TypeID).FirstOrDefault();

            // tìm kiếm phim có hay không?
            if (select != null)
            {
                // update
                select.TypeID = typeFilm.TypeID;
                select.NameType = typeFilm.NameType;

                // return database
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        ///<summary>
        /// Tìm thể loại theo tên
        ///</summary>
        public List<TypeFilmModel> FindByeName(string name)
        {
            var item = db.TypeFilms.Where(p => p.NameType.Contains(name)).Select(a => new TypeFilmModel
            {
                NameType = a.NameType,
                TypeID = a.TypeID
            }).ToList();
            return item;
        }

        ///<summary>
        /// Tìm thể loại theo id
        ///</summary>
        public TypeFilmModel FindById(int id)
        {
            var myType = db.TypeFilms.Where(a => a.TypeID == id).Select(aa => new TypeFilmModel
            {
                NameType = aa.NameType,
                TypeID = aa.TypeID
            });
            TypeFilmModel data = myType.FirstOrDefault();
            return data;
        }

        ///<summary>
        /// Trả về danh sách thể loại
        ///</summary>
        public List<TypeFilmModel> GetListAll()
        {
            var type = db.TypeFilms.Select(a => new TypeFilmModel
            {
                TypeID = a.TypeID,
                NameType = a.NameType
            }).ToList();
            // transfer
            List<TypeFilmModel> list = type;
            return list;
        }
    }
}
