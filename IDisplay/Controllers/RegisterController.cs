using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDisplay.DAL;
using IDisplay.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IDisplay.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IDisplayContext _context = new IDisplayContext(); 

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Seller seller)
        {
            ModelState.Remove("Role");
            ModelState.Remove("Active");
            if (_context.Sellers.Any(a => a.Username.Equals(seller.Username)))
            {
                ViewBag.ErrorMsg = "Record already exists, Try with a new username";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Sellers.Add(seller);
                        _context.SaveChanges();
                        ViewBag.SuccessMsg = "Successfully Registered";
                        return RedirectToAction("Create");

                    }

                    catch (DataException)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("",
                            "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    }
                }
                else
                {
                    TempData["ErrorMeassage"] = "Error !";
                    TempData["ErrorMeassageContent"] =
                        "product details couldn't save, Please try again.";
                }
            }
            ModelState.Clear();

            return View(seller);
        
   
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Seller seller)
        {
            var username = seller.Username;
            var pwd = seller.Password;

            
            var user = (from s in _context.Sellers
                        where s.Role =="Admin" || s.Role == "Seller"
                select s).ToArray();
            

        
            for (int i = 0; i < user.Length; i++)
            {
                if (user[i].Username == username && user[i].Password == pwd &&
                    user[i].Role == "Admin")
                {
                    Session["UserID"] = user[i].SellerId;
                    Session["Username"] = user[i].Username;
                    return RedirectToAction("Index", "Admin");
                }

               
                else 
                  if (user[i].Username == username && user[i].Password == pwd &&
                    user[i].Role == "Seller" && user[i].Active==true)

                {
                    Session["UserID"] = user[i].SellerId;
                    Session["Username"] = user[i].Username;
                    return RedirectToAction("Index", "Seller");
                }

               
            }
            ViewBag.ErrorMessage = "Invalid Username or password";
            return View();
        }

        [HttpGet]
        public ActionResult Location()
        {

            var seller = _context.Sellers;
            var loc = Json(JsonConvert.SerializeObject(seller.ToList()), JsonRequestBehavior.AllowGet);
            ViewBag.location = seller;
            return View();

        }

        [HttpGet]
        public JsonResult getLocation()
        {
            var seller = from s in _context.Sellers
                         where s.Role != "Admin"
                         select s;
            var loc = Json(JsonConvert.SerializeObject(seller.ToList()), JsonRequestBehavior.AllowGet);
            return loc;
        }

    }
}