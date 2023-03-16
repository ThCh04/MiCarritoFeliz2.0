using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MiCarritoFeliz.Models.ViewModels.Cars
{
    public class AddCarViewModel
    {
        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }


        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }


        [Required]
        [Display(Name = "Año")]
        public string Año { get; set; }


        [Display(Name = "ImgRuta")]
        public string ImgRuta { get; set; }
    }
}