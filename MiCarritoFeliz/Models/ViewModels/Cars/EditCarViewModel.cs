using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MiCarritoFeliz.Models.ViewModels.Cars
{
    public class EditCarViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Brand")]

        public string Marca { get; set; }
        [Display(Name = "Image Route")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Año { get; set; }

        [Required]
        [Display(Name = "Year")]
        public string ImgRuta { get; set; }
    }
}