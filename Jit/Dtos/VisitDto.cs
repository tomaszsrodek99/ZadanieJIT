using System.ComponentModel.DataAnnotations;

namespace Jit.Dtos
{
    public class VisitDto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane."), Display(Name = "Data wizyty")]
        //Tu miał być walidator godziny
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane."), Display(Name = "Właściciel")]
        public string NameOfOwner { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane."), Display(Name = "Imię zwierzęcia")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane."), Display(Name = "Wiek")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane."), Display(Name = "Kolor sierści")]
        public string Color { get; set; }
    }
}
