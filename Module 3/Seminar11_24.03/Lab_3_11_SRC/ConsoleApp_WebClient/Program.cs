using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace ConsoleApp_WebClient {

    class Program {
        static void Main(string[] numbs) {
            try {
                // HTTP GET
                // Console.WriteLine(GetStringByHttpGet("https://ya.ru").Substring(0,100));
                //Console.WriteLine(GetStringByHttpGet("http://yandex.ru").Substring(0, 100));
                //Console.WriteLine(GetStringByHttpGet("http://yandex.ru/?msg=hello").Substring(0, 100));
                //// Console.WriteLine(GetStringByHttp("http://yandex.ru/msg/hello"));    // 404

                // HTTP GET + DATA
                //Console.WriteLine(GetStringByHttpGet("https://localhost:44386/?urldata=myUrlData").Substring(0, 100));

                // HTTP POST + DATA
                // Console.WriteLine(GetStringByHttpPost("https://localhost:44386/", "formdata=myFormData").Substring(0, 100));

                // HTTP POST + JSON
                // string json = File.ReadAllText(@"..\..\..\person.json");
                // Console.WriteLine(GetStringByHttpPost("https://localhost:44386/Privacy", json, contentType: "application/json"));

                string jsonRequest = BuildJsonForSqEq(numbs);
                Console.WriteLine("Request: " + jsonRequest);
                string jsonResponse = GetStringByHttpPost("https://localhost:44386/SqEq/?handler=bulk", jsonRequest, contentType: "application/json");
                Console.WriteLine("Response: " + jsonResponse);
            }
            catch (Exception ex) {
                Console.WriteLine("...MAIN EXCEPTION HANDLER (Exception): " + ex);
            }
        }



        public static string BuildJsonForSqEq(string[] coefficients) {
            object[] col = new object[coefficients.Length];
            int i = 0;
            Array.ForEach(coefficients, st => {
                var arr = st.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                col[i++] = new { a = double.Parse(arr[0]), b = double.Parse(arr[1]), c = double.Parse(arr[2]) };
            });
            return JsonSerializer.Serialize(col);
        }


        static string GetStringByHttpGet(string url) {
            using (WebClient wc = new WebClient())
                return wc.DownloadString(url);
        }

        static string GetStringByHttpPost(string url, string data, string contentType = "application/x-www-form-urlencoded") {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            return GetStringByHttpPost(url, dataBytes, contentType);
        }

        static string GetStringByHttpPost(string url, byte[] dataBytes, string contentType = "application/x-www-form-urlencoded") {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = "POST";

            using (Stream requestBody = request.GetRequestStream()) {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream)) {
                return reader.ReadToEnd();
            }
        }


    }
}
