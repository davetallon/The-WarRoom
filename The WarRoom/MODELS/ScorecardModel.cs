using The_WarRoom.VIEWMODELS;

namespace The_WarRoom.MODELS
{
    public class ScorecardModel : ObservableObject
    {
        private int _xPoints;
        public int xPoints
        {
            get
            {
                if (_xPoints == 0)
                {
                    return 0;
                }
                return _xPoints;
            }
            set
            {
                _xPoints = value;
                OnPropertyChanged("xPoints");
            }
        }

        private int _oPoints;
        public int oPoints
        {
            get
            {
                if (_oPoints == 0)
                {
                    return 0;
                }
                return _oPoints;
            }
            set
            {
                _oPoints = value;
                OnPropertyChanged("oPoints");
            }
        }
    }
}
