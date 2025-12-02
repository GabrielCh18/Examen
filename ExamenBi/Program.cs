using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ExamenBi.Data;

namespace ExamenBi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var miConexion = new ConexionDB();
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LigaApiContext>(options =>
                options.UseMySql(
                builder.Configuration.GetConnectionString("LigaApiContext"),
                new MySqlServerVersion(new Version(10, 4, 17))
                ));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
