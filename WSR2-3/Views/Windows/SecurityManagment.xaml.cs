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
using System.Windows.Shapes;
using WSR2_3.Model;
using WSR2_3.Views.Pages.SecurityPages;

namespace WSR2_3.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для SecurityManagment.xaml
    /// </summary>
    public partial class SecurityManagment : Window
    {
        public Employees Employees { get; set; }
        public SecurityManagment(Employees employees)
        {
            InitializeComponent();
            Employees = employees;
            this.DataContext = this;
            SecurityFrame.Navigate(new SecurityMainPage());
            tblEmpl.Text = $"Пользователь: {employees.FirstName} , {employees.LastName}, {employees.Patronymic}";
        }
    }
}
