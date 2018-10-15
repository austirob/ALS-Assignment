using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XboxGamesUI.Models;
using XboxGamesUI.Static;

namespace XboxGamesUI.ViewModel
{
    public interface IRatingsViewModel
    {
        List<int> Ratings { get; set; }
        ICommand SubmitRatingCommand { get; set; }
        int SelectedRating { get; set; }

    }
}
