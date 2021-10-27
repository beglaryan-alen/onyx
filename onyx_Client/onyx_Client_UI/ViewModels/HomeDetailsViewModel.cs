using MvvmHelpers.Commands;
using onyx_Client_UI.Models.UserProfile;
using onyx_Client_UI.Resources.Strings;
using onyx_Client_UI.Services;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace onyx_Client_UI.ViewModels
{
    public class HomeDetailsViewModel : ViewModelBase
    {
        #region Intarfaces

        private readonly IUserProfile _userProfile;
        private readonly IAuthenticator _authenticator;

        #endregion

        #region Constructor

        public HomeDetailsViewModel()
        {
            _userProfile = DependencyService.Get<IUserProfile>();
            _authenticator = DependencyService.Get<IAuthenticator>();
            Task.Run(async () => await SetDates());
            Task.Run(async () => await SetBalance());
        }

        #endregion

        #region Public Properties

        private Dictionary<DateTime, string> _dates;
        public Dictionary<DateTime, string> Dates
        {
            get => _dates;
            set => SetPropertyChanged(nameof(Dates), ref _dates, value);
        }

        private decimal _balance;
        public decimal Balance
        {
            get => _balance;
            set => SetPropertyChanged(nameof(Balance), ref _balance, value);
        }

        private decimal _cashback;
        public decimal Cashback
        {
            get => _cashback;
            set => SetPropertyChanged(nameof(Cashback), ref _cashback, value);
        }

        private decimal _bonus;
        public decimal Bonus
        {
            get => _bonus;
            set => SetPropertyChanged(nameof(Bonus), ref _bonus, value);
        }

        public ICommand ExitCommand => new AsyncCommand(OnExitCommand);

        #endregion

        #region Private Helpers

        private async Task SetBalance()
        {
            var details = await _userProfile.FetchBalance();
            Balance = details.Current;
            Cashback = details.Cashback;
            Bonus = details.Bonus;
        }

        private async Task SetDates()
        {
            var visits = await _userProfile.FetchVisitHistory();
            var closestDates = visits.OrderByDescending(x => x.Date).ToList();

            Dates = new Dictionary<DateTime, string>();
            Dates.Add(closestDates[0], GetWeekNameFromDate(closestDates[0].DayOfWeek));
            Dates.Add(closestDates[1], GetWeekNameFromDate(closestDates[1].DayOfWeek));
            Dates.Add(closestDates[2], GetWeekNameFromDate(closestDates[2].DayOfWeek));
        }

        private string GetWeekNameFromDate(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return Strings.Monday;
                case DayOfWeek.Tuesday:
                    return Strings.Tuesday;
                case DayOfWeek.Wednesday:
                    return Strings.Wednesday;
                case DayOfWeek.Thursday:
                    return Strings.Thursday;
                case DayOfWeek.Friday:
                    return Strings.Friday;
                case DayOfWeek.Saturday:
                    return Strings.Saturday;
                case DayOfWeek.Sunday:
                    return Strings.Sunday;
            }

            throw new Exception("Can't get week day. ");
        }

        private async Task OnExitCommand()
        {
            await _authenticator.Logout();
        }
        #endregion
    }
}
