using MvvmHelpers.Commands;
using onyx_Client_UI.Models.Catalog;
using onyx_Client_UI.Services;
using onyx_Client_UI.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;


namespace onyx_Client_UI.ViewModels.HomeDetails
{
    public class GamesViewModel : ViewModelBase
    {
        #region Interfaces

        private readonly ICatalogInteraction _catalogInteraction;

        #endregion

        #region Constructor

        public GamesViewModel()
        {
            _catalogInteraction = DependencyService.Get<ICatalogInteraction>();
            GamesCollection = new ObservableCollection<ApplicationCatalogResponse>(_catalogInteraction.FetchGames().Result);
        }

        #endregion

        #region Public Properties

        public ICommand GameCommand => new AsyncCommand<ApplicationCatalogResponse>(OnGameCommandAsync);


        private ObservableCollection<ApplicationCatalogResponse> _gamesCollection;
        public ObservableCollection<ApplicationCatalogResponse> GamesCollection
        {
            get => _gamesCollection;
            set => SetPropertyChanged(nameof(GamesCollection), ref _gamesCollection, value);
        }

        #endregion

        #region Private Helpers

        private async Task OnGameCommandAsync(ApplicationCatalogResponse application)
        {
            var p = Process.Start(application.AppUrl);
        }

        #endregion
    }
}
