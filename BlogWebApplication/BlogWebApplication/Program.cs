
using BusinessLayer.Interface;
using BusinessLayer.Services;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;

namespace BlogWebApplication
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

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("BlogAppConnectionString"));
            });

            builder.Services.AddTransient<ICategoryBL,CategoryBL>();
            builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(option =>
            {
                option.AllowAnyHeader();
                option.AllowAnyOrigin();
                option.AllowAnyMethod();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
