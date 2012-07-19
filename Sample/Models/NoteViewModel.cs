using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public class NoteViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Created date is required")]
        public DateTime? Created { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 50, ErrorMessage = "Age must be between 18 and 50")]
        public int Age { get; set; }
    }
}