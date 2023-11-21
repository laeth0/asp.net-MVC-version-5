using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        public string CourseName { get; set; }

        [Range(1, 100)]
        public int CourseCapacity { get; set; }


        //navigation property
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        //we put this property to make the relation between the two tables
        //and indicate that the teacherId is the foreign key in the course table

    }

}
