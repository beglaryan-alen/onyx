using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models.Register
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
    }
}
