using System;
using System.Collections.Generic;
using System.Text;
using WPf_EFCore.Buisiness.Services;
using WPf_EFCore.Model;

namespace WPf_EFCore.Buisiness.Interfaces
{
    public interface IQuizService
    {
        
        public Question RandomQuestion(Topic topic);
        List<Answer> Quiz(Topic topic);
       
    }
}
