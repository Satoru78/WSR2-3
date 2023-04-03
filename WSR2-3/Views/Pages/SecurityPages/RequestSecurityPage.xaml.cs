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
using WSR2_3.Context;
using WSR2_3.Model;

namespace WSR2_3.Views.Pages.SecurityPages
{
    /// <summary>
    /// Логика взаимодействия для RequestSecurityPage.xaml
    /// </summary>
    public partial class RequestSecurityPage : Page
    {
        public Request Request { get; set; }
        public Permission Permission { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public TypeRequest TypeRequest { get; set; }
        public List<Request> Requests { get; set; }
        public List<Visitor> Visitors { get; set; }
        public Visitor Visitor { get; set; }
        public RequestSecurityPage(Request request)
        {
            InitializeComponent();
            Request = request;
            this.DataContext = this;
        }

        private void RequestTypeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchType((RequestTypeCmb.SelectedItem as ComboBoxItem).Content.ToString(), RequestTypeCmb.Text);
        }
        private void SearchType(string type = "", string search = "")
        {
            try
            {
                var request = Data.db.Request.ToList();
                if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(search))
                {
                    if (type == "личная")
                    {
                        request = request.Where(item => item.TypeRequest.Title == "личная").ToList();
                    }
                    if (type == "групповая")
                    {
                        request = request.Where(item => item.TypeRequest.Title == "групповая").ToList();
                    }
                    if (type == "Все")
                    {
                        request = request.ToList();
                    }
                }
                RequestDataGrid.ItemsSource = request;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        private void txbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RequestDataGrid.ItemsSource = Data.db.Request.Where(item => item.Subdivision.Contains(txbSearch.Text)
          || item.Date.ToString().Contains(txbSearch.Text)).ToList();
        }

        private void btnRequestEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = RequestDataGrid.SelectedItem as Request;
                if (selectedItem != null)
                {
                    NavigationService.Navigate(new RequestEdit(selectedItem));
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Requests = Data.db.Request.ToList();
            RequestDataGrid.ItemsSource = Requests;
        }
    }
}
