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

namespace WSR2_3.Views.Pages.DostupPages
{
    /// <summary>
    /// Логика взаимодействия для RequestList.xaml
    /// </summary>
    public partial class RequestList : Page
    {
        public Request Request { get; set; }
        public List<Request> Requests { get; set; }
        public List<Visitor> Visitors { get; set; }
        public List<StatusRequest> StatusRequests { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public BlackList BlackList { get; set; }
        public RequestList(Request request)
        {
            InitializeComponent();
            Request = request;
            this.DataContext = this;
        }

        private void cmdStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SearchStatus((cmdStatus.SelectedItem as ComboBoxItem).Content.ToString(), cmdStatus.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void SearchStatus(string search = "", string status = "")
        {
            var requestStatus = Data.db.Request.ToList();
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(status))
            {
                if (status == "проверка")
                {
                    requestStatus = requestStatus.Where(item => item.StatusRequest.Title == "проверка").ToList();
                }
                if (status == "одобрена")
                {
                    requestStatus = requestStatus.Where(item => item.StatusRequest.Title == "одобрена").ToList();
                }
                if (status == "не одобрена")
                {
                    requestStatus = requestStatus.Where(item => item.StatusRequest.Title == "не одобрена").ToList();
                }
                if (status == "Все")
                {
                    requestStatus = requestStatus.ToList();
                }
            }
            RequestDataGrid.ItemsSource = requestStatus;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentItem = RequestDataGrid.SelectedItem as Request;
                if (currentItem != null)
                {
                    var currentRequest = Data.db.Visitor.FirstOrDefault(item => item.IDBlackList == 1);
                    if (currentRequest != null)
                    {
                        switch (currentRequest.IDBlackList)
                        {
                            case 1:
                                currentItem.IDStatusRequest = 3;
                                Data.db.SaveChanges();
                                Page_Loaded(null, null);
                                MessageBox.Show("Заявитель находится в черном списке! Редактирвоание невозможно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);

                                break;
                            case 2:
                                NavigationService.Navigate(new RequestEditPage(currentItem));
                                break;
                        }
                    }
                }
                else
                {
                    throw new Exception("Выберите объект из списка");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Requests = Data.db.Request.ToList();
            RequestDataGrid.ItemsSource = Requests;
        }
    }
}
