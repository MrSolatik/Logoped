using System;
using System.Windows;

namespace Logoped
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AppConnect.model0db = new LogopedCabEntities();
            FrameClass.framsus = MainFrame;

            MainFrame.Navigate(new LoginPage());
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.framsus.Navigate(new StudentInf());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            //дописать момент с возвращением
            if (MainFrame.CanGoBack)
            {
                Visibility = Visibility.Visible;
            }
            else
            {
                Visibility = Visibility.Hidden;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
