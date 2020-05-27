using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace WPf_EFCore.DAL
{
    public static class DalBinder
    {
        public static IServiceCollection BindDal(this IServiceCollection services)
        {
            services.AddSingleton<ITopicRepository, TopicRepository>();
            
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<TopicContext>(options =>
                options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TopicDb; Integrated Security = True;"));//ConfigurationManager.ConnectionStrings["Topic"].ConnectionString));

            return services;
        }
    }
}
