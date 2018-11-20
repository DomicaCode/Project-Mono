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
        private readonly ProjectDbContext _dbContext;


        public HomeController(IVehicleService vehicleService, ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
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
            /*
            ProjectDbContext db = new ProjectDbContext();

            var test = db.VehicleMake;
            foreach (VehicleMakeEntity p in test)
            {
                Console.WriteLine(p);
            }
            */

            var data = _vehicleService.GetMake(0, 10, (p => p.Id));

            return View(data);
        }

        [HttpGet]
        public IActionResult Model()
        {
            var data = _vehicleService.GetModel(0, 10, (p => p.Id)).ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult CreateMake()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMake(VehicleMakeEntity vehicle)
        {
            _vehicleService.InsertMake(vehicle);

            return View();
        }

        [HttpGet]
        public IActionResult CreateModel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateModel(VehicleModelEntity vehicle)
        {
            _vehicleService.InsertModel(vehicle);

            return View();
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
            VehicleModelEntity vehiclemodel = _dbContext.VehicleModel.Where(x => x.MakeId == id).FirstOrDefault();
            _vehicleService.DeleteModel(vehiclemodel);
            DeleteMakeModel(id);

            return RedirectToAction("Index");

        }

        public void DeleteMakeModel(int id)
        {
            VehicleMakeEntity vehicle = _dbContext.VehicleMake.Where(x => x.Id == id).FirstOrDefault();
            _vehicleService.DeleteMake(vehicle);
        }

        public IActionResult DeleteModel(int id)
        {
            VehicleModelEntity vehiclemodel = _dbContext.VehicleModel.Where(x => x.Id == id).FirstOrDefault();
            _vehicleService.DeleteModel(vehiclemodel);

            return RedirectToAction("Index");

        }
        
        [HttpGet]
        public IActionResult EditMake(int id)
        {
            return View(_dbContext.VehicleMake.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult EditMake(int id, VehicleMakeEntity vehicle)
        {
            vehicle = _dbContext.VehicleMake.Where(x => x.Id == id).FirstOrDefault();
            _vehicleService.UpdateMake(vehicle);

            return RedirectToAction("Index");
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
