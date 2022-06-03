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
                var userObj = AppConnect.model0db.Users.FirstOrDefault(x => x.Login == txblogin.Text && x.Password == psbPassword.Password);
                //генерация события для PasswordBox и TextBox с обращением к содержимому базы данных
                if (userObj == null)
                {
                    MessageBox.Show("Неверно указанный пользователь!", "Ошибка доступа",        //сообщение выдаваемое при неверно указаном пользователе
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IdRole)             //переключение между профилями
                    {
                        case 1:
                            MessageBox.Show("Добро пожаловать, Администратор " + userObj.Name + "!",
                         "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 2:
                            MessageBox.Show("Добро пожаловать, ученик " + userObj.Name + "!",
                         "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте, " + userObj.Name + "!",
                         "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default:
                            MessageBox.Show("Ошибка! Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
                FrameClass.framsus.Navigate(new MainWindow()); //переход на главную форму с Базой данных
            }

            catch (Exception ex)        //при невверно указаном профиле ошибка 
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RegistBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.framsus.Navigate(new PageCreateAcc());
        }
    }
}
