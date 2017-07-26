using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShuiPlat.Core.Events;
using EShuiPlat.Entity;
using EShuiPlat.EntityFrameWork.SQLSERVER;

namespace EShuiPlat.WEB.Controllers
{
    public class HomeController : Controller
    {

        public Order AddPrice(Order ord)
        {
            ord.Price += 200;
            return ord;
        }
        public IActionResult Index()
        {
            DBContextSQLSERVER dbc = new DBContextSQLSERVER();
            Order md = new Order();
            md.Price = 100;
            md.BookNo = "123";
            dbc.Orders.Add(md);
            dbc.SaveChanges();
            BusinessLink<Order> bus = new BusinessLink<Order>();
            bus.BusinessFunc += AddPrice;
            bus.BusinessFunc += AddPrice;
            bus.BusinessFunc += AddPrice;
            bus.BusinessFunc += AddPrice;
            bus.BusinessFunc += AddPrice;
            bus.BusinessFunc += AddPrice;
            
          var pp=  bus.On_BusinessFunc(md);
            var p = md;
           // string xmlstr = p.ToSQL();
            string str = "";
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
