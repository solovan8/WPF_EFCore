using System;
using System.Collections.Generic;
using System.Text;

namespace WPf_EFCore.Model
{
    public class Topic
    {
        public Topic()
        {
        }

        public Topic( string text)
        {
            Text = text;
            Questions = new List<Question>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public List<Question> Questions { get; set; }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

    }
}
