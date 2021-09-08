using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using ToDoAPI.Data;

namespace ToDoAPI.AuthService
{
    public class JwtMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public JwtMiddleWare(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }
        public async Task Invoke(HttpContext context, IUserRepo userRepo, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                context.Items["User"] = userRepo.GetById(userId.Value);
            }
            await _next(context);
        }
    }
}