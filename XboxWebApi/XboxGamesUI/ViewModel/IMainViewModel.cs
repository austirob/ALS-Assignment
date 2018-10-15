using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XboxGamesUI.Messaging;
using XboxGamesUI.Models;

namespace XboxGamesUI.ViewModel
{
    public interface IMainViewModel
    {
        //void ExecuteClearFiltersCommand();
        //void FilteredGames_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e);
        //void HandleRefreshMessage(RefreshGamesMsg obj);
        //oid ExecuteLoadDataCmd();
        ICommand LoadDataCommand { get; set; }
        ICommand ClearFiltersCommand { get; set; }
        List<int> RatingOptions { get; set; }
        ObservableCollection<Game> FilteredGames { get; set; }
        //void ApplyFilter();

    }
}
