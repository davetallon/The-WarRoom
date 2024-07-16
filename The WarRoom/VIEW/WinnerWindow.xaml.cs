using System.Windows;
using System.Windows.Input;

namespace The_WarRoom.VIEW
{
    public partial class WinnerWindow : Window
    {
        //INSTANTIATE THE WINNER VARIABLE
        public string Winner { get; set; }

        public WinnerWindow(string winner)
        {
            Winner = winner;
            InitializeComponent();
            DataContext = this;
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_playAgain.Foreground = System.Windows.Media.Brushes.Red;
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void tb_playAgain_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_playAgain.Foreground = System.Windows.Media.Brushes.White;
        }
    }
}
