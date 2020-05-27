using System;
using System.Collections.Generic;
using System.Text;
using WPf_EFCore.Model;

namespace WPf_EFCore.Buisiness.Interfaces
{
    interface ITopicService
    {
        IEnumerable<Topic> GetAllTopics();
        Topic GetTopicById(int id);
        Topic Create(string text);
        void CreateTopic(Topic topic);
        Topic GetTopicByName(string name);
        void CreateQuestion(Topic topic, string questionText, string trueA, string falseA1, string falseA2, string falseA3);

    }
}
