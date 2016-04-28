using Glosowanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Glosowanie.Controllers
{
    public class DupaController : Controller
    {

       [HttpGet]
        public ActionResult SolvePool(Pool model)
        {

            #region temporaryIn
            string txt = "Czyje takie brzydkie dziecko?";

            List<Answer> tempAns = new List<Answer>();

            Answer a = new Answer()
            {
                AnswerText = "niczyje",
                NumberOfChoses = 0
            };

            for (int i = 0; i < 3; i++)
            {
                tempAns.Add(a);

            }
            List<Question> questions = new List<Question>();
            Question q = new Question() { QuestionText = txt, Answers = tempAns };
            for (int i = 0; i < 10; i++)
            {
                questions.Add(q);
            }
            Pool model2 = new Pool()
            {
                Title = "tempTittle",
                Questions = questions
            };
            #endregion


            return View(model2);
        }
            
        
    }
}