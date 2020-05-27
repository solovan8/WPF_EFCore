using System;
using System.Collections.Generic;
using System.Text;

namespace WPf_EFCore.Model
{
    public class Answer
    {
        public int id { get; set; }
        public string Text { get; set; }
        public bool IsTrue { get; set; }
        public Answer() { }
        public Answer(string text)
        {
            this.Text = text;
        }
    }
}
