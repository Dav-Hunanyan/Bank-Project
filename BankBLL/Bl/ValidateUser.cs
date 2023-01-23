using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankBLL.Bl
{
    public class ValidateUser
    {
        static bool MailValid(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        static bool PhoneValid(string phone)
        {
            return Regex.IsMatch(phone, @"^\+374\([1-9][0-9]\)[0-9]{3}\-[0-9]{3}");
        }

        static bool PasswordValid(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

        }
        static bool NameValid(string name)
        {
            return Regex.IsMatch(name, @"^[A-Z][a-zA-Z]*$");

        }

        static bool SurnameValid(string surname)
        {
            return Regex.IsMatch(surname, @"^[A-Z][a-zA-Z]*$");

        }

        static bool BirthdayValid(DateTime date)
        {
            return Regex.IsMatch(date.ToString(), @"^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$");
        }
    }
}
