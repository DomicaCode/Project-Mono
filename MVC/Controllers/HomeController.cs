using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Data;
using Data.Entities;
using Data.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public HomeController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        public IActionResult Make()
        {
            var data = _vehicleService.GetMake(0, 10);

            return View(data);
        }

        [HttpGet]
        public IActionResult Model()
        {
            var data = _vehicleService.GetModel(0, 10);

            return View(data);
        }

        [HttpGet]
        public IActionResult CreateMake()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMake(VehicleDto vehicle)
        {
            _vehicleService.InsertMake(vehicle);

            return RedirectToAction("Make");
        }

        [HttpGet]
        public IActionResult CreateModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateModel(VehicleDto vehicle)
        {
            _vehicleService.InsertModel(vehicle);

            return RedirectToAction("Model");
        }

        /*
        [HttpGet]
        public IActionResult DeleteMake(int id)
        {
            var data = _dbContext.VehicleMake.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        */


        //Ove dvije metode sam morao razdvojiti, jer da obrises Make moras obrisati Model gdje je tamo foreign key, 
        // a ne mozes obrisati u istoj metodi jer se tek izvrsi nakon sto sve prode
        public IActionResult DeleteMake(int id)
        {
            VehicleDto vehiclemodel = _vehicleService.GetModelByMakeId(id);

            if (vehiclemodel != null)
            {
                _vehicleService.DeleteModel(vehiclemodel);
                DeleteMakeModel(id);
            }
            else
            {
                DeleteMakeModel(id);
            }


            return RedirectToAction("Make");

        }

        public void DeleteMakeModel(int id)
        {
            VehicleDto vehicle = _vehicleService.GetMakeById(id);
            _vehicleService.DeleteMake(vehicle);
        }

        public IActionResult DeleteModel(int id)
        {
            VehicleDto vehiclemodel = _vehicleService.GetModelById(id);
            _vehicleService.DeleteModel(vehiclemodel);

            return RedirectToAction("Model");

        }

        [HttpGet]
        public IActionResult EditMake(int id)
        {
            return View(_vehicleService.GetMakeById(id));
        }

        [HttpPost]
        public IActionResult EditMake(int id, VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            _vehicleService.UpdateMake(vehicle);

            return RedirectToAction("Make");
        }

        [HttpGet]
        public IActionResult EditModel(int id)
        {
            return View(_vehicleService.GetModelById(id));
        }

        [HttpPost]
        public IActionResult EditModel(int id, VehicleDto vehicle)
        {
            //vehicle = _vehicleService.GetMakeById(id);
            _vehicleService.UpdateModel(vehicle);

            return RedirectToAction("Model");
        }

        public IActionResult DetailsMake(int id)
        {
            return View(_vehicleService.GetMakeById(id));
        }

        public IActionResult DetailsModel(int id)
        {
            return View(_vehicleService.GetModelById(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
