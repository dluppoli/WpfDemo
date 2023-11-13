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
using WpfDemo.ViewModels;
using WpfDemo.Views;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowViewModel();
            DataContext = vm;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            vm.Logout();
            NavigationService.NavigationService.Navigate(new LoginView());
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigationService.Navigate(new StudenteRandomView());
        }

        private void Calcolatrice_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigationService.Navigate(new Calcolatrice());
        }
    }
}
