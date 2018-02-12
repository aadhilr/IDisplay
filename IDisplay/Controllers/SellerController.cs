using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDisplay.DAL;
using IDisplay.Models;

namespace IDisplay.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        private readonly IDisplayContext _context = new IDisplayContext();
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Profile()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.userDetails = _context.Sellers.Find(Int32.Parse(Session["UserID"].ToString()));
            return View();
        }
    }
}