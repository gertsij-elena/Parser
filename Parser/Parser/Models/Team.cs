using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parser.Models
{
    public class Team
    {
        [Key]
        [ScaffoldColumn(false)]
        public int TeamId { get; set; }

        [Display(Name = "Team")]
        [Required(ErrorMessage = "Поле обязательно")]
        [StringLength(50, ErrorMessage = "Длина не должна превышать 50 символов")]
        public string TeamName { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        //public Team()
        //{
        //    Players = new List<Player>();
        //}
    }
}