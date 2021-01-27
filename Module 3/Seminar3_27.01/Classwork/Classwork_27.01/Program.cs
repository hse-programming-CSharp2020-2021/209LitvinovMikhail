using System;

namespace Classwork_27._01
{

    delegate void CoordChanged(Dot dot);

    class Dot {
        public double X { get; private set; }
        public double Y { get; private set; }
        // ------------------
        public Dot(double x, double y) {
            this.X = x;
            this.Y = y;
        }

        public static event CoordChanged OnCoordChanged;

        public void DotFlow() {
            Random rnd = new Random();
            for (int i = 0; i < 10; ++i) {
                this.X = rnd.Next(-10, 11) + rnd.NextDouble();
                this.Y = rnd.Next(-10, 11) + rnd.NextDouble();
                if (this.X < 0 && this.Y < 10) {
                    Dot.OnCoordChanged(this);
                }
            }

        }
    }

    // --------------------------------------------

    delegate void SquareSizeChanged(double param);

    class Square {

        private Dot first;
        private Dot second;

        public Dot First{ get => this.first; set { this.first = value;  this.OnSizeChanged?.Invoke(this.first.X - this.second.X); } }
        public Dot Second { get => this.second; set { this.second = value; this.OnSizeChanged?.Invoke(this.first.X - this.second.X); } }

        public Square(Dot first, Dot second) {
            this.First = first;
            this.Second = second;
        }

        public event SquareSizeChanged OnSizeChanged;
    }


    // ------------------------------------------

    class Account
    {
        public class AccountTransactionsArgs : EventArgs {
            public string Action { get; private set; }
            public int Difference { get; private set; }
            public int Sum { get; private set; }

            public AccountTransactionsArgs(string message, int difference, int sum) {
                this.Action = message;
                this.Difference = difference;
                this.Sum = sum;
            }
        }

        // public delegate void Transactions(string action, int difference, int sum);

        public event EventHandler<AccountTransactionsArgs> OnTransactions;
        public Account(int sum) {
            Sum = sum;

            this.OnTransactions += delegate (object sender, AccountTransactionsArgs args)
            {
                switch (args.Action)
                {
                    case "Put": Console.WriteLine($"You put {args.Difference} on your account; current balance = {sum}"); break;
                    case "Take": Console.WriteLine($"You took {args.Difference} from your account; current balance = {sum}"); break;
                    case "Failure": Console.WriteLine($"You tried to take {args.Difference} from your account, but to no avail; current balance = {sum}"); break;
                }
            };
        }
        // сумма на счете
        public int Sum { get; private set; }
        // добавление средств на счет
        public void Put(int sum)
        {
            Sum += sum;
            this.OnTransactions?.Invoke(this, new AccountTransactionsArgs("Put", sum, this.Sum));
        }
        // списание средств со счета
        public void Take(int sum)
        {
            if (Sum >= sum) {
                Sum -= sum;
                this.OnTransactions?.Invoke(this, new AccountTransactionsArgs("Take", sum, this.Sum));
            }
            this.OnTransactions?.Invoke(this, new AccountTransactionsArgs("Failure", sum, this.Sum));
        }
    }


    class Program {

        public static void PrintInfo(Dot A) {
            Console.WriteLine($"First coordinate: {A.X}, second coordinate: {A.Y}");
        }

        public static void SquareConsoleInfo(double A) {
            Console.WriteLine($"{A:F2}");
        }

        public static void Main(string[] args) {
            /*Dot D = new Dot(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Dot.OnCoordChanged += Program.PrintInfo;
            D.DotFlow();
            -------------------------------------------*/
            /*Square S = new Square(new Dot(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())), 
                new Dot(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
            S.OnSizeChanged += Program.SquareConsoleInfo;
            while (true) {
                double x1, y1, x2, y2;
                x1 = double.Parse(Console.ReadLine());
                y1 = double.Parse(Console.ReadLine());
                x2 = double.Parse(Console.ReadLine());
                y2 = double.Parse(Console.ReadLine());
                if (x1 == x2 && y1 == y2 && x1 == 0 && y1 == 0) { return; }
                S.First = new Dot(x1, y1);
                S.Second = new Dot(x2, y2);
            }
            -------------------------------------------*/
            Account acc = new Account(100);
            acc.Put(20);    // добавляем на счет 20
            acc.Take(70);   // пытаемся снять со счета 70
            acc.Take(180);  // пытаемся снять со счета 180
            Console.Read();
        }
    }
}
