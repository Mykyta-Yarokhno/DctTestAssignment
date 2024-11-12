using DctTestAssignment.Services;
using DctTestAssignment.ViewModels;
using DctTestAssignment.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DctTestAssignment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<CoinCapApiService>();
            services.AddSingleton<CoinMarketCapApiService>();
            services.AddSingleton<CryptoDataService>();

            services.AddScoped<MainWindowViewModel>();
            services.AddTransient(typeof(MainWindow));
        }
    }

}
