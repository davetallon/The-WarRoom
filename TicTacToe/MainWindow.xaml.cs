using System;
using System.Collections.Generic;
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
using TicTacToe.MODELS;
using TicTacToe.VIEWMODELS;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel = new MainViewModel();
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void ActivateSquare(object sender, RoutedEventArgs e)
        {
            String UIElementName = Convert.ToString(e.Source.GetType().GetProperty("Name").GetValue(e.Source, null));
            _viewModel.SetSquare(UIElementName);
        }

        private void PlayBtn(object sender, RoutedEventArgs e)
        {
            _viewModel.ResetGame();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.ResetGame();
            _viewModel.isClassicGameMode = true;
        }

        private void SwapGameMode(object sender, MouseButtonEventArgs e)
        {
            if(ToggleClassicGameMode.Visibility == Visibility.Visible)
            //SWITCH TO CLASSY MODE
            {
                _viewModel.isClassicGameMode = true;
                ToggleClassicGameMode.Visibility = Visibility.Collapsed;
                ToggleFlashyGameMode.Visibility = Visibility.Visible;
                btn_classicPlay.Visibility = Visibility.Visible;
                btn_flashyPlay.Visibility = Visibility.Collapsed;
                points.Visibility = Visibility.Visible;
                trophy.Visibility = Visibility.Collapsed;
                btn0.Visibility = Visibility.Visible;
                tb0.Visibility = Visibility.Collapsed;
                btn1.Visibility = Visibility.Visible;
                tb1.Visibility = Visibility.Collapsed;
                btn2.Visibility = Visibility.Visible;
                tb2.Visibility = Visibility.Collapsed;
                btn3.Visibility = Visibility.Visible;
                tb3.Visibility = Visibility.Collapsed;
                btn4.Visibility = Visibility.Visible;
                tb4.Visibility = Visibility.Collapsed;
                btn5.Visibility = Visibility.Visible;
                tb5.Visibility = Visibility.Collapsed;
                btn6.Visibility = Visibility.Visible;
                tb6.Visibility = Visibility.Collapsed;
                btn7.Visibility = Visibility.Visible;
                tb7.Visibility = Visibility.Collapsed;
                btn8.Visibility = Visibility.Visible;
                tb8.Visibility = Visibility.Collapsed;
            }
            else
            //SWITH TO FLASHY MODE
            {
                _viewModel.isClassicGameMode = false;
                ToggleClassicGameMode.Visibility = Visibility.Visible;
                ToggleFlashyGameMode.Visibility = Visibility.Collapsed;
                btn_flashyPlay.Visibility = Visibility.Visible;
                btn_classicPlay.Visibility = Visibility.Collapsed;
                points.Visibility= Visibility.Collapsed;
                trophy.Visibility = Visibility.Visible;
                btn0.Visibility = Visibility.Collapsed;
                tb0.Visibility = Visibility.Visible;
                btn1.Visibility = Visibility.Collapsed;
                tb1.Visibility = Visibility.Visible;
                btn2.Visibility = Visibility.Collapsed;
                tb2.Visibility = Visibility.Visible;
                btn3.Visibility = Visibility.Collapsed;
                tb3.Visibility = Visibility.Visible;
                btn4.Visibility = Visibility.Collapsed;
                tb4.Visibility = Visibility.Visible;
                btn5.Visibility = Visibility.Collapsed;
                tb5.Visibility = Visibility.Visible;
                btn6.Visibility = Visibility.Collapsed;
                tb6.Visibility = Visibility.Visible;
                btn7.Visibility = Visibility.Collapsed;
                tb7.Visibility = Visibility.Visible;
                btn8.Visibility = Visibility.Collapsed;
                tb8.Visibility = Visibility.Visible;
            }
        }
    }
}