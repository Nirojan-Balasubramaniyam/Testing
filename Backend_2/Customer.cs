using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    internal class Customer
    {
        public int CustomerID;
        public string Name;
        public string Email;
        public List<Account> AccountList;
        public Customer() { }
        public Customer(int customerID, string name, string email)
        {
            this.CustomerID = customerID;
            this.Name = name;
            this.Email = email;
            this.AccountList = new List<Account>();
        }
        public void AddAccount(Account account)
        {
            AccountList.Add(account);
        }
        public void RemoveAccount(Account account)
        {
            AccountList.Remove(account);
        }
        public void GetAccountDetails()
        {
            Console.WriteLine($"Customer ID: {CustomerID}\nCustomer Name: {Name}\nCustomer Email: {Email}");
            foreach (Account account in AccountList)
            {
                var balance=account.GetBalance();
                Console.WriteLine($"Accoount Number: {account.AccountNumber}, Balance: {account.GetBalance()}\n");
                //AccountList.GetAccountDetails();
            }
        }
    }
}
