using MiCarritoFeliz.Models.ViewModels.Users;
using MiCarritoFeliz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiCarritoFeliz.Controllers.Users
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            List<ListUserViewModel> lst = null;

            using (DBMVCSCEntities db = new DBMVCSCEntities())
            {
                lst = (from users in db.USERS
                       where users.idStatus == 1
                       orderby users.Email

                       select new ListUserViewModel
                       {
                           Email = users.Email,
                           UserId = users.ID,
                           Pass = users.Password
                       }
                       ).ToList();
            }

            return View("Show", lst);
        }

        [HttpPost]

        public ActionResult CreateUser(AddUsersViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            using (var db = new DBMVCSCEntities())
            {
                USER user = new USER
                {
                    idStatus = 1,
                    Email = vm.Email,
                    Password = vm.Password
                };

                db.USERS.Add(user);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Users/GetUsers"));
        }

        public ActionResult CreateUser()
        {

            return View("Add");
        }

        public ActionResult EditUser(int id)
        {
            EditUsersViewModel vm = new EditUsersViewModel();
            using (var db = new DBMVCSCEntities())
            {
                var user = db.USERS.Find(id);
                vm.Email = user.Email;
                vm.UserId = user.ID;
            }

            return View("Edit", vm);
        }

        [HttpPost]
        public ActionResult EditUser(EditUsersViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", vm);
            }

            using (var db = new DBMVCSCEntities())
            {
                var user = db.USERS.Find(vm.UserId);
                user.Email = vm.Email;


                if (!String.IsNullOrEmpty(vm.Password))
                {
                    user.Password = vm.Password;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Users/GetUsers"));
        }

        [HttpPost]

        public ActionResult DeleteUser(int id)
        {
            using (var db = new DBMVCSCEntities())
            {
                var user = db.USERS.Find(id);
                user.idStatus = 3;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}