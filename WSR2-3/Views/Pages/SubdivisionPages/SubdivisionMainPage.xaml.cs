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

namespace WSR2_3.Views.Pages.SubdivisionPages
{
    /// <summary>
    /// Логика взаимодействия для SubdivisionMainPage.xaml
    /// </summary>
    public partial class SubdivisionMainPage : Page
    {
        public SubdivisionMainPage()
        {
            InitializeComponent();
        }

        private void btnVisitors_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VisitorList());
        }

        private void btnRequests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RequestList());
        }
    }
}
