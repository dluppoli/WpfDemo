using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using WpfDemo.ViewModels;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for Calcolatrice.xaml
    /// </summary>
    public partial class Calcolatrice : Window 
    {
        private CalcolatriceViewModel vm;
        public Calcolatrice()
        {
            InitializeComponent();
            vm = new CalcolatriceViewModel();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.Tasto("5");
        }
    }
}
