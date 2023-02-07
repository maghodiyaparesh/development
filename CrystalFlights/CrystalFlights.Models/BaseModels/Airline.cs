﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Airline")]
    public class Airline : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Airline Id")]
        public long Id { get; set; }

        [Display(Name = "Airline Name")]
        [Required(ErrorMessage = "Airline name is required")]
        public string? Name { get; set; }

        [Display(Name = "Airline Code")]
        [Required(ErrorMessage = "Airline code is required")]
        public string? Code { get; set; }
    }
}
