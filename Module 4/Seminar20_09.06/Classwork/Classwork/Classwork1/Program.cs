using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;

namespace Classwork1
{
    class Program {

        private static MatchCollection GetLinksFromTheWikiText(string htmlText) => Regex.Matches(htmlText,
                @" href=""\/wiki\/(?<name>[a-zA-Z0-9%_()]+)""");

        private static async Task<string> GetTextFromAUrlOfAPage(string link) => await ((new HttpClient()).GetAsync(link)).Result.Content.ReadAsStringAsync();

        static async Task Main() {

            //using HttpClient client = new HttpClient();

            var wikiLink = "https://en.wikipedia.org/wiki/Main_Page";

            //var response = await client.GetAsync(wikiLink);

            string htmlText = /* Program.GetTextFromAUrlOfAPage(wikiLink); */ await GetTextFromAUrlOfAPage(wikiLink);



            Console.WriteLine($"Скачали ответ: {htmlText.Length} символов");



            // Находим все подстроки, подходящие по шаблону:

            // MatchCollection linksCollection = 
            foreach (Match link in Program.GetLinksFromTheWikiText(htmlText)) {

                Console.WriteLine($" {link.Groups["name"].Value} : {link}");
            }

        }
    }
}
