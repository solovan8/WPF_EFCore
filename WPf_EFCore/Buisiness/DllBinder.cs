using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WPf_EFCore.Buisiness.Interfaces;
using WPf_EFCore.Buisiness.Services;

namespace WPf_EFCore.Buisiness
{
    public static class DllBinder
    {
        public static IServiceCollection BindBll(this IServiceCollection services)
        {
            services.AddSingleton<ITopicService, TopicService>();
            services.AddSingleton<IQuizService, QuizService>();

            return services;
        }
    }
}
