using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.VIEWMODELS
{
    public class MainViewModel
    {
        public SquareViewModel Sqr0 { get; private set; }
        public SquareViewModel Sqr1 { get; private set; }
        public SquareViewModel Sqr2 { get; private set; }
        public SquareViewModel Sqr3 { get; private set; }
        public SquareViewModel Sqr4 { get; private set; }
        public SquareViewModel Sqr5 { get; private set; }
        public SquareViewModel Sqr6 { get; private set; }
        public SquareViewModel Sqr7 { get; private set; }
        public SquareViewModel Sqr8 { get; private set; }
        public ScorecardViewModel scorecard { get; set; }
        public bool isClassicGameMode { get; set; }
        private bool isX = true;

        public MainViewModel()
        {
            Sqr0 = new SquareViewModel();
            Sqr1 = new SquareViewModel();
            Sqr2 = new SquareViewModel();
            Sqr3 = new SquareViewModel();
            Sqr4 = new SquareViewModel();
            Sqr5 = new SquareViewModel();
            Sqr6 = new SquareViewModel();
            Sqr7 = new SquareViewModel();
            Sqr8 = new SquareViewModel();
            scorecard = new ScorecardViewModel();
        }


        public void SetSquare(string UIElementName)
        {
            switch (UIElementName)
            {
                case "btn0":
                case "tb0":
                    AssignValue(Sqr0);
                    break;
                case "btn1":
                case "tb1":
                    AssignValue(Sqr1);
                    break;
                case "btn2":
                case "tb2":
                    AssignValue(Sqr2);
                    break;
                case "btn3":
                case "tb3":
                    AssignValue(Sqr3);
                    break;
                case "btn4":
                case "tb4":
                    AssignValue(Sqr4);
                    break;
                case "btn5":
                case "tb5":
                    AssignValue(Sqr5);
                    break;
                case "btn6":
                case "tb6":
                    AssignValue(Sqr6);
                    break;
                case "btn7":
                case "tb7":
                    AssignValue(Sqr7);
                    break;
                case "btn8":
                case "tb8":
                    AssignValue(Sqr8);
                    break;
            } 
        }

        private void AssignValue(SquareViewModel activeSquare)
        {
            if(!activeSquare.IsOccupied)
            {
                //TO PREVENT THE STRING TO BE PRINTED SET THE TEXT PROPERTY WITH
                //SUPPORTED UniCode STRING e.g:  "&#xe900;"  BECOMES   "\ue900"
                activeSquare.Label = (isX) ? "X" : "O";
                activeSquare.IconFontText = (isX) ? "\ue900" : "\ue904";
                activeSquare.IsOccupied = true;
                isX = !isX;
                CheckWin();
            }
        }

        public void ResetGame()
        {
            //RESET BUTTONS
            Sqr0.Label = "";
            Sqr0.IsOccupied = false;
            Sqr0.IconFontText = "";
            Sqr1.Label = "";
            Sqr1.IsOccupied = false;
            Sqr1.IconFontText = "";
            Sqr2.Label = "";
            Sqr2.IsOccupied = false;
            Sqr2.IconFontText = "";
            Sqr3.Label = "";
            Sqr3.IsOccupied = false;
            Sqr3.IconFontText = "";
            Sqr4.Label = "";
            Sqr4.IsOccupied = false;
            Sqr4.IconFontText = "";
            Sqr5.Label = "";
            Sqr5.IsOccupied = false;
            Sqr5.IconFontText = "";
            Sqr6.Label = "";
            Sqr6.IsOccupied = false;
            Sqr6.IconFontText = "";
            Sqr7.Label = "";
            Sqr7.IsOccupied = false;
            Sqr7.IconFontText = "";
            Sqr8.Label = "";
            Sqr8.IsOccupied = false;
            Sqr8.IconFontText = "";
            //RETURN TO PLAYER X
            isX = true;
        }

        public void LockBeforeRestart()
        {
            Sqr0.IsOccupied = true;
            Sqr1.IsOccupied = true;
            Sqr2.IsOccupied = true;
            Sqr3.IsOccupied = true;
            Sqr4.IsOccupied = true;
            Sqr5.IsOccupied = true;
            Sqr6.IsOccupied = true;
            Sqr7.IsOccupied = true;
            Sqr8.IsOccupied = true;
            Task.Delay(3000).ContinueWith(task => ResetGame());
        }

        private void CheckWin()
        {
            //ROWS X
            if ((Sqr0.Label == "X" && Sqr1.Label == "X" && Sqr2.Label == "X") || (Sqr3.Label == "X" && Sqr4.Label == "X" && Sqr5.Label == "X") || (Sqr6.Label == "X" && Sqr7.Label == "X" && Sqr8.Label == "X"))
            {
                IncrementWin("X");
                LockBeforeRestart();
            }
            // ROWS O
            else if ((Sqr0.Label == "O" && Sqr1.Label == "O" && Sqr2.Label == "O") || (Sqr3.Label == "O" && Sqr4.Label == "O" && Sqr5.Label == "O") || (Sqr6.Label == "O" && Sqr7.Label == "O" && Sqr8.Label == "O"))
            {
                IncrementWin("O");
                LockBeforeRestart();
            }
            //COLUMNS X
            else if ((Sqr0.Label == "X" && Sqr3.Label == "X" && Sqr6.Label == "X") || (Sqr1.Label == "X" && Sqr4.Label == "X" && Sqr7.Label == "X") || (Sqr2.Label == "X" && Sqr5.Label == "X" && Sqr8.Label == "X"))
            {
                IncrementWin("X");
                LockBeforeRestart();
            }
            //COLUMNS O
            else if ((Sqr0.Label == "O" && Sqr3.Label == "O" && Sqr6.Label == "O") || (Sqr1.Label == "O" && Sqr4.Label == "O" && Sqr7.Label == "O") || (Sqr2.Label == "O" && Sqr5.Label == "O" && Sqr8.Label == "O"))
            {
                IncrementWin("O");
                LockBeforeRestart();
            }
            //CRISS CROSS X
            else if ((Sqr6.Label == "X" && Sqr4.Label == "X" && Sqr2.Label == "X") || (Sqr0.Label == "X" && Sqr4.Label == "X" && Sqr8.Label == "X"))
            {
                IncrementWin("X");
                LockBeforeRestart();
            }
            //CRISS CROSS O
            else if ((Sqr6.Label == "O" && Sqr4.Label == "O" && Sqr2.Label == "O") || (Sqr0.Label == "O" && Sqr4.Label == "O" && Sqr8.Label == "O"))
            {
                IncrementWin("O");
                LockBeforeRestart();
            }
        }

        private void IncrementWin(string playerPoint)
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
    }
}

