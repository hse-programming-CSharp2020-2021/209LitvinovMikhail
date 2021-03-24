using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;



namespace Classwork1
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;



        public TokenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }



        public async Task InvokeAsync(HttpContext context)
        {
            //if (context.Request.Path != "/home/calc") { await _next.Invoke(context); return; }
            int result = int.Parse(context.Request.Query["num"]);
            await context.Response.WriteAsync((result * result).ToString());
        }
    }
}