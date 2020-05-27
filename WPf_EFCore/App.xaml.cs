using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPf_EFCore.Buisiness;
using WPf_EFCore.Buisiness.Interfaces;
using WPf_EFCore.DAL;
using WPf_EFCore.VM;

namespace WPf_EFCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);

            ServiceProvider = service.BuildServiceProvider();

            DisplayRootRegistry.RegisterWindowType<TopicViewModel, MainWindow>();
           
        }
        public static IServiceProvider ServiceProvider { get; private set; }

        public DisplayRootRegistry DisplayRootRegistry { get; } = new DisplayRootRegistry();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            serviceCollection.BuildServiceProvider();

            
            var viewModel = new TopicViewModel(ServiceProvider.GetService<ITopicService>(),
                ServiceProvider.GetService<IQuizService>());


            DisplayRootRegistry.ShowModalPresentation(viewModel);
            Shutdown();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(MainWindow));
            services.BindDal();
            services.BindBll();
        }
    }
}
