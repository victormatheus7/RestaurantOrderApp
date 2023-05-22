using RestaurantOrderApp.Infrastructure;
using RestaurantOrderApp.Application;
using RestaurantOrderApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantOrderApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(p => p.AddPolicy("RestaurantOrderApps", p =>
            {
                p.WithOrigins(builder.Configuration.GetSection("FrontendAddress").Get<string>()).AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Run database migration.
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<RestaurantOrderAppContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("RestaurantOrderApps");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}