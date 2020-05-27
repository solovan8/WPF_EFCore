using System;
using System.Collections.Generic;
using System.Text;

namespace WPf_EFCore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITopicRepository TopicRepository { get; }
        private readonly TopicContext context;

        public UnitOfWork(ITopicRepository topicRepository, TopicContext _context)
        {
            TopicRepository = topicRepository;
            context = _context;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
