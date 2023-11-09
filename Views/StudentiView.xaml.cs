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
    /// Interaction logic for StudentiView.xaml
    /// </summary>
    public partial class StudentiView : Window
    {
        private StudentiViewModel vm;
        public StudentiView()
        {
            InitializeComponent();
            vm = new StudentiViewModel();
            DataContext = vm;
        }

        private void Filtra_Click(object sender, RoutedEventArgs e)
        {
            vm.Filtra();
        }

        private void Elimina_Click(object sender, RoutedEventArgs e)
        {
            vm.Elimina();
        }

        private void Nuovo_Click(object sender, RoutedEventArgs e)
        {
            vm.Nuovo();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.Edit();
        }
    }
}
