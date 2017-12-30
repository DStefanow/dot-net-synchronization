using System;

namespace CriticalSectionDemo
{
    class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal balance)
        {
            this.balance = balance;
        }

        public decimal GetBalance()
        {
            return this.balance;
        }

        public void IncreaseBalance(decimal amount)
        {
            this.balance += amount;
            Console.WriteLine("Increase with: {0}. New Balance: {1}", amount, this.balance);
        }

        public void DecreaseBalance(decimal amount)
        {
            if (this.balance - amount >= 0)
            {
                this.balance -= amount;
                Console.WriteLine("Decrease with: {0}. New Balance: {1}", amount, this.balance);
            }
            else
            {
                Console.WriteLine("There aren't enough money in the account.\nTrying to withdraw: {0}, from balance - {1}",
                    amount, balance);
            }

        }
    }
}
