using MapWhen.Extensions;

namespace MapWhen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseLogin();
            //Map() metodu ilə oxşar işləyir, lakin URL, sorğu başlıqları,
            //sorğu sətirləri və s. üzərində daha çox nəzarət edir. MapWhen()
            //metodu parametr kimi HttpContext-dən istənilən şərti yoxladıqdan
            //sonra Boolean qaytarır.

            app.MapWhen(context => context.Request.Query.ContainsKey("branch"), builder =>
            {
                builder.Use(async (context,next) =>
                {
                    Console.WriteLine("Map When Started");
                    await context.Response.WriteAsync("Map When Middleware is called");
                    await next.Invoke(context);
                    Console.WriteLine("Map When Ended");
                });
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}