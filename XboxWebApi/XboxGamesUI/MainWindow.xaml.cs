using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XboxGamesUI.Mapping;
using XboxGamesUI.Models;
using XboxGamesUI.ViewModel;
using XboxGamesUI.Views;

namespace XboxGamesUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModelLocator _vmLocator;
        public MainWindow()
        {
            InitializeComponent();
            AutoMapper.Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            _vmLocator = new ViewModelLocator();
        }

        private void RateGame(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var game = btn.DataContext as Game;
            var RatingsWindow = new Ratings();
            RatingsWindow.DataContext = _vmLocator.Ratings(game);
            RatingsWindow.ShowDialog();
            
        }

        private void AddGame(object sender, RoutedEventArgs e)
        {
            var addGameWindow = new ModifyGame();
            addGameWindow.DataContext = _vmLocator.Add;
            addGameWindow.ShowDialog();
        }

        private void EditGame(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var game = btn.DataContext as Game;
            var editGameWindow = new ModifyGame();
            editGameWindow.DataContext = _vmLocator.Edit(game);
            editGameWindow.ShowDialog();
        }
    }
}
