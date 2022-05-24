using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Logoped
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model0db.Users.FirstOrDefault(x=>x.Login==txblogin.Text && x.Password ==psbPassword.Password);
                if(userObj != null)
                {
                    MessageBox.Show("Unknown user!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); 
                }
                else
                {
                    switch(userObj.IdRole)
                    {
                        case 0: MessageBox.Show("Welcome Administrator!" + userObj.Name + "!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 1:MessageBox.Show("Добро пожаловать " + userObj.Name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default: MessageBox.Show("Данные не обнаружены!","Уведомление",MessageBoxButton.OK,MessageBoxImage.Warning);
                                break;
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + " Критическая работа приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RegistBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
