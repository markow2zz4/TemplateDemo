using Demo_var_6.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace Demo_var_6.Views
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        DataBase database = new DataBase();
        private string? _login;
        private string? _password;

        public Login()
        {
            InitializeComponent();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            _login = textbox_login.Text;
            _password = textbox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataLoginTable = new DataTable();

            string queryLoginString = $"select UserID, UserLogin, UserPassword from [User] where UserLogin = '{_login}' and UserPassword = '{_password}'";
            SqlCommand command = new SqlCommand(queryLoginString, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dataLoginTable);

            if (dataLoginTable.Rows.Count == 1)
            {
                MessageBox.Show("Успешно!");

                NavigationService.Navigate(new DataView());
            }
            else
            {
                MessageBox.Show("Аккаунт не найден", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            NavigationService.Navigate(new Registration());
        }
    }
}
