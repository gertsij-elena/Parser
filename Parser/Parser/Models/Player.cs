using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parser.Models
{
    public class Player
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PlayerId { get; set; }

        [Display(Name = "NO")]
        [Required(ErrorMessage = "Поле обязательно")]
        public int No { get; set; }

        [Display(Name = "DRIVER")]
        [Required(ErrorMessage = "Поле обязательно")]
        public string Driver { get; set; }

        [Required]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public virtual ICollection<Result> Results { get; set; }

        //public virtual ICollection<Team> Teams { get; set; }

        //public Player()
        //{
        //    Teams = new List<Team>();
        //}
    }
}