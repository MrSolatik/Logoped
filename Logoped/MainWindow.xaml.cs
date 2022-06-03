using System;
using System.Windows;


namespace Logoped
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AppConnect.model0db = new LogopedCabEntities1();
            FrameClass.framsus = MainFrame;

            //RechevayKarta1.ItemsSource = new LogopedCabEntities1.GetContext().RechevayKarta.ToList();

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
