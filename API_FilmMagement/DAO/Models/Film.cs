using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    /// <summary>
    /// Create table Film
    /// </summary>
    [Table ("Film")]
    public class Film
    {
        [Key]
        public int FilmID { get; set; }

        [MaxLength (100)]
        [Required]
        public string FilmName { get; set; }

        public string Describe { get; set; }

        public int Rate { get; set; }

        public DateTime Year { get; set; }

        public string Img { get; set; }

        public bool Status { get; set; }

        public ICollection<SubType> SubTypes { get; set; }
        public ICollection<SubActor> SubActors { get; set; }
        public ICollection<SubDirector> SubDirectors { get; set; }
        public ICollection<SubUser> SubUsers { get; set; }
    }
}
