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
    /// Interaction logic for CoachKeyPage.xaml
    /// </summary>
    public partial class CoachKeyPage : Page
    {
      
        public CoachKeyPage()
        {
            InitializeComponent();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            CoachDataPage CoachDataPage = new CoachDataPage( );
 
            this.NavigationService.Navigate(CoachDataPage);
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            CoachDataPage CoachDataPage = new CoachDataPage();
            this.NavigationService.Navigate(CoachDataPage);
        }
    }
}
