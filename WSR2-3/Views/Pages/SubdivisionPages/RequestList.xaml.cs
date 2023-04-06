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

namespace WSR2_3.Views.Pages.SubdivisionPages
{
    /// <summary>
    /// Логика взаимодействия для RequestList.xaml
    /// </summary>
    public partial class RequestList : Page
    {
        public Request Request { get; set; }
        public List<Request> Requests { get; set; }
        public Permission Permission { get; set; }
        public BlackList BlackList { get; set; }
        public TypeRequest TypeRequest { get; set; }
        public List<Visitor> Visitors { get; set; }
        public Visitor Visitor { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public RequestList(Request request)
        {
            InitializeComponent();
            Request = request;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Requests = Data.db.Request.ToList();
            RequestDataGrid.ItemsSource = Requests;
        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = RequestDataGrid.SelectedItem as Request;
                if (selectedItem != null)
                {
                    NavigationService.Navigate(new MoreInfoList(new Request()));
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

        private void txbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RequestDataGrid.ItemsSource = Data.db.Request.Where
         (item => item.Date.ToString().Contains(txbSearch.Text)).ToList();
        }
    }
}
