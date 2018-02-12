using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IDisplay.DAL;
using IDisplay.Models;

namespace IDisplay.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        private readonly IDisplayContext _context = new IDisplayContext();
     

        [HttpGet]
        public ActionResult Create()
        {
            

            var prodCategories = _context.ProductCategories;
            ViewBag.CategoryList = prodCategories;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
           
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.ProductCategories.Add(productCategory);
                        _context.SaveChanges();
                        TempData["SuccessMeassage"] = "Success !";
                        TempData["SuccessMeassageContent"] =
                            "Product details saved sucessfully";

                        return RedirectToAction("Create");

                    }

                    catch (DataException /* dex */)
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
            
            ModelState.Clear();
            return View(productCategory);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            ProductCategory productCategory = _context.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            ProductCategory productCategory = _context.ProductCategories.Find(id);
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
            ViewBag.SuucessMsg = "Deleted Successfully";

            return RedirectToAction("Create");
        }
    }
}