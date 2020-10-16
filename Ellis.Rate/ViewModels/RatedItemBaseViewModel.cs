using System.ComponentModel.DataAnnotations;

namespace Ellis.Rate.ViewModels
{
    public class RatedItemBaseViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
    }

}