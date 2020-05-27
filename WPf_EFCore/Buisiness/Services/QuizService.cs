using System;
using System.Collections.Generic;
using System.Text;
using WPf_EFCore.Buisiness.Interfaces;
using WPf_EFCore.Model;

namespace WPf_EFCore.Buisiness.Services
{
    class QuizService:IQuizService
    {
        //Random random;
        
        //Question randomQuestion;
        public QuizService() { }
        //    Random random)
        //{
        //    this.random = random;
            
        //}
        public Question RandomQuestion(Topic topic)
        {
            //int rq = topic.Questions[0]//random.Next(0, topic.Questions.Count);
            var randomQuestion = topic.Questions[0];
            return randomQuestion;
        }
        public List<Answer> Quiz(Topic topic)
        {
            
            List<Answer> temporaryAnswers = RandomQuestion(topic).Answers;
            var randanswers = new List<Answer>();

            for (int i = 0; i < 4; i++)
            {
                int ra = i;
                //int ra = random.Next(0, temporaryAnswers.Count);
                randanswers.Add(RandomQuestion(topic).Answers[ra]);
                temporaryAnswers.Remove(temporaryAnswers[ra]);
            }
            return randanswers;

        }
       
    }
}
