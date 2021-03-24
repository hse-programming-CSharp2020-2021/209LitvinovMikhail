using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Bootstrap_Forms.Pages {
    // https://stackoverflow.com/questions/50442256/how-to-disable-the-antiforgery-token-check-in-asp-net-mvc-core-2
    [IgnoreAntiforgeryToken(Order = 2000)]
    public class SqEqModel : PageModel {
        public double A { get; set; } // => TempData[nameof(A)] != null ? double.Parse(TempData[nameof(A)]?.ToString() ?? "") : 0.0;
        public double B { get; set; } // => TempData[nameof(B)] != null ? double.Parse(TempData[nameof(B)]?.ToString() ?? "") : 0.0;
        public double C { get; set; } // => TempData[nameof(C)] != null ? double.Parse(TempData[nameof(C)]?.ToString() ?? "") : 0.0;
        public string Solution { get; set; }

        public void OnGet() {
            double.TryParse(TempData["a"]?.ToString(), out double val);
            A = val;
            double.TryParse(TempData["b"]?.ToString(), out val);
            B = val;
            double.TryParse(TempData["c"]?.ToString(), out val);
            C = val;
            Solution = TempData["sol"]?.ToString();
        }

        public IActionResult OnPost([FromForm] double a, [FromForm] double b, [FromForm] double c) {
            double d = b * b - 4 * a * c;
            double x1, x2;
            if (d > 0) {
                x1 = -b - Math.Sqrt(d) / 2 / a;
                x2 = -b + Math.Sqrt(d) / 2 / a;
                Solution = $"x<sub>1</sub> = {x1:f2}<br />x<sub>2</sub> = {x2:f2}";
            }
            else if (d == 0) {
                x1 = -b / 2 / a;
                Solution = $"x = {x1:f2}";
            }
            else {
                Solution = "нет корней";
            }
            TempData["a"] = a.ToString();
            TempData["b"] = b.ToString();
            TempData["c"] = c.ToString();
            TempData["sol"] = Solution;
            return RedirectToPage("SqEq");
        }

        /// <summary>
        /// вызвать можно так https://localhost:44386/sqeq/?handler=json&a=1&b=3&c=1
        /// вызвать можно так https://localhost:44386/sqeq/?handler=json&a=1&b=2&c=1
        /// вызвать можно так https://localhost:44386/sqeq/?handler=json&a=1&b=1&c=1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public JsonResult OnGetJson([FromQuery] double a, [FromQuery] double b, [FromQuery] double c) {
            double d = b * b - 4 * a * c;
            double x1, x2;
            if (d > 0) {
                x1 = -b - Math.Sqrt(d) / 2 / a;
                x2 = -b + Math.Sqrt(d) / 2 / a;
                return new JsonResult(new { x1, x2 });
            }
            else if (d == 0) {
                x1 = -b / 2 / a;
                return new JsonResult(new { x = x1});
            }
            return new JsonResult(new { });
        }

        class SqEq {
            public double a { get; set; }
            public double b { get; set; }
            public double c { get; set; }
        }

        public async Task<JsonResult> OnPostBulkAsync() {
            Request.EnableBuffering();
            string jsonInput;
            using (StreamReader sr = new StreamReader(Request.Body)) {
                jsonInput = await sr.ReadToEndAsync();
            }
            dynamic jsonObject = JsonSerializer.Deserialize<List<SqEq>>(jsonInput);
            object[] list = new object[jsonObject.Count];
            int i=0;
            foreach (var item in jsonObject) {
                list[i++] = OnGetJson(item.a, item.b, item.c).Value;
            }
            return new JsonResult(list);
        }


    }
}
