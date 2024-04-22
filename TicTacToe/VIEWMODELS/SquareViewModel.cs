using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe.VIEWMODELS
{
    public class SquareViewModel : ObservableObject
    {
        // IS THE SQUARE OCCIPIED? 
        private bool _isOccupied; // field
        public bool IsOccupied   // property
        {
            get { return _isOccupied; }   // get method
            set { _isOccupied = value; }  // set method
        }

        //THE LABEL ON THE SQUARE
        private string _label;
        public string Label
        {
            get
            {
                if(string.IsNullOrEmpty(_label))
                {
                    return "";
                }
                return _label;
            }
            set
            {
                _label = value;
                OnPropertyChanged("Label");
            }
        }

        //THE VISIBILITY PARAMETER OF THE BUTTON
        private string _iconFontText;
        public string IconFontText
        {
            get
            {
                if(string.IsNullOrEmpty(_iconFontText))
                {
                    return "";
                }
                return _iconFontText;
            }
            set
            {
                _iconFontText = value;
                OnPropertyChanged("IconFontText");
            }
        }
    }
}
