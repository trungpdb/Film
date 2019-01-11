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
    /// Create table User
    /// </summary>
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(20)]
        public string UserName { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

        public bool Gender { get; set; }

        public DateTime Birthday { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        public virtual ICollection<SubUser> SubUsers { get; set; }
    }
}
