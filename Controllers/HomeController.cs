using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public object obj { get; private set; }

        //[HttpPost]
        public ActionResult Index()
        {
            DBconnection obj = new DBconnection();
            string locationid = Request.QueryString["locationid"];
            string salesdate = Request.QueryString["salesdate"];
            var valus = obj.DBconnect(locationid, salesdate);

            ViewBag.cus = valus;
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(string locationid)
        //{
        //    DBconnection obj = new DBconnection();
        //    var valus = obj.DBconnect("0001");

        //    ViewBag.cus = valus;
        //    return View();
        //}

        public ActionResult Report()
        {

            DBconnection obj = new DBconnection();
            var valus = obj.DBconnect("","");

            ViewBag.cus = valus;
            return View();
        }

        public ActionResult About()
        {
            DBconnection obj = new DBconnection();
            string cardno = Request.QueryString["cardno"];
            string salesdate = Request.QueryString["salesdate"];
            var valus = obj.DBconnectCardTran(cardno, salesdate);

            ViewBag.cus = valus;
            return View();
        }

    }
}