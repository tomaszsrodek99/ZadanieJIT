using System.ComponentModel.DataAnnotations;

namespace Jit.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public string NameOfOwner { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
