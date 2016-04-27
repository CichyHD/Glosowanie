using Glosowanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Glosowanie.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Token model)
        {
            if (true)
            {
                //TO DO
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreatePool()
        {
            Pool model = new Pool();

            model.Questions = new List<Question>();
            for (int i = 0; i < 10; i++)
            {
                Question temp = new Question();
                temp.Answers = new List<Answer>();
                for (int j = 0; j < 5; j++)
                {
                    temp.Answers.Add(new Answer());
                }
                model.Questions.Add(temp);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePool(Pool model)
        {
            return View();
        }
    }
}