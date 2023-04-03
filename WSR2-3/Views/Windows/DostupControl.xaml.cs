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
using WSR2_3.Views.Pages.DostupPages;
using WSR2_3.Model;

namespace WSR2_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class DostupControl : Window
    {
      public Employees Employees { get; set; }
        public DostupControl(Employees employees)
        {
            InitializeComponent();
            Employees = employees;
            this.DataContext = this;
            DostupFrame.Navigate(new DostupMainPage());
            tblEmpl.Text = $"Пользователь: {employees.FirstName} , {employees.LastName}, {employees.Patronymic}";
        }
    }
}
