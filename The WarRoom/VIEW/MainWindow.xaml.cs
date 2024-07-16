using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using The_WarRoom.VIEW;
using The_WarRoom.VIEWMODELS;

namespace The_WarRoom
{
    public partial class MainWindow : Window
    {
        //INSTANTIATE THE VIEWMODEL
        private MainViewModel _viewModel = new MainViewModel();

        //DECLARE VARIABLES
        Polygon[] gamePolygons;
        DoubleAnimation fadeOut = new DoubleAnimation(1,0, new Duration(TimeSpan.FromSeconds(1)));
        DoubleAnimation fadeOut2 = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(5)));
        private List<String> winningSquares = new List<String>();
        private List<TextBlock> textBlocks = new List<TextBlock>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
            gamePolygons = [btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8];
            textBlocks = [Sqr0, Sqr1, Sqr2, Sqr3, Sqr4, Sqr5, Sqr6, Sqr7, Sqr8];
            StartGameAnimation();
        }

        private async void StartGameAnimation()
        {
            foreach (Polygon polygon in gamePolygons)
            {
                polygon.Fill = new SolidColorBrush(Colors.White);
                polygon.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.5))));
            }
            await Task.Delay(500);
            foreach (Polygon polygon in gamePolygons)
            {
                polygon.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.25))));
            }
        }

        private void ActivateSquare(object sender, RoutedEventArgs e)
        {
            if (e.Source != null) { 
                try
                {
                    //DISABLE SELECTED UI ELEMENT (POLYGON)
                    ((UIElement)e.Source).IsEnabled = false;

                    //SEND NAME OF UI ELEMENT (POLYGON) TO VIEWMODEL
                    String UIElementName = Convert.ToString(e.Source.GetType().GetProperty("Name").GetValue(e.Source, null));
                    _viewModel.SetSquare(UIElementName, e);
                }
                catch (Exception)
                {
                    throw;
                }
                AnimateBoxSelection(e);

                //CHECK FOR WIN + DRAW
                winningSquares = _viewModel.CheckWin();

                if (winningSquares != null && !_viewModel.isDraw)
                {
                    AnimateWinningBoxes();
                }
                else if (_viewModel.isDraw)
                {
                    StartGameAnimation();
                    RestartGame();
                }
            }
        }

        private async void RestartGame()
        {
            //RESET WINNING SQUARES
            if (winningSquares != null)
            {
                winningSquares.Clear();
            }
            UpdateScoreCard();

            await Task.Delay(2000);

            StartGameAnimation();

            //RESET GAME
            await Task.Delay(500).ContinueWith(task => _viewModel.ResetGame());

            _viewModel.isDraw = false;

            EnableUI();
        }

        private void DisableUI()
        {
            //DISABLE POLYGONS
            foreach (Polygon polygon in gamePolygons)
            {
                polygon.IsEnabled = false;
            }

            //DISABLE BUTTONS
            foreach (SquareViewModel square in _viewModel.squareArray)
            {
                square.IsOccupied = true;
            }
        }

        private void EnableUI()
        {
            //ENABLE TEXTBLOCKS
            foreach (TextBlock textBlock in textBlocks)
            {
                textBlock.BeginAnimation(OpacityProperty, new DoubleAnimation(1, new Duration(TimeSpan.FromSeconds(0))));
            }

            //ENABLE POLYGONS
            foreach (Polygon polygon in gamePolygons)
            {
                polygon.IsEnabled = true;
            }
        }

        private async void UpdateScoreCard()
        {
            TextBlock[] xScoreElements = {xScore1, xScore2, xScore3, xScore4, xScore5, xScore6, xScore7, xScore8, xScore9, xScore10};
            TextBlock[] oScoreElements = {oScore1, oScore2, oScore3, oScore4, oScore5, oScore6, oScore7, oScore8, oScore9, oScore10};

            //BUILD X SCORECARD
            foreach (TextBlock element in xScoreElements)
            {
                //DETERMINE VISIBILITY OF X SCORES
                int xPosition = Array.IndexOf(xScoreElements, element);
                if (_viewModel.scorecard.xPoints > xPosition || _viewModel.scorecard.xPoints == 10)
                {
                    element.Visibility = Visibility.Visible;
                }

                //CHECK FOR X WIN
                if (_viewModel.scorecard.xPoints == 10 && xPosition == 9)
                {
                    string Winner = "X";

                    //DISPLAY WINNER WINDOW
                    WinnerWindow winnerWindow = new WinnerWindow(Winner);
                    winnerWindow.Winner = Winner;
                    winnerWindow.Owner = this;
                    winnerWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    await Task.Delay(1500);
                    winnerWindow.ShowDialog();

                    //RESET ENTIRE GAME
                    xScoreElements.ToList().ForEach(x => x.Visibility = Visibility.Hidden);
                    oScoreElements.ToList().ForEach(x => x.Visibility = Visibility.Hidden);
                    ResetEntireGame();

                    //EXIT METHOD IF GAME IS A WIN
                    break;
                }
            }

            //BUILD O SCORECARD
            foreach (TextBlock element in oScoreElements)
            {
                //DETERMINE VISIBILITY OF O SCORES
                int oPosition = Array.IndexOf(oScoreElements, element);
                if (_viewModel.scorecard.oPoints > oPosition || _viewModel.scorecard.oPoints == 10)
                {
                    element.Visibility = Visibility.Visible;
                }

                //CHECK FOR O WIN
                if (_viewModel.scorecard.oPoints == 10 && oPosition == 9)
                {
                    string Winner = "O";

                    //DISPLAY WINNER WINDOW
                    WinnerWindow winnerWindow = new WinnerWindow(Winner);
                    winnerWindow.Winner = Winner;
                    winnerWindow.Owner = this;  
                    winnerWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    await Task.Delay(1500);
                    winnerWindow.ShowDialog();

                    //RESET ENTIRE GAME
                    oScoreElements.ToList().ForEach(x => x.Visibility = Visibility.Hidden);
                    xScoreElements.ToList().ForEach(x => x.Visibility = Visibility.Hidden);
                    ResetEntireGame();
                }
            }
        }

        private void ResetEntireGame() 
        {
            _viewModel.scorecard.xPoints = 0;
            _viewModel.scorecard.oPoints = 0;
            _viewModel.ResetGame();
        }

        private void AnimateBoxSelection(RoutedEventArgs e)
        {
            Shape animatedElement = (Shape)e.Source;
            animatedElement.Fill = new SolidColorBrush(Colors.White);
            animatedElement.BeginAnimation(UIElement.OpacityProperty, fadeOut);
        }

        private async void AnimateWinningBoxes()
        {
            DisableUI();

            //ANIMATE WINNING BOXES
            foreach (Polygon polygon in gamePolygons)
            {
                polygon.Fill = new SolidColorBrush(Colors.White);
                polygon.BeginAnimation(UIElement.OpacityProperty, fadeOut);
                await Task.Delay(50);
            }

            //FADE OUT LOSER MOVES
            foreach (TextBlock textBlock in textBlocks)
            {
                if (!winningSquares.Contains(textBlock.Name))
                {
                    textBlock.BeginAnimation(OpacityProperty, fadeOut);
                }
            }
            RestartGame();
        }

        // BANNER BUTTONS & HOVER STATES
        #region

        //BANNER BUTTONS
        private void CreditsBTN_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CreditsWindow creditsWindow = new CreditsWindow();

            //ENSURE CREDITS WINDOW IS ALWAYS CENTERED BEFORE DISPLAYING
            creditsWindow.Owner = this;
            creditsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            creditsWindow.ShowDialog();
        }

        private void CreditsBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            setHover("credits");
        }

        private void CreditsBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            UI_CreditsBtn.Source = (ImageSource)Application.Current.Resources["credits_Btn"];
        }

        private void StartBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            setHover("start");
        }

        private void StartBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            UI_StartBtn.Source = (ImageSource)Application.Current.Resources["start_Btn"];
        }

        private void StartBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _viewModel.ResetGame();
            StartGameAnimation();
            EnableUI();
        }

        private void CloseBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            setHover("close");
        }

        private void CloseBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            UI_CloseBtn.Source = (ImageSource)Application.Current.Resources["close_Btn"];
        }

        private void CloseBTN_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //MOVE APP WINDOW
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((e.OriginalSource is Grid && e.OriginalSource is not Viewbox) && (e.LeftButton == MouseButtonState.Pressed))
            {
                DragMove();
            }
        }

        //HOVER STATES
        private void setHover(string candidate)
        {
            switch (candidate)
            {
                case "credits":
                    UI_CreditsBtn.Source = (BitmapImage)Application.Current.Resources["credits_Btn_Hover"];
                    break;
                case "start":
                    UI_StartBtn.Source = (BitmapImage)Application.Current.Resources["start_Btn_Hover"];
                    break;
                case "close":
                    UI_CloseBtn.Source = (BitmapImage)Application.Current.Resources["close_Btn_Hover"];
                    break;
            }
        }
        #endregion
    }
}