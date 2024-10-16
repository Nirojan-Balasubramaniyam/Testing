using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    internal class Program
    {
        public static Bank bank = new Bank("BOC");

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1.\tCreate a Customer\r\n2.\tCreate an Account\r\n3.\tDeposit Funds\r\n4.\tWithdraw Funds\r\n5.\tTransfer Funds\r\n6.\tView Customer Details\r\n7.\tExit\r\n");
                string UserRes=Console.ReadLine();  
                switch(UserRes)
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        CreateAccount();
                        break;
                    case "3":
                        DepositFunds();
                        break;
                    case "4":
                        WithdraFunds();
                        break;
                    case "5":
                        TransferFunds();
                        break;
                    case "6":
                        ViewCustomerDetails();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Please Select Listed Valid Functionality Number");
                        break;
                }
            }
           
        }
        public static void CreateCustomer()
        {
            Console.Write("Enter Customer ID: ");
            int customerID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Customer Email: ");
            string customerEmail = Console.ReadLine();
            bank.AddAccount(new Customer(customerID,customerName,customerEmail));
            Console.WriteLine("Customer Added Successfully");

        }
        public static void CreateAccount()
        {
            Console.Write("Enter Customer ID: ");
            int customeriD = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Account Number: ");
            int accountNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Select Account Type: \n1.\tSaving Account  \n2.\tChecking Account  ");
            string accountType = (Console.ReadLine());
            var customer = bank.CustomerList.Find(cstmr=>cstmr.CustomerID == customeriD);
            if (customer == null)
            {
                Console.WriteLine("Customer ID is Invalid!!!");
            }
            else
            {
                Account newAccount;
                if (accountType == "1")
                {
                    newAccount = new SavingAccount(accountNum, customeriD);
                }
                else if (accountType == "2")
                {
                    newAccount = new CheckingAccount(accountNum, customeriD);
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Account Type!!!");
                    return;
                }
                customer.AddAccount(newAccount);
                Console.WriteLine("Account Added Sucessfully");
            }
        }
        public static void DepositFunds()
        {

            Console.Write("Enter Account Number: ");
            int accountNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Ammount to Deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            var findedAccount = FindAccount(accountNum);
            if (findedAccount == null)
            {
                Console.WriteLine("Please Enter registered Account Number!!");
            }
            else
            {
                findedAccount.Deposit(amount);
                Console.WriteLine("Successfully Deposited");
                Transaction transaction = new Transaction(accountNum, amount, "Deposit");
                transaction.GetTransactionDetails();
            }
            
        }
        /*public static void WithdraFunds()
        {
            Console.Write("Enter Account Number: ");
            int accountNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How Do You Withdraw: \n1.\tAmmount  \n2.\tPercentage of Amount ");
            string WithdrawType = Console.ReadLine();
           
            Account findedAccount = FindAccount(accountNum);
           
            decimal amount = 0;
            double balancePercentage = 0.0;
            if(WithdrawType== "1")
            {
                Console.Write("Enter Ammount to Withdraw: ");
                amount = Convert.ToDecimal(Console.ReadLine());
                findedAccount.Withdraw(amount);
                
            }
            else if(WithdrawType== "2")
            {
                Console.Write("Enter Percentage of Your Balance to Withdraw: ");
                balancePercentage = Convert.ToDouble(Console.ReadLine());
                findedAccount.Withdraw(balancePercentage);
            }
            Console.WriteLine("Successfully Withdrawed");
            Transaction transaction = new Transaction(accountNum, amount, "Withdraw");
            transaction.GetTransactionDetails();
        }*/

        //Testing
        public static void WithdraFunds()
        {
            Console.Write("Enter Account Number: ");
            int accountNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount or Percentage of amount to Withdraw: ");
            string userInput = Console.ReadLine();
            var findedAccount = FindAccount(accountNum);
            if (findedAccount == null)
            {
                Console.WriteLine("Please Enter registered Account Number!!");
            }else
            {
                double balancePercentage = 0;
                decimal amount = 0;
                decimal withdrawAmount = 0;
                bool withdrawStatus;

                if (userInput.EndsWith("%"))
                {
                    balancePercentage = Convert.ToDouble(userInput.TrimEnd('%'));
                    withdrawAmount = (decimal)(balancePercentage / 100) * findedAccount.Balance;
                    withdrawStatus = findedAccount.Withdraw(balancePercentage);
                }
                else
                {
                    amount = Convert.ToDecimal(userInput);
                    withdrawAmount = amount;
                    withdrawStatus = findedAccount.Withdraw(withdrawAmount);
                }
                if (withdrawStatus)
                {
                    Console.WriteLine("Successfully Withdrawed");
                    Transaction transaction = new Transaction(accountNum, withdrawAmount, "Withdraw");
                    transaction.GetTransactionDetails();
                }
                else
                {
                    Console.WriteLine("Withdraw Failed due to Insufficient Balance!!!");
                }
            }
            
            

           
        }
        public static void TransferFunds()
        {
            Console.Write("Enter Sender Account Number: ");
            int SourceaccountNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Reciever Account Number: ");
            int ToaccountNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Ammount to Transfer: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            var fromAccount = FindAccount(SourceaccountNum);
            var toAccount = FindAccount(ToaccountNum);
            if(fromAccount != null && toAccount != null)
            {
                bool transferFund = bank.TransferFund(fromAccount, toAccount, amount);
                if(transferFund)
                {
                    Console.WriteLine("Fund Transfered Successfully");
                    Transaction transaction = new Transaction(SourceaccountNum, ToaccountNum, amount, "Fund Transfer");
                    transaction.GetTransferTransactionDetails();
                    return;
                }

            }
            else
            {
                Console.WriteLine("Sender or Receiver Account is not found!!!");
            }
        }
        public static void ViewCustomerDetails()
        {
            Console.WriteLine("Select the View Customer Option: \n1.\tView All Customer Detail: \n2.\tView particular Customer Detail: ");
            string selection = Console.ReadLine();
            if(selection == "1")
            {
                bank.GetCustomerDetails();
            }else if(selection == "2")
            {
                Console.Write("Enter Customer ID: ");
                int customerID = Convert.ToInt32(Console.ReadLine());
                Customer customer = new Customer();
                customer = bank.CustomerList.Find(cstmr => cstmr.CustomerID == customerID);
                if (customer == null)
                {
                    Console.WriteLine("Please Enter Valid Customer ID!!!");
                }
                else
                {
                    customer.GetAccountDetails();
                }
            }
           
           
        }
        public static Account FindAccount(int accountNum)
        {
            Account Accnt = new Account();
            foreach (Customer customers in bank.CustomerList)
            {
                Accnt = customers.AccountList.Find(accnt => accnt.AccountNumber == accountNum);
                if (Accnt != null)
                {
                    return Accnt;
                }

            }
            return null;
        }
    }
}
