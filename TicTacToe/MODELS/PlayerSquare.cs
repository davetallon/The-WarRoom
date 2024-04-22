using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.MODELS
{
    public class PlayerSquare
    {
        public bool isPlayerX { get; set; }
        public bool isOccupied { get; set; }
        public string label { get; set; }
    }
}
