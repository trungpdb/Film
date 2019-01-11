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
    /// Create table SubActor
    /// </summary>
    [Table("SubActor")]
    public class SubActor
    {
        [Key, Column(Order = 0)]
        public int ActorID { get; set; }

        [Key, Column(Order = 1)]
        public int FilmID { get; set; }

        [ForeignKey("ActorID")]
        public Actor Actor { get; set; }

        [ForeignKey("FilmID")]
        public Film Film { get; set; }

    }
}
