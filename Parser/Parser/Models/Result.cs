using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parser.Models
{
    public class Result
    {

        [Key]
        [ScaffoldColumn(false)]
        public int ResultId { get; set; }

        [Display(Name = "POS")]
        [Required(ErrorMessage = "Поле обязательно")]
        public string Pos { get; set; }

        [Display(Name = "LAPS")]
        [Required(ErrorMessage = "Поле обязательно")]
        public int Laps { get; set; }

        [Display(Name = "Time/Retired")]
        [Required(ErrorMessage = "Поле обязательно")]
        public string Time { get; set; }

        [Required]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}