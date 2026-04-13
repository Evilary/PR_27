
using System.Windows;
using System.Windows.Input;


namespace ShopContent_Chernyshkov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public View.Main Main = new View.Main();
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            Main = new View.Main();
            Main.DataContext = new ViewModell.VMItems();

            frame.Navigate(Main);
        }
        private void OpenIndex(object sender, MouseButtonEventArgs e)=> 
            frame.Navigate(Main);
    }
}
