using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;

namespace Classwork4 {

    class Program {

        private static async Task<string> GetTextFromAUrlOfAPage(string link) =>
        await ((new HttpClient()).GetAsync(link)).Result.Content.ReadAsStringAsync();

        private static MatchCollection GetImagesUrls(string htmlText) =>
            Regex.Matches(htmlText, "<img.*src=(?<url>\".*..*\").*>");

        static async Task Main(string[] args) {
            string htmlText = await Program.GetTextFromAUrlOfAPage("https://en.wikipedia.org/wiki/Chessboard");
            foreach (Match match in Program.GetImagesUrls(htmlText)) {
                Console.WriteLine(match.Groups["url"].Value);
            }
        }
    }
}
