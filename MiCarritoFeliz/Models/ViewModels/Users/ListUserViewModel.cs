using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiCarritoFeliz.Models.ViewModels.Users
{
    public class ListUserViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}