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
using WSR2_3.Model;

namespace WSR2_3.Views.Pages.SubdivisionPages
{
    /// <summary>
    /// Логика взаимодействия для VisitorList.xaml
    /// </summary>
    public partial class VisitorList : Page
    {
        public Visitor Visitor { get; set; }
        public List<Visitor> Visitors { get; set; }
        public BlackList BlackList { get; set; }
        public VisitorList(Visitor visitor )
        {
            InitializeComponent();
            Visitor = visitor;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Visitors = Data.db.Visitor.ToList();
            VisitorDataGrid.ItemsSource = Visitors;
        }

        private void btnBlackList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = VisitorDataGrid.SelectedItem as Visitor;
                if (selectedItem != null)
                {
                    NavigationService.Navigate(new BlackListPage(selectedItem));
                }
                else
                {
                    throw new Exception("Пожалуйста, выберите объект из списка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
