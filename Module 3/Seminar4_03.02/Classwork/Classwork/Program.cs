using System;
using Classwork1;
using System.Text;
namespace Classwork {
    class Program
    {
        static Random randomGen = new Random();
        static private string GenerateNamePart()
        {
            int length = Program.randomGen.Next(4, 10);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; ++i)
            {
                result.Append((char)Program.randomGen.Next('a', 'z'));
            }
            result[0] = char.ToUpper(result[0]);
            return result.ToString();
        }

        public static void Main() {
            Bandmaster master = new Bandmaster();
            OrchestraPlayer[] orc = new OrchestraPlayer[10];
            for (int i = 0; i < orc.Length; ++i) {
                int player = Program.randomGen.Next(0, 2);
                switch (player) {
                    case 0: orc[i] = new Violinist(Program.GenerateNamePart()); break;
                    case 1: orc[i] = new Hornist(Program.GenerateNamePart()); break;
                }
                master.PlayIsStarted += orc[i].PlayIsStartedEventHandler;
            }
            Console.WriteLine("Please type in your preferred composition number below:");
            int compositionNumber;
            do {

            } while (!int.TryParse(Console.ReadLine(), out compositionNumber));
            Console.WriteLine("Please type in your preferred amount of replays for the band:");
            int replays;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out replays));
            for (int i = 0; i < replays; ++i) {
                master.StartPlay(compositionNumber);
            }
        }
    }
}
