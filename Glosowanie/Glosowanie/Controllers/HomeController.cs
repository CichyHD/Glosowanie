using AutoMapper;
using Glosowanie.Domain.Providers;
using Glosowanie.Domain.Services;
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
        IPoolService _poolService;

        public HomeController(IExcelProvider excelProvider, IPoolService _poolService)
        {
            this.excelProvider = excelProvider;
            this._poolService = _poolService;
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
            if (ModelState.IsValid)
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
                        numberOfTokens = Convert.ToInt32(poolOptionsModel.NumberOfTokens.Replace(" ", ""));
                    }
                }
                catch (Exception)
                {
                    numberOfTokens = 200;
                }

                for (int i = 0; i < model.Questions.Count(); i++)
                {
                    if (String.IsNullOrEmpty(model.Questions[i].QuestionText))
                    {
                        model.Questions.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        for (int j = 0; j < model.Questions[i].Answers.Count(); j++)
                        {
                            if (String.IsNullOrEmpty(model.Questions[i].Answers[j].AnswerText))
                            {
                                model.Questions[i].Answers.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }

                List<string> Tokens = new List<string>();
                string token;

                model.Tokens = new List<Token>();

                for (int i = 0; i < numberOfTokens; i++)
                {
                    token = Guid.NewGuid().ToString().Substring(0, 13);
                    model.Tokens.Add(new Token() { TokenValue = token, Used = false });
                    Tokens.Add(token);
                }

                var excelFile = excelProvider.CreateExcelFile(Tokens);

                Mapper.CreateMap<Pool, Glosowanie.Entity.Models.Pool>();
                Mapper.CreateMap<Question, Glosowanie.Entity.Models.Question>();
                Mapper.CreateMap<Token, Glosowanie.Entity.Models.Token>();
                Mapper.CreateMap<Answer, Glosowanie.Entity.Models.Answer>();

                _poolService.Create(Mapper.Map<Glosowanie.Entity.Models.Pool>(model));

            }
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