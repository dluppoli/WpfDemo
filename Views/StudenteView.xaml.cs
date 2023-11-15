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
using System.Windows.Shapes;
using WpfDemo.Models;
using WpfDemo.ViewModels;

namespace WpfDemo.Views
{
    /// <summary>
    /// Interaction logic for StudenteView.xaml
    /// </summary>
    public partial class StudenteView : Window
    {
        private StudenteViewModel vm;
        public StudenteView()
        {
            InitializeComponent();
            vm = new StudenteViewModel();
            DataContext = vm;
        }

        public StudenteView(Studente s)
        {
            InitializeComponent();
            vm = new StudenteViewModel(s);
            DataContext = vm;
        }

        private void Annulla_Click(object sender, RoutedEventArgs e)
        {
            vm.Annulla();
            Close();
        }

        private async void Conferma_Click(object sender, RoutedEventArgs e)
        {
            await vm.Conferma();
            //Close();
        }
    }
}
