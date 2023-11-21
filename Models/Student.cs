using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// and there is another option Computed => which use when the column is computed in the database like age and birthdate and so on
        public int Id { get; set; }


        [MaxLength(50)]
        [MinLength(5)]
        public string StudentName { get; set; }

        public bool IsActive { get; set; }

        [Range(5, 18)]
        public int StudentAge { get; set; }
    }
}
