using MvvmHelpers.Commands;
using onyx_Client_UI.Models.Catalog;
using onyx_Client_UI.Services;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace onyx_Client_UI.ViewModels.HomeDetails
{
    public class SoftViewModel : ViewModelBase
    {
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
        }
    }
}
