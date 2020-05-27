using System;
using System.Collections.Generic;
using System.Text;

namespace WPf_EFCore.DAL
{
    public interface IUnitOfWork
    {

            public ITopicRepository TopicRepository { get; }
            void Save();
        
    }
}
