using System;
using System.Threading;

namespace CriticalSectionDemo
{
    class MainThread
    {
        static void Main(string[] args)
        {
            ushort option;

            Console.WriteLine("Pick up an option.");
            Console.WriteLine("1) Use unsynchronized transaction");
            Console.WriteLine("2) Use synchronized transaction with Monitor.{Enter, Exit}");
            Console.WriteLine("3) Use synchronized transaction with lock");

            UInt16.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: UseUnsynchronizedTransaction(); break;
                case 2: UseSynchronizedWithMonitorEnterExit(); break;
                case 3: UseSynchronizedWithLock(); break;
                default: Console.WriteLine("Wrong number"); break;
            }
        }

        public static BankTransaction GetAccountInfo()
        {
            decimal balance, increaseAmount, decreaseAmount;
            
            Console.Write("Enter account balance: ");
            Decimal.TryParse(Console.ReadLine(), out balance);
            Console.Write("Enter transaction increase amount: ");
            Decimal.TryParse(Console.ReadLine(), out increaseAmount);
            Console.Write("Enter transaction decrease amount: ");
            Decimal.TryParse(Console.ReadLine(), out decreaseAmount);

            // return the BankAcount and UnsynchronizedTransaction object
            return  new BankTransaction(new BankAccount(balance), increaseAmount, decreaseAmount);
        }

        public static void UseSynchronizedWithLock()
        {
            BankTransaction tran = GetAccountInfo();

            SyncWithLock syncTran = new SyncWithLock(tran);

            Thread th1 = new Thread(new ThreadStart(syncTran.IncreaseSync));
            th1.Name = "Increase";
            th1.Start();

            Thread th2 = new Thread(new ThreadStart(syncTran.DecreaseSync));
            th2.Name = "Decrease";
            th2.Start();
        }

        public static void UseSynchronizedWithMonitorEnterExit()
        {
            BankTransaction tran = GetAccountInfo();

            SyncWithMonitor syncTran = new SyncWithMonitor(tran);

            Thread th1 = new Thread(new ThreadStart(syncTran.IncreaseSync));
            th1.Name = "Increase";
            th1.Start();

            Thread th2 = new Thread(new ThreadStart(syncTran.DecreaseSync));
            th2.Name = "Decrease";
            th2.Start();
        }
        
        public static void UseUnsynchronizedTransaction()
        {
            BankTransaction tran = GetAccountInfo();

            Thread th1 = new Thread(new ThreadStart(tran.DecreaseAccountBalance));
            th1.Start();

            Thread th2 = new Thread(new ThreadStart(tran.IncreaseAccountBalance));
            th2.Start();

            th1.Join();
            th2.Join();

            Console.WriteLine("Current Account balance: {0}", tran.GetAccount().GetBalance());
        }
    }
}
