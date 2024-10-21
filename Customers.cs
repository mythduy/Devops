using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    internal class Customers
    {
        private string name;
        private string iDCard;
        private string citizenship;
        private string phone;
        private string email;
        private DateTime dateOfBirth;
        private string address;

        public Customers(string name, string iDCard, string citizenship, string phone, string email, DateTime dateOfBirth, string address)
        {
            this.name = name;
            this.iDCard = iDCard;
            this.citizenship = citizenship;
            this.phone = phone;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
        }
        ~Customers()
        {
            Console.WriteLine();
        }
        public string Name { get => name; set => name = value; }
        public string IDCard { get => iDCard; set => iDCard = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Address { get => address; set => address = value; }

        public string CalculateAge()
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if(age >= 18)
            {
                return "You are an adult";
            }
            else
            {
                return "You are a minor";
            }
        }
        public void UpdateContact(string phone, string email, string address)
        {
            this.phone = phone;
            this.email = email;
            this.address = address;
        }
        public bool CheckEmail()
        {
            if (email.Contains("@") && email.Contains(".com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string toString()
        {
            return $"Name: {name}\nID Card: {iDCard}\nCitizenship: {citizenship}\nPhone: {phone}\nEmail: {email}\nDate of Birth: {dateOfBirth}\nAddress: {address}";
        }
    }
}
