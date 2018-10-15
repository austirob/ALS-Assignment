using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using XboxGamesUI.DataLayer;
using XboxGamesUI.Messaging;
using XboxGamesUI.Models;

namespace XboxGamesUI.ViewModel
{
   public class AddGameViewModel:BaseGameViewModel, IModifyGameViewModel
    {
      
        public ICommand SaveCommand { get; set; }

        public Boolean AllowTitleEdit => true;
        public AddGameViewModel(IDataService dataService) : base(dataService)
        {
            Game = new Game();
            SaveCommand = new RelayCommand(ExecuteSaveCommand);
        }

        private void ExecuteSaveCommand()
        {
            try
            {
                UsrMsg = Validate();
                if (!string.IsNullOrEmpty(UsrMsg)) { return; }
                DataService.CreateGame(Game);
                Messenger.Default.Send(new RefreshGamesMsg());
                UsrMsg = "Saved";
            }
            catch (Exception e)
            {
                UsrMsg = e.ToString();
            }
        }
    }
}
