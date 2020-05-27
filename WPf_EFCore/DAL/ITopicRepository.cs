using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPf_EFCore.Model;

namespace WPf_EFCore.DAL
{
    public interface ITopicRepository
    {
        public IEnumerable<Topic> GetAll();

        public Topic GetById(int id);

        public void Update(Topic animal);

        public void Create(Topic animal);
    }
}
