using MiCarritoFeliz.Models;
using MiCarritoFeliz.Models.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiCarritoFeliz.Controllers.Cars
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult GetCars()
        {

            List<ListCarViewModel> list = null;

            using (DBMVCSCEntities db = new DBMVCSCEntities())
            {
                list = (from car in db.AUTOS
                        where car.miEstatus == 1
                        orderby car.Marca

                        select new ListCarViewModel
                        {
                            CarId = car.IDauto,
                            Brand = car.Marca,
                            Model = car.Modelo,
                            Year = car.Anio,
                            ImgRoute = car.ImgRuta

                        }).ToList();
            }

            return View("ShowCars", list);
        }


        public ActionResult CreateCar()
        {
            return View("AddCars");
        }

        [HttpPost]

        public ActionResult CreateCar(AddCarViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCars", vm);
            }

            using (var db = new DBMVCSCEntities())
            {
                AUTO carro = new AUTO
                {
                    miEstatus = 1,
                    Marca = vm.Marca,
                    Anio = vm.Año,
                    ImgRuta = vm.ImgRuta,
                    Modelo = vm.Modelo,
                };

                db.AUTOS.Add(carro);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Car/GetCars"));
        }

        [HttpPost]

        public ActionResult DeleteCars(int id)
        {
            using (var db = new DBMVCSCEntities())
            {
                var selectedCar = db.AUTOS.Find(id);
                selectedCar.miEstatus = 2;
                db.Entry(selectedCar).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

        public ActionResult EditCar(int id)
        {
            EditCarViewModel vm = new EditCarViewModel();
            using (var db= new DBMVCSCEntities())
            {
                var car = db.AUTOS.Find(id);
                vm.Modelo = car.Modelo;
                vm.Id = car.IDauto;
                vm.Marca = car.Marca;
                vm.ImgRuta = car.ImgRuta;
                vm.Año = car.Anio;
            }

            return View("EditCars",vm);
        }

        [HttpPost]

        public ActionResult EditCar(EditCarViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            using (var db = new DBMVCSCEntities())
            {
                var carro = db.AUTOS.Find(vm.Id);
                carro.Modelo = vm.Modelo;
                carro.Anio = vm.Año;
                carro.ImgRuta = vm.ImgRuta;
                carro.Marca = vm.Marca;

                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Car/GetCars"));
        }

    }
}