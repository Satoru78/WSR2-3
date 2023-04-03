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
    /// Логика взаимодействия для RequestEdit.xaml
    /// </summary>
    public partial class RequestEdit : Page
    {
        public List<Permission> Permissions { get; set; }
        public Request Request { get; set; }
        public RequestEdit(Request request)
        {
            InitializeComponent();
            Request = request;
            this.DataContext = this;
            Permissions = Data.db.Permission.ToList();
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
                MessageBox.Show("Разрешение выдано", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
