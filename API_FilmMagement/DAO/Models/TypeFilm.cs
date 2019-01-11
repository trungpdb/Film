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
    /// Create table Type
    /// </summary>
    [Table("Type")]
    public class TypeFilm
    {
        [Key]
        public int TypeID { get; set; }

        [Required]
        [MaxLength(100)]      
        public string NameType { get; set; }

        public ICollection<SubType> SubTypes { get; set; }     
    }
}
