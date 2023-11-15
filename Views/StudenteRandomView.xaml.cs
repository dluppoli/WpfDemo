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
using WpfDemo.ViewModels;

namespace WpfDemo.Views
{
    /// <summary>
    /// Interaction logic for StudenteRandomView.xaml
    /// </summary>
    public partial class StudenteRandomView : Page
    {
        private StudenteRandomViewModel vm;
        public StudenteRandomView()
        {
            InitializeComponent();
            vm = new StudenteRandomViewModel();
            DataContext = vm;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await vm.GetStudenteRandom();
        }
    }
}
