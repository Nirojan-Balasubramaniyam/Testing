using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    internal class Transaction
    {
        public int TransactionID;
        public int AccountNumber1;
        public int AccountNumber2;
        public decimal Amount;
        public string TransactionType;
        public DateTime date;
        public Transaction(int accountNumber, decimal amount, string transactionType)
        {
            Random random = new Random();
            TransactionID = random.Next();
            AccountNumber1 = accountNumber;
            Amount = amount;
            TransactionType = transactionType;
            this.date = DateTime.Now;
        }
        public Transaction(int accountNumber1, int accountNumber2,decimal amount, string transactionType)
        {
            Random random = new Random();
            TransactionID = random.Next();
            AccountNumber1 = accountNumber1;
            AccountNumber2 = accountNumber2;
            Amount = amount;
            TransactionType = transactionType;
            this.date = DateTime.Now;
        }

        public void GetTransactionDetails()
        {
            Console.WriteLine($"Transaction ID: {TransactionID}\nAccount Number: {AccountNumber1}\nTransaction Type: {TransactionType}\nAmount: {Amount}\nDate: {date} ");
        }
        public void GetTransferTransactionDetails()
        {
            Console.WriteLine($"Transaction ID: {TransactionID}\nSender Account Number: {AccountNumber1}\nReceiver Account Number: {AccountNumber2}\nTransaction Type: {TransactionType}\nAmount: {Amount}\nDate: {date} ");
        }
    }
}
