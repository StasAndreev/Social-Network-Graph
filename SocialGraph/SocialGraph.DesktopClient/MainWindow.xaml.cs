using System.Windows;

namespace SocialGraph.DesktopClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel VM = new MainViewModel();

        public MainViewModel ViewModel
        {
            get { return VM; }
        }
    }
}
