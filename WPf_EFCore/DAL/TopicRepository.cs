using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPf_EFCore.Model;

namespace WPf_EFCore.DAL
{
    public class TopicRepository : ITopicRepository
    {
        
        private readonly TopicContext _context;

        public TopicRepository(TopicContext context)
        {
            _context = context;
        }

        public IEnumerable<Topic> GetAll()
        {
            return _context.Topics;
        }

        public Topic GetById(int id)
        {
            return _context.Topics.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Topic topic)
        {
            _context.Topics.Update(topic);
        }

        public void Create(Topic topic)
        {
            _context.Topics.Add(topic);
        }
    }
}
