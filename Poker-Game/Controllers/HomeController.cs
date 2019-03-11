using Poker_Game.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Poker_Game.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GameService game = new GameService();
            game.Orquestrador();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}