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
        private readonly ICatalogInteraction _catalogInteraction;

        public GamesViewModel(ICatalogInteraction catalogInteraction)
        {
            _catalogInteraction = catalogInteraction;
            GamesCollection = new ObservableCollection<ApplicationCatalogResponse>(catalogInteraction.FetchGames().Result);
        }

        public ICommand GameCommand => new AsyncCommand<ApplicationCatalogResponse>(OnGameCommandAsync);


        private ObservableCollection<ApplicationCatalogResponse> _gamesCollection;
        public ObservableCollection<ApplicationCatalogResponse> GamesCollection
        {
            get => _gamesCollection;
            set => SetPropertyChanged(nameof(GamesCollection), ref _gamesCollection, value);
        }


        private async Task OnGameCommandAsync(ApplicationCatalogResponse application)
        {
            var p = Process.Start(application.SoftUrl, application.AppUrl);
            p.Start();
        }
    }
}
