using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TODO_App.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskID { get; set; }
        [Required]
        [DisplayName("Nazwa zadania")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Descripiton { get; set; }
        [Required]
        [DisplayName("Czy zrobione")]
        public bool Done { get; set; }
    }

}