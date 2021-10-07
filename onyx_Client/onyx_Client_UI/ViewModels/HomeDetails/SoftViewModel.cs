using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace onyx_Client_UI.ViewModels.HomeDetails
{
    public class SoftViewModel : ViewModelBase
    {
        Services.ICatalogInteraction _catalog;
        private IEnumerable<Models.Catalog.ApplicationCatalogResponse> _soft;
        public IEnumerable<Models.Catalog.ApplicationCatalogResponse> Soft
        {
            get => _soft;
            set => SetPropertyChanged(nameof(Soft), ref _soft, value);
        }


        public SoftViewModel(Services.ICatalogInteraction catalog)
        {
            _catalog = catalog;
            GetSoft();
        }


        private async Task GetSoft()
        {
            var response = await _catalog.FetchSoft();
            Soft = response;
        }
    }
}
