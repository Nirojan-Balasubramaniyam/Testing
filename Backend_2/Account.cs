using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    internal class Account
    {
        public int AccountNumber;
        public decimal Balance;
        public int CustomerID;
        public Account() 
        { 
        }
        public Account(int accountNumber, int customerID)
        {
            AccountNumber = accountNumber;
            CustomerID = customerID;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public bool Withdraw(decimal amount)
        {
            if (Balance > amount)
            {
                Balance -= amount;
                return true;
            }
            return false;

       
            
            
        }
        public bool Withdraw(double percentage)
        {
            decimal amount = (decimal)percentage / 100 * Balance;
            
            if(Balance > amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
