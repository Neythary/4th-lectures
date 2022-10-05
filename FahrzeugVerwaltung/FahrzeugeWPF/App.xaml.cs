using FahrzeugDatenbank;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FahrzeugeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ServiceCollection services = new ServiceCollection();

            services.AddScoped<IKonfigurationsLeser>(sp => new KonfigurationsLeser((IConfiguration)configuration));
            services.AddScoped(sp => new FahrzeugRepository(sp.GetRequiredService<IKonfigurationsLeser>().LiesDatenbankVerbindungZurMariaDB()));
            services.AddScoped<FahrzeugeModell>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>();

            ServiceProvider = services.BuildServiceProvider();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            this.MainWindow = ServiceProvider.GetService<MainWindow>();
            this.MainWindow.DataContext = ServiceProvider.GetService<MainWindowViewModel>();
            this.MainWindow.Show();
        }

        private string GetConnectionString()
        {
            return "Server=localhost;User ID=root;Password=root;Database=FahrzeugDB;";
        }
    }
}
