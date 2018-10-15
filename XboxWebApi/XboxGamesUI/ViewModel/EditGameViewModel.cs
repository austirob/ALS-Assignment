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
   public class EditGameViewModel:BaseGameViewModel, IModifyGameViewModel
    {
      
        public ICommand SaveCommand { get; set; }

        // As we are using the same view for Add and Edit
        // use this property to determine if user
        // can edit the game title
        public Boolean AllowTitleEdit => false;
        public EditGameViewModel(Game game, IDataService dataService):base(dataService)
        {
            Game = game;
            SaveCommand = new RelayCommand(ExecuteSaveCommand);
        }

        private void ExecuteSaveCommand()
        {
            try
            {
                UsrMsg = Validate();
                if (!string.IsNullOrEmpty(UsrMsg)){return;}
                DataService.UpdateGame(Game);
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
