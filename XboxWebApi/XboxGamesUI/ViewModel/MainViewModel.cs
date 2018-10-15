using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using XboxGamesUI.DataLayer;
using XboxGamesUI.Messaging;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using XboxGamesUI.Models;
using XboxGamesUI.Static;

namespace XboxGamesUI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase,IMainViewModel
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        ///
        ///
        private IDataService _dataService;
        private static object _lockRefresh = new object();


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


        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            MessengerInstance.Register<RefreshGamesMsg>(this, HandleRefreshMessage);
            LoadDataCommand = new RelayCommand(ExecuteLoadDataCmd);
            ClearFiltersCommand = new RelayCommand(ExecuteClearFiltersCommand);
            FilteredGames = new ObservableCollection<Game>();
            FilteredGames.CollectionChanged += FilteredGames_CollectionChanged;
            RatingOptions = new RatingOptions();
            ExecuteLoadDataCmd();

        }

        private void ExecuteClearFiltersCommand()
        {
            RatingsFilter=null;
        }

        private void FilteredGames_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Games");
        }

        private void HandleRefreshMessage(RefreshGamesMsg obj)
        {
            ExecuteLoadDataCmd();
        }

        private void ExecuteLoadDataCmd()
        {
            try
            {

                lock (_lockRefresh)
                {
                   
                    // I'm not showing a spinner in the UI, but would do in a real world app
                    Task.Factory.StartNew(() =>
                    {
                        UsrMsg = "Loading data...........";
                        // prevent blocking UI
                        return _dataService.GetGames();

                    }).ContinueWith((x) =>
                    {
                        if (x.IsFaulted)
                        {
                            var flattened = x.Exception.Flatten();

                            flattened.Handle(ex =>
                            {
                                UsrMsg = ex.ToString();
                                return true;
                            });
                        }

                        else
                        {
                            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (Action) (() =>
                            {
                                _games = x.Result;
                                ApplyFilter();
                                UsrMsg = String.Empty;
                            }));
                        }
                        // marshall on to main Ui thread
                      
                    });
                }
            }
            catch (Exception e)
            {
                UsrMsg = e.ToString();
            }
        }

        //private void ExecuteLoadDataCmd()
        //{
        //    try
        //    {

        //        lock (_lockRefresh)
        //        {
        //            UsrMsg = String.Empty;
        //            // I'm not showing a spinner in the UI, but would do in a real world app
        //            _games = _dataService.GetGames();
        //            ApplyFilter();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        UsrMsg = e.ToString();
        //    }
        //}

        public ICommand LoadDataCommand { get; set; }
        public ICommand ClearFiltersCommand { get; set; }
        public List<int> RatingOptions { get;  set; }
        private ObservableCollection<Game> _games;
        private ObservableCollection<Game> _filteredGames;
        public ObservableCollection<Game> FilteredGames
        {
            get { return _filteredGames; }
            set
            {
                if (_filteredGames == value)
                {
                    return;
                }
                _filteredGames = value;
                RaisePropertyChanged("FilteredGames");
            }
        }

        private int? _ratingsFilter;
        public int? RatingsFilter
        {
            get { return _ratingsFilter; }
            set
            {
                if (_ratingsFilter == value)
                {
                    return;
                }
                _ratingsFilter = value;
                RaisePropertyChanged("RatingsFilter");
                ApplyFilter();
            }

        }

        private void ApplyFilter()
        {
            //decided to implement client side as we load all data initially anyway
            try
            {
                if (_games == null) return;
                if (RatingsFilter == null)
                {
                    FilteredGames = _games;
                }
                else
                {
                    FilteredGames = new ObservableCollection<Game>(_games.Where(x => x.AvgRating.Count.Equals(RatingsFilter)));
                }
            }
            catch (Exception e)
            {
                UsrMsg = e.ToString();
            }
            
           
        }
    }
}