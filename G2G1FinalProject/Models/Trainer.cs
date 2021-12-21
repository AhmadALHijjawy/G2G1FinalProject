using System.ComponentModel.DataAnnotations;

namespace G2G1FinalProject.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        [Required]
        [Display(Name = "Trainer Name")]
        public string TrainerName { get; set; }
        [Required]
        [Display(Name = "Trainer Info")]
        public string TrainerInfo { get; set; }
        [Required]
        [Display(Name = "Trainer CV")]
        public string TrainerCv { get; set; }

    }
}
