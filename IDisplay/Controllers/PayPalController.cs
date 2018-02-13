using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDisplay.Migrations;
using IDisplay.Models;

namespace IDisplay.Controllers
{
    public class PayPalController : Controller
    {
        // GET: PayPal
        public ActionResult RedirectFromPaypal()
        {
            return View();
        }

        public ActionResult CancelFromPaypal()
        {
            return View();
        }

        public ActionResult NotifyFromPaypal()
        {
            return View();
        }

        public ActionResult ValidateCommand(string product, string totalPrice)
        {
            bool useSandBox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPalModel(useSandBox);
            paypal.item_name = product;
            paypal.amount = totalPrice;

            return View(paypal);
        }
    }
}