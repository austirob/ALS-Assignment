using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XboxGamesUI.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using XboxGamesUI.DataLayer;
using XboxGamesUI.Messaging;
using XboxGamesUI.Static;


namespace XboxGamesUI.ViewModel
{
    public class RatingsViewModel:BaseGameViewModel, IRatingsViewModel
    {
       
        
        public List<int> Ratings { get; set; }
        public ICommand SubmitRatingCommand { get; set; }
        private IDataService _dataService;
        public RatingsViewModel(Game game, IDataService dataService) : base(dataService)
        {
            _dataService = dataService;
            Game = game;
            SubmitRatingCommand = new RelayCommand(ExecuteSubmitRatingCommand);
            Ratings = new RatingOptions();
        }

        private void ExecuteSubmitRatingCommand()
        {
            try

            {
                UsrMsg = String.Empty;
                if (SelectedRating == 0)
                {
                    UsrMsg = "Please select a rating";
                    return;
                }

              
                _dataService.SubmitRating(new Rating() { GameId = Game.Id, Stars = SelectedRating });
                Messenger.Default.Send(new RefreshGamesMsg());
                UsrMsg = "Rating Submitted";
            }
            catch (Exception e)
            {
                UsrMsg = e.ToString();
            }
          

        }

        private int _selectedRating;
        public int SelectedRating
        {
            get { return _selectedRating;}
            set
            {
                _selectedRating = value;
                RaisePropertyChanged("SelectedRating");
            }

        }


    }
}
