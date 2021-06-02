using System;
using System.Threading;
namespace Classwork1
{

    class BankAccount
    {
        private object thisLock = new object();
        volatile int accountAmount;
        Random r = new Random();
        public BankAccount(int sum) => accountAmount = sum;
        public void DoTransactions(object index)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine($"Работа с потоком номер {(int)index + 1}:");
                    Buy(r.Next(1, 50), (int)index);
                    Thread.Sleep(r.Next(1, 10));
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Обработано исключение:{ ex.Message}. Поток завершает работу...");
            }
        }

        int Buy(int sum, int index)
        {
            if (accountAmount == 0)
                throw new InvalidOperationException($"Нулевой баланс...");
            // условие никогда не выполнится, пока вы не закомментируете lock.
            if (accountAmount < 0)
                throw new InvalidOperationException($"Отрицательный баланс");
            Monitor.Enter(thisLock);
            Console.WriteLine($"Попытка покупки пользователем номер {index + 1}:)");
            try
            {
                if (accountAmount >= sum)
                {
                    Console.WriteLine($"Состояние счета: {accountAmount}");
                    Console.WriteLine($" Покупка на сумму: {sum}");
                    accountAmount = accountAmount - sum;
                    Console.WriteLine($" Счет после пок.: {accountAmount}");
                    return sum;
                }
                else
                {
                    Console.WriteLine("Транзакция не была завершена успешно: недостаточно денег на счету");
                    return 0; // не хватает денег - отказываем в покупке
                }
            }
            finally { Monitor.Exit(thisLock); }
        }


    }





    class Program
    {
        static void Main()
        {
            Thread[] threads = new Thread[10];
            BankAccount dep = new BankAccount(1000);
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(dep.DoTransactions);
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start(i);
            }
        }
    }
}
