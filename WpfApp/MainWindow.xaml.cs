using Autofac;
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
using ViewModelLayer.Interfaces.Recipient;
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

        private readonly IRecepientService recipientService;
        public MainWindow()
        {
            SetupContainer();
            var recipientList = this.recipientService.GetActiveRecipients();
            this.DataContext = new MainViewModel();
        }

        private void SetupContainer()
        {
            var builder = new ContainerBuilder();
            BuildupContainer(builder);
            var container = builder.Build();
            AppContainer = container;
        }

        private void BuildupContainer(ContainerBuilder builder)
        {
            builder.RegisterType<RecipientService>().As<IRecepientService>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
