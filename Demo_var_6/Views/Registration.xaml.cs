using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Demo_var_6.Model;
using Demo_var_6.Views;

namespace Demo_var_6.Views
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase();
            string uName = textbox_name.Text;
            string uSurname = textbox_surname.Text;
            string uPatronymic = textbox_patronimyc.Text;
            string login = textbox_email.Text.Trim();
            string pass = textbox_password.Text.Trim();

            string querystring = $"insert into [User](UserName, UserSurname, UserPatronymic, UserLogin, UserPassword) values('{uName}','{uSurname}', '{uPatronymic}', '{login}', '{pass}')";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Добро пожаловать в систему", "Успешно!"); // delete
                DataView dv = new DataView();
                NavigationService.Navigate(dv);
            }

            else
            {
                MessageBox.Show("Неправильные данные", "Аккаунт не создан!"); // delete
            }
            dataBase.closeConnection();
        }

        private void signin_txt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            NavigationService.GoBack();

        }
    }
}

