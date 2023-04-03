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
    /// Логика взаимодействия для RequestEditPage.xaml
    /// </summary>
    public partial class RequestEditPage : Page
    {
        public Request Request { get; set; }
        public List<StatusRequest> StatusRequests { get; set; }
        public RequestEditPage(Request request)
        {
            InitializeComponent();
            Request = request;
            this.DataContext = this;
            StatusRequests = Data.db.StatusRequest.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Request.ID == 0)
                {
                    Data.db.Request.Add(Request);
                }
                Data.db.SaveChanges();
                MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
