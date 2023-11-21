using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Teacher
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }


        [MaxLength(50)]
        [MinLength(10)]
        public string TeacherName { get; set; }


        [Range(20, 60)]//this mean the age must be between 20 and 60
        public int TeacherAge { get; set; }


    }
}
