using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsQuery;
using CsQuery.Mvc;
using Parser.Models;

namespace Parser.Controllers
{
    public class HomeController : Controller
    {
        DataContext _db = new DataContext();

        public ActionResult Index()
        {
            return View();
        } 
        
        [HttpPost]
        public string Parse()
        {
            //try
            //{
            //  return "succesconnection";
            //}
            //catch
            //{
            //    return "failconnection";
            //}
            return "succesconnection";
        }
    }
}