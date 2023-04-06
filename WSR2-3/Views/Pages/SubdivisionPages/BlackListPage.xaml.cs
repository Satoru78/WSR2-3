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
    /// Логика взаимодействия для BlackListPage.xaml
    /// </summary>
    public partial class BlackListPage : Page
    {
        public List<BlackList> BlackLists { get; set; }
        public Visitor Visitor { get; set; }
        public BlackListPage(Visitor visitor)
        {
            InitializeComponent();
            Visitor = visitor;
            this.DataContext = this;
            BlackLists = Data.db.BlackList.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Visitor.ID == 0)
                {
                    Data.db.Visitor.Add(Visitor);
                }
                Data.db.SaveChanges();
                MessageBox.Show("Данные успешно сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
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
