using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    internal class Bank
    {
        public string Name;
        public List<Customer> CustomerList;
        public Bank(string name)
        {
            this.Name = name;
            this.CustomerList = new List<Customer>();
        }
        public void AddAccount(Customer customer)
        {
            CustomerList.Add(customer);
        }
        public void RemoveAccount(Customer customer)
        {
            CustomerList.Remove(customer);
        }
        public void GetCustomerDetails()
        {
            foreach(Customer customer in CustomerList)
            {
                customer.GetAccountDetails();     
            }
        }
        public bool TransferFund(Account fromAccount, Account toAccount, decimal amount)
        {
            bool transfer =  fromAccount.Withdraw(amount);
              
            if(transfer)
            {
                toAccount.Deposit(amount);
                return true;
            }
            Console.WriteLine("Transfer failed, Insufficient Balance!!");
            return false;

        }
    }
   
}
