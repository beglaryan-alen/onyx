<<<<<<< HEAD
﻿using MvvmHelpers.Commands;
using onyx_Client_UI.Models.Catalog;
using onyx_Client_UI.Services;
using onyx_Client_UI.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
=======
﻿using onyx_Client_UI.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf

namespace onyx_Client_UI.ViewModels.HomeDetails
{
    public class GamesViewModel : ViewModelBase
    {
<<<<<<< HEAD
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
=======
        Services.ICatalogInteraction _catalog;
        private IEnumerable<Models.Catalog.ApplicationCatalogResponse> _games;
        public IEnumerable<Models.Catalog.ApplicationCatalogResponse> Games
        {
            get => _games;
            set => SetPropertyChanged(nameof(Games), ref _games, value);
        }


        public GamesViewModel(Services.ICatalogInteraction catalog)
        {
            _catalog = catalog;
            GetGames();
        }


        private async Task GetGames()
        {
            var response = await _catalog.FetchGames();
            Games = response;
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
        }
    }
}
