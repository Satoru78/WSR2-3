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
    /// Логика взаимодействия для MoreInfoList.xaml
    /// </summary>
    public partial class MoreInfoList : Page
    {
        public Request Request { get; set; }
        public List<Visitor> Visitors { get; set; }
        public Permission Permission { get; set; }
        public BlackList BlackList { get; set; }
        public TypeRequest TypeRequest { get; set; }
        public List<Request> Requests { get; set; }
        public Visitor Visitor { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public MoreInfoList(Request request)
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
