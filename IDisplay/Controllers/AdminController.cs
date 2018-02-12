using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDisplay.DAL;
using IDisplay.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace IDisplay.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
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
        public ActionResult ProductDetails()
        {

            var products = _context.Products;
            ViewBag.ProductList = products;
            return View();

        }

        [HttpGet]
        public ActionResult SellerDetails()
        {
            IEnumerable<Seller> sellers = _context.Sellers;
            ViewBag.sellerDetails = sellers;

            return View();



        }

        [HttpGet]
        public ActionResult active(int? id)
        {
            var seller = _context.Sellers.Find(id);
            seller.Active = true;
            _context.SaveChanges();
            return RedirectToAction("SellerDetails");
        }

        [HttpGet]
        public ActionResult deactive(int? id)
        {
            var seller = _context.Sellers.Find(id);
            seller.Active = false;
            _context.SaveChanges();
            return RedirectToAction("SellerDetails");
        }

        public ActionResult ProductList()
        {

            return View();
        }
    }
}