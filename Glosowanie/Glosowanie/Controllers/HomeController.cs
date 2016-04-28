using Glosowanie.Domain.Providers;
using Glosowanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Glosowanie.Controllers
{
    public class HomeController : Controller
    {
        IExcelProvider excelProvider;

        public HomeController(IExcelProvider excelProvider)
        {
            this.excelProvider = excelProvider;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Token model = new Token();

            return View(model);
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
            int numberOfQuestions;
            int numberOfAnswers;

            PoolOptions poolOptionsModel = (PoolOptions)Session["PoolOptions"];

            try
            {
                if (String.IsNullOrEmpty(poolOptionsModel.NumberOfQuestions))
                {
                    throw new Exception("Object is empty");
                }
                else
                {
                    numberOfQuestions = Convert.ToInt32(poolOptionsModel.NumberOfQuestions.Replace(" ", ""));
                }
            }
            catch (Exception)
            {
                numberOfQuestions = 5;
            }

            try
            {
                if (String.IsNullOrEmpty(poolOptionsModel.NumberOfAnswers))
                {
                    throw new Exception("Object is empty");
                }
                else
                {
                    numberOfAnswers = Convert.ToInt32(poolOptionsModel.NumberOfAnswers.Replace(" ", ""));
                }
            }
            catch (Exception)
            {
                numberOfAnswers = 2;
            }

            Pool model = new Pool();

            model.Questions = new List<Question>();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Question temp = new Question();
                temp.Answers = new List<Answer>();
                for (int j = 0; j < numberOfAnswers; j++)
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
            int numberOfTokens;

            PoolOptions poolOptionsModel = (PoolOptions)Session["PoolOptions"];

            try
            {
                if (String.IsNullOrEmpty(poolOptionsModel.NumberOfTokens))
                {
                    throw new Exception("Object is empty");
                }
                else
                {
                    numberOfTokens = Convert.ToInt32(poolOptionsModel.NumberOfTokens.Replace(" ",""));
                }
            }
            catch (Exception)
            {
                numberOfTokens = 200;
            }

            List<string> Tokens = new List<string>();
            string token;

            model.Tokens = new List<Token>();

            for (int i = 0; i < numberOfTokens; i++)
            {
                token = Guid.NewGuid().ToString().Substring(0, 13);
                model.Tokens.Add(new Token() { TokenValue = token, Used = false});
                Tokens.Add(token);
            }

            var excelFile = excelProvider.CreateExcelFile(Tokens);

            return View(model);
        }

        [HttpGet]
        public ActionResult InitialisePool()
        {
            PoolOptions model = new PoolOptions();

            return View(model);
        }

        [HttpPost]
        public ActionResult InitialisePool(PoolOptions model)
        {
            Session["PoolOptions"] = model;

            return RedirectToAction("CreatePool");
        }
    }
}