using System;
using System.Threading;

namespace CriticalSectionDemo
{
    class SyncWithLock
    {
        private BankTransaction transaction;

        public SyncWithLock(BankTransaction transaction)
        {
            this.transaction = transaction;
        }

        public void IncreaseSync()
        {
            lock (this.transaction)
            { 
                Console.WriteLine("Enter Thread: {0}", Thread.CurrentThread.Name);
                this.transaction.IncreaseAccountBalance();
            }

        }

        public void DecreaseSync()
        {
            lock(this.transaction)
            {
                Console.WriteLine("Enter Thread: {0}", Thread.CurrentThread.Name);
                this.transaction.DecreaseAccountBalance();
            }
        }
    }
}
