using System;
using System.Threading;

namespace CriticalSectionDemo
{
    class BankTransaction
    {
        private BankAccount bankAccount;

        private decimal increaseAmount;

        private decimal decreaseAmount;

        public BankTransaction(BankAccount bankAccount, decimal increaseAmount, decimal decreaseAmount)
        {
            this.bankAccount = bankAccount;
            this.increaseAmount = increaseAmount;
            this.decreaseAmount = decreaseAmount;

            Console.WriteLine("Open 2 threads that will try to add and remove from the account balance 3 times.");
        }

        public void DecreaseAccountBalance()
        {
            for (int i = 0; i < 3; i++)
            {
                this.bankAccount.DecreaseBalance(this.decreaseAmount);
                Thread.Sleep(500);
            }
        }

        public void IncreaseAccountBalance()
        {
            for (int i = 0; i < 3; i++)
            {
                this.bankAccount.IncreaseBalance(this.increaseAmount);
                Thread.Sleep(500);
            }
        }

        public BankAccount GetAccount()
        {
            return this.bankAccount;
        }
    }
}
