using MvvmHelpers.Commands;
using onyx_Client_UI.Resources.Strings;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.State.Navigators;
using onyx_Client_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace onyx_Client_UI.ViewModels.HomeDetails
{
    public class HomeDetailsViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;

        public HomeDetailsViewModel()
        {
            _authenticator = DependencyService.Get<IAuthenticator>();
            SetDates();
            Balance = _authenticator.CurrentUser.Balance;
            Cashback = _authenticator.CurrentUser.Cashback;
            Bonus = _authenticator.CurrentUser.Bonus;
        }

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

        private void SetDates()
        {
            var visits = _authenticator.CurrentUser.Visits;
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

            throw new Exception("OOh fuck...");
        }

        private async Task OnExitCommand()
        {
            await _authenticator.Logout();
        }
        #endregion
    }
}
