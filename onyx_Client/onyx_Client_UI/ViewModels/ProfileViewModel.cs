using onyx_Client_UI.Services;
using onyx_Client_UI.ViewModel;
using System.Threading.Tasks;

namespace onyx_Client_UI.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly IUserProfile _userProfile;

        public ProfileViewModel()
        {
            _userProfile = DependencyService.Get<IUserProfile>();
            Task.Run(async () => await SetProperties());
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set => SetPropertyChanged(nameof(ImageUrl), ref _imageUrl, value);
        }

        private int _id;
        public int ID
        {
            get => _id;
            set => SetPropertyChanged(nameof(ID), ref _id, value);
        }

        private int _place;
        public int Place
        {
            get => _place;
            set => SetPropertyChanged(nameof(Place), ref _place, value);
        }

        private async Task SetProperties()
        {
            var response = await _userProfile.FetchUserProfile();
            ID = response.Code;
            //ImageUrl = response.ImageUrl;
            //Place = response.Place;
            ImageUrl = "https://cq.ru/storage/uploads/images/973102/1596554043824.png";
            Place = 21;
        }
    }
}
