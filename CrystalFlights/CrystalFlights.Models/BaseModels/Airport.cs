﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Airport")]
    public class Airport : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Airport Id")]
        public long Id { get; set; }

        [Display(Name = "Airport Name")]
        [Required(ErrorMessage = "Airport name is required")]
        public string? Name { get; set; }

        [Display(Name = "Airport Code")]
        [Required(ErrorMessage = "Airport code is required")]
        public string? Code { get; set; }

        public string? CityCode { get; set; }

        public string? CityName { get; set; }

        public string? StateCode { get; set; }

        public string? StateName { get; set; }

        public string? CountryCode { get; set; }

        public string? CountryName { get; set; }

        public string? Continent { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longtitude { get; set; }

        public string? DisplayName { get; set; }
    }
}
