using ecommerce_web_api.Database;
using ecommerce_web_api.Services.Categories;
using ecommerce_web_api.Services.Products;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_web_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // add services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            // database service
            builder.Services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("mydb"));
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // cors policy to avoid cross origin error
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200");
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}