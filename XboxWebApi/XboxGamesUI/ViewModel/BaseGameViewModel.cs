using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using XboxGamesUI.DataLayer;
using XboxGamesUI.Models;

namespace XboxGamesUI.ViewModel
{
    public class BaseGameViewModel:ObservableObject
    {
        protected IDataService DataService { get; set; }
        public BaseGameViewModel(IDataService dataService)
        {
            DataService = dataService;
        }

        private string _usrMsg { get; set; }
        public string UsrMsg
        {
            get { return _usrMsg; }
            set
            {
                if (_usrMsg == value)
                {
                    return;
                }
                _usrMsg = value;
                RaisePropertyChanged("UsrMsg");
            }
        }



        private Game _game;

       

        public Game Game
        {
            get { return _game; }
            set
            {
                if (_game == value)
                {
                    return;
                }
                _game = value;
                RaisePropertyChanged("Game");
            }
        }

        public string Validate()
        {
            if (String.IsNullOrEmpty(_game.Desc))
            {
                return "Please enter a description";
            }

            if (String.IsNullOrEmpty(_game.Title))
            {
                return "Please enter a title";
            }

            return String.Empty;
        }
    }
}
