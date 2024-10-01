
using Lab1_PRN231.Repository.ProductDbContext;
using Lab1_PRN231.Repository;
using Microsoft.EntityFrameworkCore;
using Lab1_PRN231.Service.Service;

namespace Lab1_PRN231.API
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


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ProductContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<CategoryService>();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
