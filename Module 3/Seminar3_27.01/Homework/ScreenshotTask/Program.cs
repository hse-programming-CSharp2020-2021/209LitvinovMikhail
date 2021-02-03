using System;
using System.Text;
namespace ScreenshotTask
{
    class Program {

        static Random randomGen = new Random();

        static private string GenerateNamePart() {
            int length = Program.randomGen.Next(4, 10);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; ++i) {
                result.Append((char)Program.randomGen.Next('a', 'z'));
            }
            result[0] = char.ToUpper(result[0]);
            return result.ToString();
        }

        static void Main() {
            VetoComission comission = new VetoComission();
            for (int i = 0; i < 5; ++i) {
                VetoVoter voter = new VetoVoter(GenerateNamePart() + " " + GenerateNamePart());
                comission.OnVote += voter.VoteHandler;
            }
            Console.WriteLine("Type in your proposal:");
            VetoEventArgs result = comission.Vote(Console.ReadLine());
            Console.WriteLine((result.VetoBy == null) ? $"The proposal \"{result.Proposal}\" wasn't rejected" :
                $"The proposal \"{result.Proposal}\" was rejected by spokesman {result.VetoBy.Name})");
        }
    }
}
