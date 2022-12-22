using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SC.Context;
using SC.Models;
using SC.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Controllers
{
    public class KeluhanController : Controller
    {
        KeluhanRepository KeluhanRepository;
        ResponKeluhanRepository ResponKeluhanRepository;
        myContext myContext;

        public KeluhanController(KeluhanRepository keluhanRepository, ResponKeluhanRepository ResponKeluhanRepository, myContext myContext)
        {
            this.KeluhanRepository = keluhanRepository;
            this.ResponKeluhanRepository = ResponKeluhanRepository;
            this.myContext = myContext;
        }

        // GET ALL
        public IActionResult Index()
        {
           int iduser = (int)HttpContext.Session.GetInt32("iduser");
   
                var data = myContext.Keluhans.Include(x => x.User.ProfilMahasiswa).Where(x => x.UserId.Equals(iduser)).ToList();
                //var data = KeluhanRepository.keluhanmhs();
                ViewBag.respon = ResponKeluhanRepository;
                ViewBag.iduser = iduser;
                return View(data);
            
        }

        

        //GET BY ID
        public IActionResult Details(int id)
        {
            var data = KeluhanRepository.Get(id);
            return View(data);
        }

        // CREATE 
        // GET
        //[Authorize("Mhs")]
        public IActionResult Create()
        {
            ViewBag.daten = DateTime.Now.ToString("yyyy-MM-dd");
            
            ViewBag.iduser = HttpContext.Session.GetInt32("iduser");
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Keluhan keluhan)
        {
            if (ModelState.IsValid)
            {

                var result = KeluhanRepository.Post(keluhan);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // UPDATE
        // GET
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var data = myContext.Keluhans.Include(x => x.User.ProfilMahasiswa).Where(x => x.Id.Equals(id)).ToList();
            //var data = KeluhanRepository.keluhanmhs();
            //ViewBag.respon = ResponKeluhanRepository;
            //ViewBag.iduser = iduser;
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Keluhan keluhan)
        {
            if (ModelState.IsValid)
            {
                var result = KeluhanRepository.Put(id, keluhan);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // DELETE
        // GET
        public ActionResult Remove(int id)
        {
            var data = KeluhanRepository.Get(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(Keluhan keluhan)
        {
            var result = KeluhanRepository.Remove(keluhan);
            if (result > 0)
                return RedirectToAction("Index");
            return View();
        }
    }
}
