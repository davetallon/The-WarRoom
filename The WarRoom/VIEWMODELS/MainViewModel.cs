using System.Windows;
using The_WarRoom.MODELS;

namespace The_WarRoom.VIEWMODELS
{
    public class MainViewModel
    {
        //DECLARE SQUARES & NECESSARY VARIABLES
        public SquareModel Sqr0 { get; private set; }
        public SquareModel Sqr1 { get; private set; }
        public SquareModel Sqr2 { get; private set; }
        public SquareModel Sqr3 { get; private set; }
        public SquareModel Sqr4 { get; private set; }
        public SquareModel Sqr5 { get; private set; }
        public SquareModel Sqr6 { get; private set; }
        public SquareModel Sqr7 { get; private set; }
        public SquareModel Sqr8 { get; private set; }
        public ScorecardModel scorecard { get; set; }
        public SquareModel[] squareArray = [];
        private bool isXMove = true;
        public bool isDraw = false;

        public MainViewModel()
        {
            Sqr0 = new SquareModel();
            Sqr1 = new SquareModel();
            Sqr2 = new SquareModel();
            Sqr3 = new SquareModel();
            Sqr4 = new SquareModel();
            Sqr5 = new SquareModel();
            Sqr6 = new SquareModel();
            Sqr7 = new SquareModel();
            Sqr8 = new SquareModel();
            squareArray = [Sqr0, Sqr1, Sqr2, Sqr3, Sqr4, Sqr5, Sqr6, Sqr7, Sqr8];
            scorecard = new ScorecardModel();
        }


        public void SetSquare(string UIElementName, RoutedEventArgs e)
        {
            switch (UIElementName)
            {
                case "btn0":
                    AssignValue(Sqr0, e);
                    break;
                case "btn1":
                    AssignValue(Sqr1, e);
                    break;
                case "btn2":
                    AssignValue(Sqr2, e);
                    break;
                case "btn3":
                    AssignValue(Sqr3, e);
                    break;
                case "btn4":
                    AssignValue(Sqr4, e);
                    break;
                case "btn5":
                    AssignValue(Sqr5, e);
                    break;
                case "btn6":
                    AssignValue(Sqr6, e);
                    break;
                case "btn7":
                    AssignValue(Sqr7, e);
                    break;
                case "btn8":
                    AssignValue(Sqr8, e);
                    break;
            } 
        }

        private void AssignValue(SquareModel activeSquare, RoutedEventArgs e)
        {
            if(!activeSquare.IsOccupied)
            {
                activeSquare.Label = (isXMove) ? "X" : "O";
                activeSquare.IsOccupied = true;
                isXMove = !isXMove;
            }
        }

        public void ResetGame()
        {
            //RESET BUTTONS
            foreach (SquareModel square in squareArray)
            {
                square.Label = "";
                square.IsOccupied = false;
                square.FontColour = "White";
            }
            
            //RETURN TO PLAYER X
            isXMove = true;
        }

