using MvvmHelpers.Commands;
using onyx_Client_UI.Models.Catalog;
using onyx_Client_UI.Services;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
<<<<<<< HEAD
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
=======
using System.Collections.Generic;
using System.Threading.Tasks;
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf

namespace onyx_Client_UI.ViewModels.HomeDetails
{
    public class SoftViewModel : ViewModelBase
    {
<<<<<<< HEAD
        private readonly ICatalogInteraction _catalogInteraction;


        public SoftViewModel(ICatalogInteraction catalogInteraction)
        {
            _catalogInteraction = catalogInteraction;
            SoftsCollection = new ObservableCollection<ApplicationCatalogResponse>(catalogInteraction.FetchSoft().Result);
        }

        public ICommand SoftCommand => new AsyncCommand<ApplicationCatalogResponse>(OnSoftCommandAsync);

        private ObservableCollection<ApplicationCatalogResponse> _softsCollection;
        public ObservableCollection<ApplicationCatalogResponse> SoftsCollection
        {
            get => _softsCollection;
            set => SetPropertyChanged(nameof(SoftsCollection), ref _softsCollection, value);
        }


        private async Task OnSoftCommandAsync(ApplicationCatalogResponse application)
        {
            var p = Process.Start(application.AppUrl);
            p.Start();
=======
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
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
        }
    }
}
