using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace The_WarRoom
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

        CreditsWindow creditsWindow = new CreditsWindow();
        
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            creditsWindow.ShowDialog();
            //creditsWindow.Close();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            

        }
    }
}