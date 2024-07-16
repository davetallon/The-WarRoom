﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace The_WarRoom.VIEWMODELS
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
        private string? _label;
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

        //THE COLOUR OF THE SQUARE
        private string? _fontColour;
        public string FontColour
        {
            get
            {
                if (string.IsNullOrEmpty(_fontColour))
                {
                    return "White";
                }
                return _fontColour;
            }
            set
            {
                _fontColour = value;
                OnPropertyChanged("FontColour");
            }
        }
    }
}