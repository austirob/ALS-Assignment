/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:XboxGamesUI"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
//using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator;
using XboxGamesUI.DataLayer;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;
using XboxGamesUI.Models;
using XboxGamesUI.ServiceLayer.REST;

namespace XboxGamesUI.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public static IUnityContainer Container { get; private set; }
        public ViewModelLocator()
        {
            Container = new UnityContainer();
           
            IXboxGamesService xboxGamesService = new XboxGamesService();
            Container.RegisterInstance<IXboxGamesService>(xboxGamesService, new ContainerControlledLifetimeManager());

            IDataService ds = new DataService(xboxGamesService);
            Container.RegisterInstance<IDataService>(ds, new ContainerControlledLifetimeManager());
            Container.RegisterType<IMainViewModel,MainViewModel>();
            Container.RegisterType<IRatingsViewModel,RatingsViewModel>();
            Container.RegisterType<IModifyGameViewModel,EditGameViewModel>("edit");
            Container.RegisterType<IModifyGameViewModel,AddGameViewModel>("add");

        }

        public IMainViewModel Main
        {
            get
            {
                return Container.Resolve<IMainViewModel>();

            }
        }

        public IRatingsViewModel Ratings  (Game game)
        {
              
                return Container.Resolve<IRatingsViewModel>(new ParameterOverride("game", game));
           
        }

        public IModifyGameViewModel Add
        {
            get
            {
                return Container.Resolve<IModifyGameViewModel>("add");
            }
        }

        public IModifyGameViewModel Edit(Game game)
        {
            
                return Container.Resolve<IModifyGameViewModel>("edit", new ParameterOverride( "game", game ));
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}