using System;
using System.Collections.Generic;

namespace onyx_Client_UI.Models
{
    public enum Gender
    {
        Man,
        Women,
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string IDNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public List<DateTime> Visits { get; set; }
        public decimal Balance { get; set; }
        public decimal Cashback { get; set; }
        public decimal Bonus { get; set; }
    }
}
