using BankBLL.Bl;
using BankDAL.Models;
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

namespace Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Register(object sender, RoutedEventArgs e)
        {
            UserData data = new UserData();
            UserAccessData userAccess = new UserAccessData();

            data.Name = name.Text;
            data.Surname = surname.Text;
            userAccess.Mail = mail.Text;

            data.Region = region.Text;
            data.City = city.Text;
            data.Phone = phone.Text;
            if (password.Password == password2.Password)
            {
                userAccess.Password = password.Password;
            }
            data.UserAccessData.Add(userAccess);
            UserDataBl dataBl = new UserDataBl(new BankEmulatorContext());
            dataBl.Register(data);

            

        }
    }
}