        public List<String>? CheckWin()
        {
            //ROW 1 X:
            if ((Sqr0.Label == "X" && Sqr1.Label == "X" && Sqr2.Label == "X"))
            {
                DisplayWinningLine(Sqr0, Sqr1, Sqr2);
                IncrementWinningPoint("X");
                return new List<string> { "Sqr0", "Sqr1", "Sqr2" };
            }
            // ROW 1 O:
            else if ((Sqr0.Label == "O" && Sqr1.Label == "O" && Sqr2.Label == "O"))
            {
                DisplayWinningLine(Sqr0, Sqr1, Sqr2);
                IncrementWinningPoint("O");
                return new List<string> { "Sqr0", "Sqr1", "Sqr2" };
            }
            // ROW 2 X: 
            else if ((Sqr3.Label == "X" && Sqr4.Label == "X" && Sqr5.Label == "X"))
            {
                DisplayWinningLine(Sqr3, Sqr4, Sqr5);
                IncrementWinningPoint("X");
                return new List<string> { "Sqr3", "Sqr4", "Sqr5" };
            }
            // ROW 2 O:
            else if ((Sqr3.Label == "O" && Sqr4.Label == "O" && Sqr5.Label == "O"))
            {
                DisplayWinningLine(Sqr3, Sqr4, Sqr5);
                IncrementWinningPoint("O");
                return new List<string> { "Sqr3", "Sqr4", "Sqr5" };
            }
            // ROW 3 X:
            else if ((Sqr6.Label == "X" && Sqr7.Label == "X" && Sqr8.Label == "X"))
            {
                DisplayWinningLine(Sqr6, Sqr7, Sqr8);
                IncrementWinningPoint("X");
                return new List<string> { "Sqr6", "Sqr7", "Sqr8" };
            }
            // ROW 3 O:
            else if ((Sqr6.Label == "O" && Sqr7.Label == "O" && Sqr8.Label == "O"))
            {
                DisplayWinningLine(Sqr6, Sqr7, Sqr8);
                IncrementWinningPoint("O");
                return new List<string> { "Sqr6", "Sqr7", "Sqr8" };
            }

            //COLUMN 1 X:
            else if ((Sqr0.Label == "X" && Sqr3.Label == "X" && Sqr6.Label == "X"))
            {
                DisplayWinningLine(Sqr0, Sqr3, Sqr6);
                IncrementWinningPoint("X");
                return new List<string> { "Sqr0", "Sqr3", "Sqr6" };
            }
            //COLUMN 1 O:
            else if ((Sqr0.Label == "O" && Sqr3.Label == "O" && Sqr6.Label == "O"))
            {
                DisplayWinningLine(Sqr0, Sqr3, Sqr6);
                IncrementWinningPoint("O");
                return new List<string> { "Sqr0", "Sqr3", "Sqr6" };
            }
            //COLUMN 2 X:
            else if ((Sqr1.Label == "X" && Sqr4.Label == "X" && Sqr7.Label == "X"))
            {
                DisplayWinningLine(Sqr1, Sqr4, Sqr7);
                IncrementWinningPoint("X");
                return new List<string> { "Sqr1", "Sqr4", "Sqr7" };
            }
            //COLUMN 2 O:
            else if ((Sqr1.Label == "O" && Sqr4.Label == "O" && Sqr7.Label == "O"))
            {
                DisplayWinningLine(Sqr1, Sqr4, Sqr7);
                IncrementWinningPoint("O");
                return new List<string> { "Sqr1", "Sqr4", "Sqr7" };
            }
            //COLUMN 3 X:
            else if ((Sqr2.Label == "X" && Sqr5.Label == "X" && Sqr8.Label == "X"))
            {
                DisplayWinningLine(Sqr2, Sqr5, Sqr8);
                IncrementWinningPoint("X");
                return new List<string> { "Sqr2", "Sqr5", "Sqr8" };
            }
            //COLUMN 3 O:
            else if ((Sqr2.Label == "O" && Sqr5.Label == "O" && Sqr8.Label == "O"))
            {
                DisplayWinningLine(Sqr2, Sqr5, Sqr8);
                IncrementWinningPoint("O");
                return new List<string> { "Sqr2", "Sqr5", "Sqr8" };
            }

            //CRISS CROSS 1 X:
            else if ((Sqr6.Label == "X" && Sqr4.Label == "X" && Sqr2.Label == "X"))
            {
                DisplayWinningLine(Sqr6, Sqr4, Sqr2);
                IncrementWinningPoint("X");
                return new List<string> { "Sqr6", "Sqr4", "Sqr2" };
            }
            //CRISS CROSS 1 O:
            else if ((Sqr6.Label == "O" && Sqr4.Label == "O" && Sqr2.Label == "O"))
            {
                DisplayWinningLine(Sqr6, Sqr4, Sqr2);
                IncrementWinningPoint("O");
                return new List<string> { "Sqr6", "Sqr4", "Sqr2" };
            }
            //CRISS CROSS 2 X:
            else if ((Sqr0.Label == "X" && Sqr4.Label == "X" && Sqr8.Label == "X"))
            {
                DisplayWinningLine(Sqr0, Sqr4, Sqr8);
                IncrementWinningPoint("X");
                return new List<string> { "Sqr0", "Sqr4", "Sqr8" };
            }
            //CRISS CROSS 2 O:
            else if ((Sqr0.Label == "O" && Sqr4.Label == "O" && Sqr8.Label == "O"))
            {
                DisplayWinningLine(Sqr0, Sqr4, Sqr8);
                IncrementWinningPoint("O");
                return new List<string> { "Sqr0", "Sqr4", "Sqr8" };
            }
            else if (Sqr0.IsOccupied && Sqr1.IsOccupied && Sqr2.IsOccupied && Sqr3.IsOccupied && Sqr4.IsOccupied && Sqr5.IsOccupied && Sqr6.IsOccupied && Sqr7.IsOccupied && Sqr8.IsOccupied)
            {
                isDraw = true;
                return null;
            }
            return null;
        }

        private void IncrementWinningPoint(string playerPoint)
        {
            if (playerPoint == "X")
            {
                scorecard.xPoints++;
            }
            else
            {
                scorecard.oPoints++;
            }
        }

        private void DisplayWinningLine(SquareModel One, SquareModel Two, SquareModel Three)
        {
            One.FontColour = "Red";
            Two.FontColour = "Red";
            Three.FontColour = "Red";
        }
    }
}