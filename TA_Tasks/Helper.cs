using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Tasks.PageObjects;

namespace TA_Tasks
{
    static class Helper
    {
        public static void FillForm(Dictionary<string, string> d)
        {
            BbcSubmitStoryPage Submit = new BbcSubmitStoryPage();
            BbcSubmitQuestionPage Question = new BbcSubmitQuestionPage();

            if (d.ContainsKey("Comments"))
            {
                Submit.FillForm(d);
            }
            else if (d.ContainsKey("What questions would you like us to investigate?"))
            {
                Question.FillForm(d);
            }
        }

        public static bool CheckForm(string pagetype)
        {
            BbcSubmitStoryPage Submit = new BbcSubmitStoryPage();
            BbcSubmitQuestionPage Question = new BbcSubmitQuestionPage();

            if (pagetype == "Story")
            {
                return Submit.CheckForm();
            }
            else if (pagetype == "Question")
            {
                return Question.CheckForm();
            }
            else throw new NotImplementedException();
        }
    }
}
