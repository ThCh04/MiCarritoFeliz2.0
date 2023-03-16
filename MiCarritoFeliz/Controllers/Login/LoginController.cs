using MiCarritoFeliz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiCarritoFeliz.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("LoginView");
        }

        public ActionResult Log(string user, string passwd)
        {

            try
            {
                using (DBMVCSCEntities db = new DBMVCSCEntities())
                {
                    var lst = from d in db.USERS
                              where d.Email == user
                                 && d.Password == passwd
                                 && d.idStatus == 1
                              select d;
                    if (lst.Count() > 0)
                    {
                        Session["User"] = lst.FirstOrDefault();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Revisa usuario y password...");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content($"Ha ocurrido un error en el servidor: {ex}");
            }
        }

    }
}