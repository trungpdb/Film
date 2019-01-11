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
    /// Create table SubUser
    /// </summary>
    [Table("SubUser")]
    public class SubUser
    {
        [Key, Column(Order = 0)]      
        public int UserID { get; set; }

        [Key, Column(Order = 1)]
        public int FilmID { get; set; }


        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("FilmID")]
        public Film Film { get; set; }
    }
}
