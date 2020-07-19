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

namespace LoiOpdracht.Views
{
    /// <summary>
    /// Interaction logic for CoachDataPage.xaml
    /// </summary>
    public partial class CoachDataPage : Page
    {
        public CoachDataPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CoachKeyPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CoachKeyPage());
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CoachKeyPage());
        }
    }
}
