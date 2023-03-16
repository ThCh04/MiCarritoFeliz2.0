using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiCarritoFeliz.Models.ViewModels.Cars
{
    public class ListCarViewModel
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string ImgRoute { get; set; }
    }
}