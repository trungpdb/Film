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
    /// Create table Director containt information of director.
    /// </summary>
    [Table ("Director")]
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }

        // Set nvarchar 100
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string DirectorName { get; set; }

        // Set bit for DirectorGender
        [Column(TypeName = "BIT")]
        public bool DirectorGender { get; set; }

        // Set Datetime for DirectorBirthday
        [Column(TypeName = "DateTime")]
        public DateTime DirectorBirthday { get; set; }

        // Set text for DirectorDescribe
        [Column(TypeName = "text")]
        public string DirectorDescribe { get; set; }

        // Set text for DirectorImage
        [Column(TypeName = "text")]
        public string DirectorImg { get; set; }

        // Set bit for DirectorStatus
        [Column(TypeName = "BIT")]
        public bool DirectorStatus { get; set; }

        public ICollection<SubDirector> SubDirectors { get; set; }
    }
}
