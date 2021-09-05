using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Data;
using ToDoAPI.Config;

namespace ToDoAPI.AuthService
{
    public class JwtMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public JwtMiddleWare(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
    }
}