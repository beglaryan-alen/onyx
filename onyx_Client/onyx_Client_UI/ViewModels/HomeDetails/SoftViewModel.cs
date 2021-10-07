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
        #region Interfaces

        private readonly ICatalogInteraction _catalogInteraction;

        #endregion

        #region Constructor

        public SoftViewModel()
        {
            _catalogInteraction = DependencyService.Get<ICatalogInteraction>();
            SoftsCollection = new ObservableCollection<ApplicationCatalogResponse>(_catalogInteraction.FetchSoft().Result);
        }

        #endregion

        #region Public Properties

        public ICommand SoftCommand => new AsyncCommand<ApplicationCatalogResponse>(OnSoftCommandAsync);

        private ObservableCollection<ApplicationCatalogResponse> _softsCollection;
        public ObservableCollection<ApplicationCatalogResponse> SoftsCollection
        {
            get => _softsCollection;
            set => SetPropertyChanged(nameof(SoftsCollection), ref _softsCollection, value);
        }

        #endregion

        #region Private Helpers

        private async Task OnSoftCommandAsync(ApplicationCatalogResponse application)
        {
            var p = Process.Start(application.AppUrl);
            p.Start();
        }

        #endregion

    }
}
