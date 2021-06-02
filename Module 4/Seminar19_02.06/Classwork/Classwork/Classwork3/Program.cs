using System;
using System.Threading;
using System.Threading.Tasks;
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
                    Console.WriteLine($" Счет после покупки: {accountAmount}");
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
            Task[] tasks = new Task[10];
            BankAccount dep = new BankAccount(1000);
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() => dep.DoTransactions(i));
               // tasks[i].RunSynchronously();
            }
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i].RunSynchronously();
           }
        }
    }
}
