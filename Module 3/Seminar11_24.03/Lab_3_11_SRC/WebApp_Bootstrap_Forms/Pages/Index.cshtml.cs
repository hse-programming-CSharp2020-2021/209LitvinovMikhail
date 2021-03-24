using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp_Bootstrap_Forms.Pages {
    // https://stackoverflow.com/questions/50442256/how-to-disable-the-antiforgery-token-check-in-asp-net-mvc-core-2
    [IgnoreAntiforgeryToken(Order = 2000)]
    public class IndexModel : PageModel {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger) {
        //    _logger = logger;
        //}


        public string Name => (string)TempData[nameof(Name)];
        public bool Check => TempData[nameof(Check)] != null ? (bool)TempData[nameof(Check)] : false;
        //public bool Check => string.CompareOrdinal((string)TempData[nameof(Check)], "true") == 0;
        public string FormData => (string)TempData[nameof(FormData)];


        public string RequestHeaders { get; set; }
        public string Cookies { get; set; }
        public string Query { get; set; }
        public string Form { get; set; }

        /// <summary>
        /// Это метод обработки GET-запроса
        /// </summary>
        public void OnGet() {
            if (TempData[nameof(RequestHeaders)] != null) {
                RequestHeaders = TempData[nameof(RequestHeaders)] as string;
                Cookies = TempData[nameof(Cookies)] as string;
                Query = TempData[nameof(Query)] as string;
                Form = TempData[nameof(Form)] as string;
                return;
            }
            GetRequestHeaders();
            GetRequestCookies();
            GetRequestQuery();
            GetRequestForm();
        }

        /// <summary>
        /// Это метод обработки POST-запроса
        /// Обратите внимание! Внизу RedirectToPage - перенаправление на страницу (GET)
        /// Далее все паарметры - Dependency Injection
        /// </summary>
        /// <param name="name">сюда автоматически подставляется параметр name из формы</param>
        /// <param name="check">сюда автоматически подставляется параметр check из формы</param>
        /// <param name="formdata">сюда автоматически подставляется параметр formdata из формы</param>
        /// <returns></returns>
        public IActionResult OnPost([FromForm] string name, [FromForm] bool check, [FromForm] string formdata) {
            TempData["Name"] = name;
            TempData["Check"] = check;
            TempData[nameof(RequestHeaders)]= GetRequestHeaders();
            TempData[nameof(Cookies)]= GetRequestCookies();
            TempData[nameof(Query)] = GetRequestQuery();
            TempData[nameof(Form)] = GetRequestForm();
            TempData[nameof(FormData)] = formdata;
            return RedirectToPage("Index");
        }


        private string GetRequestHeaders() {
            StringBuilder sb = new StringBuilder();
            foreach (var item in HttpContext.Request.Headers) {
                sb.AppendLine($"{item.Key}: {string.Join(", ", item.Value)}");
            }
            return RequestHeaders = sb.ToString();
        }

        private string GetRequestCookies() {
            StringBuilder sb = new StringBuilder();
            foreach (var item in HttpContext.Request.Cookies) {
                sb.AppendLine($"{item.Key}: {item.Value}");
            }
            return Cookies = sb.ToString();
        }

        private string GetRequestQuery() {
            StringBuilder sb = new StringBuilder();
            foreach (var item in HttpContext.Request.Query) {
                sb.AppendLine($"{item.Key}: {string.Join(", ", item.Value)}");
            }
            return Query = sb.ToString();
        }

        private string GetRequestForm() {
            if (HttpContext.Request.Method != "POST")
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            //try {
                foreach (var item in HttpContext.Request.Form) {
                    sb.AppendLine($"{item.Key}: {string.Join(", ", item.Value)}");
                }
            //} catch (Exception e) { }
            return Form = sb.ToString();
        }

    }
}
