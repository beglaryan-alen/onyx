using onyx_Client_UI.Models;
using onyx_Client_UI.Resources.Strings;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace onyx_Client_UI.ViewModels.HomeDetails
{
    public class HomeDetailsViewModel : ViewModelBase
    {
        private readonly User CurrentUser;

        public HomeDetailsViewModel(User currentUser)
        {
            CurrentUser = currentUser;
            SetDates();

            Balance = currentUser.Balance;
            Cashback = currentUser.Cashback;
            Bonus = currentUser.Bonus;
        }

        #region Public Properties

        private Dictionary<string, DateTime> _dates;
        public Dictionary<string, DateTime> Dates
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

        #endregion

        #region Private Helpers

        private void SetDates()
        {
            var visits = CurrentUser.Visits;
            var closestDates = visits.Where(x => x <= DateTime.Now).ToList();

            Dates = new Dictionary<string, DateTime>();
            Dates.Add(GetWeekNameFromDate(closestDates[0].DayOfWeek), closestDates[0]);
            Dates.Add(GetWeekNameFromDate(closestDates[1].DayOfWeek), closestDates[1]);
            Dates.Add(GetWeekNameFromDate(closestDates[2].DayOfWeek), closestDates[2]);
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

        #endregion
    }
}
