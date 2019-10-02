using Autofac;
using AutofacModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Interfaces.Recipient;
using ViewModelLayer.Models;
using ViewModelLayer.Services;
using ViewModelLayer.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainer AppContainer;
        private readonly IBillService billService;
        private readonly IRecipientService recipientService;
        public MainWindow()
        {
            SetupContainer();
            recipientService.CreateRecepient(new Recipient()
            {
                Account = "43749928388829",
                Active = true,
                Address = "Bulowice ulica błotna numer zachlapany",
                CompanyName = "Tauron",
                CustomerServiceUrl = "www.dupa.pl"
            });
        }

        private void SetupContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DbAccessModule());
            builder.RegisterModule(new ViewModelLayerModule());
            BuildupContainer(builder);
            var container = builder.Build();
            AppContainer = container;
           
        }

        private void BuildupContainer(ContainerBuilder builder)
        {
            builder.RegisterType<RecipientService>().As<IRecipientService>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
