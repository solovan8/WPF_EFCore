using System;
using System.Collections.Generic;
using System.Text;

namespace WPf_EFCore.Model
{
    public class Question
    {
       public int id { get; set; }
       public string text { get; set; }
      
        public List<Answer> Answers; 
        public Question(string text)
        {
            this.text = text;
            Answers = new List<Answer>(4);
        }
        public Question() { }
        public void AddAnswer(Answer answer)
        {
            if (Answers.Count == 0)
            {
                answer.IsTrue = true;
            }
            Answers.Add(answer);
        }
    }
}
