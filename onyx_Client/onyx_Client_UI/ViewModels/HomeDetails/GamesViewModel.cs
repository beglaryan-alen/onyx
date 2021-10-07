using onyx_Client_UI.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace onyx_Client_UI.ViewModels.HomeDetails
{
    public class GamesViewModel : ViewModelBase
    {
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
        }
    }
}
