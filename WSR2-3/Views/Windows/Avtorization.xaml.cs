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
using WSR2_3.Context;
using WSR2_3.Model;

namespace WSR2_3.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Window
    {
        public Employees Employees { get; set; }

        public List<Departament> Departaments { get; set; }
        public Avtorization()
        {
            InitializeComponent();
            Departaments = Data.db.Departament.ToList();
            this.DataContext = this;
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbCode.Text == "" && cmdDep.Text == "")
                {
                    throw new Exception("Заполните все поля");
                }
                else
                {
                    var epmloeeyLog = Data.db.Employees.FirstOrDefault(item => item.Code == txbCode.Text);
                    if (epmloeeyLog != null && cmdDep.Text != "")
                    {
                        switch (epmloeeyLog.IDDepartment)
                        {
                            case 1:
                                DostupControl dostupControl = new DostupControl(epmloeeyLog);
                                dostupControl.ShowDialog();
                                break;
                            case 2:
                                SecurityManagment security = new SecurityManagment(epmloeeyLog);
                                security.ShowDialog();
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
