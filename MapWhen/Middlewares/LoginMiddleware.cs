namespace MapWhen.Middlewares
{
    public class LoginMiddleware
    {
        RequestDelegate _next;
        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Login Started");
            await _next.Invoke(context);
            Console.WriteLine("Login Ended");
        }
    }
}
