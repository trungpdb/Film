using DataObject;
using DataObject.EF;
using DataObject.Models;
using DataService.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIAplication.Controllers
{
    public class DirectorController : ApiController
    {
        //    private DirectorService db = new DirectorService();

        /// <summary>
        /// GET: gets list director
        /// </summary>
        /// <returns> list director </returns>
        [HttpGet]
        [Route("api/director/GetAllDirectors")]
        public IHttpActionResult GetAllDirectors()
        {
            // create server director
            DirectorService DirectorService = new DirectorService();

            // get list director
            var select = DirectorService.GetAllDirectors();

            if (select != null)
            {
                return Ok(select);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// GET: Search director by name
        /// </summary>
        /// <param name="name"> name of director </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/director/FindDirectorByName/{name}")]
        public IHttpActionResult FindDirectorByName(string name)
        {
            // create server director
            DirectorService DirectorService = new DirectorService();

            // get director have directorName like name
            var select = DirectorService.FindDirectorByName(name);

            if (select != null)
            {
                return Ok(select);
            }
            else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// GET: Search director have directorID like id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/director/FindDirectorByID/{id}")]
        public IHttpActionResult FindDirectorByID(int id)
        {
            // create server director
            DirectorService DirectorService = new DirectorService();

            // get director have directorID like id
            var select = DirectorService.GetDirectorByID(id);

            if (select != null)
            {
                return Ok(select);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create new director
        /// </summary>
        /// <param name="director"> director want add </param>
        // POST: api/Director
        [HttpPost]
        [Route("api/director/AddNewDirector/")]
        public IHttpActionResult AddNewDirector([FromBody]DirectorModel director)
        {
            // director not null
            if (director != null)
            {
                // create server director
                DirectorService DirectorService = new DirectorService();

                // add director
                var check = DirectorService.AddNewDirector(director);

                // add success
                if (check > 0)
                {
                    return Ok(director);
                }
                else
                {
                    return BadRequest("Thêm đạo diễn thất bại");
                }
            }

            // director is null
            else
            {
                return BadRequest("Đạo diễn thêm mới đang bị NULL");
            }
        }

        /// <summary>
        /// POST:  Update a director
        /// </summary>
        /// <param name="id"> id of director</param>
        /// <param name="director"> director want update</param>
        [HttpPost]
        [Route("api/director/EditDirector/")]
        public IHttpActionResult EditDirector([FromBody]DirectorModel director)
        {
            if (director != null)
            {
                // create server director
                DirectorService DirectorService = new DirectorService();

                // Edit director
                var edit = DirectorService.UpdateDirector(director);

                if (edit > 0)
                {
                    return Ok(director);
                }
                else
                {
                    return BadRequest("Chỉnh sửa đạo diễn thất bại !");
                }
            }

            return BadRequest("Chỉnh sửa đạo diễn muốn xóa đang bị NULL");
        }

        /// <summary>
        /// Delete a director
        /// </summary>
        /// <param name="id"> id of director </param>
        [HttpGet]
        [Route("api/director/RemoveDirectorByID/{id}")]
        public IHttpActionResult RemoveDirectorByID(int id)
        {
            // create server director
            DirectorService DirectorService = new DirectorService();

            // Delete directo by ID
            var check = DirectorService.RemoveDirectorByID(id);

            // Delete 
            if (check > 0)
            {
                return Ok(check);
            }
            else
            {
                return BadRequest("Xóa đạo diễn thất bại !");
            }
        }

        /// <summary>
        /// Find a director
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DirectorExists(int id)
        {
            // create server director
            DirectorService DirectorService = new DirectorService();

            var c = DirectorService.GetDirectorByID(id);

            // Exists
            if (c != null)
            {
                return true;
            }

            return false;
        }
    }
}
