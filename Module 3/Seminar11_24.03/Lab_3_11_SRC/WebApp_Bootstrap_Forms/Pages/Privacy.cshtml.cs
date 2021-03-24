using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp_Bootstrap_Forms.Pages {
    // https://stackoverflow.com/questions/50442256/how-to-disable-the-antiforgery-token-check-in-asp-net-mvc-core-2
    [IgnoreAntiforgeryToken(Order = 2000)]
    public class PrivacyModel : PageModel {
        public string RequestBody { get; set; }

        public void OnGet() {
        }


        /*
         // НЕ РАБОТАЕТ - ПОЧЕМУ???
        public void OnPost() {
            Request.EnableBuffering();
            using (StreamReader sr = new StreamReader(Request.Body)) {
                RequestBody = sr.ReadToEndAsync();
            }
        }
        */

        public async void OnPostAsync() {
            Request.EnableBuffering();
            using (StreamReader sr = new StreamReader(Request.Body)) {
                RequestBody = await sr.ReadToEndAsync();
            }
        }


    }
}
