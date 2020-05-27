using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPf_EFCore.Buisiness.Interfaces;
using WPf_EFCore.DAL;
using WPf_EFCore.Model;

namespace WPf_EFCore.Buisiness.Services
{
    class TopicService : ITopicService
    {
       
        private readonly IUnitOfWork unit;
        
        
        public TopicService(IUnitOfWork _unit)
        {
            unit = _unit;
        }
        public void CreateTopic(Topic topic)
        {

            unit.TopicRepository.Create(topic);
            unit.Save();
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            return unit.TopicRepository.GetAll();
        }

        public Topic GetTopicById(int id)
        {
            return unit.TopicRepository.GetById(id);
        }
        public Topic GetTopicByName(string name)
        {
            return unit.TopicRepository.GetAll().FirstOrDefault(p => p.Text == name);
        }
        public void CreateQuestion(Topic topic, string questionText, string trueA, string falseA1, string falseA2, string falseA3)
        {
            var question = new Question(questionText);
            topic.AddQuestion(question);
            var ta = new Answer(trueA);
            var fa1 = new Answer(falseA1);
            var fa2 = new Answer(falseA2);
            var fa3 = new Answer(falseA3);
            question.AddAnswer(ta);
            question.AddAnswer(fa1);
            question.AddAnswer(fa2);
            question.AddAnswer(fa3);

        }

        public Topic Create(string text)
        {
            var topic = new Topic(text);
            return topic;
        }
    }
}
