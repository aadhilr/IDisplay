using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDisplay.DAL;
using IDisplay.Models;
using Newtonsoft.Json;

namespace IDisplay.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDisplayContext _context = new IDisplayContext();

        public ActionResult Index()
        {
            var id = Session["UserID"].ToString();
            int userID = Int32.Parse(id);
            var products = (from k in _context.Products
                            where k.UserId == userID
                            select k);
            return View(products);
        }

        [HttpGet]
        public ActionResult GetProducts(int? productCategoryId)
        {
            var products = (from p in _context.Products
                            where p.ProductCategoryId == productCategoryId
                            select p);
            ViewBag.productDetails = products;
            return View();

        }

        [HttpGet]
        public JsonResult GetProductListJsonResult()
        {
            IEnumerable<Product> products = _context.Products;
            return Json(JsonConvert.SerializeObject(products.ToList()), JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //create a new product
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase productImg)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
           
                try
                {
                    if (productImg != null)
                    {
                        var fileName = Path.GetFileName(productImg.FileName);
                        string mappedPath = ConfigurationManager.AppSettings["ItemImageFilePath"];
                        var directoryToSave = Server.MapPath(Url.Content(mappedPath));

                        var pathToSave = Path.Combine(directoryToSave, fileName);
                        productImg.SaveAs(pathToSave);
                        product.ImageUrl = fileName;

                    }

                    _context.Products.Add(product);
                    _context.SaveChanges();
                    ViewBag.SuccessMsg = "Successfully Added";
                    return RedirectToAction("Create", "Product");

                }

                catch (DataException /* dex */)
                {
                    ModelState.AddModelError("",
                        "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            

            return View(product);
        }

        [HttpGet]
        public JsonResult GetUserListJsonResult()
        {
            IEnumerable<Seller> users = _context.Sellers;
            return Json(JsonConvert.SerializeObject(users.ToList()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductCategoryListJsonResult()
        {
            IEnumerable<ProductCategory> prodCategories = _context.ProductCategories;
            return Json(JsonConvert.SerializeObject(prodCategories.ToList()), JsonRequestBehavior.AllowGet);
        }

    }
}