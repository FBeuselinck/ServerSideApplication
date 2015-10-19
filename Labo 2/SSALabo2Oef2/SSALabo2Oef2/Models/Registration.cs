using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSALabo2Oef2.Models
{
    public class Registration
    {
        [Required(ErrorMessage= "Verplicht in te vullen")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Verplicht in te vullen")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Verplicht in te vullen")]
        [Range(12,110, ErrorMessage = "Gelieve een geldige leeftijd in te vullen")]
        [DisplayName("Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Verplicht in te vullen")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Slot1")]
        public string Slot1 { get; set; }
        [DisplayName("Slot2")]
        public string Slot2 { get; set; }
        [DisplayName("Slot3")]
        public string Slot3 { get; set; }
        [DisplayName("Laptop")]
        public bool Laptop { get; set; }
        [DisplayName("Tablet")]
        public bool Tablet { get; set; }
        [DisplayName("Apple Watch")]
        public bool Apple_Watch { get; set; }
        [DisplayName("Organization")]
        public string Organization { get; set; }
        [DisplayName("Are you coming to the closing party?")]
        public bool ClosingParty { get; set; }

    }
}