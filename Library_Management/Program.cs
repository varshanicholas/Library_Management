using LibraryManagement.Repositories;
using Library_Management.Model;
using Library_Management.Repository;
using Microsoft.EntityFrameworkCore;

namespace Library_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
          //  builder.Services.AddEndpointsApiExplorer();
           


            builder.Services.AddControllersWithViews()
             .AddJsonOptions(
             options =>
             {
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 options.JsonSerializerOptions.ReferenceHandler = 
                 System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                 options.JsonSerializerOptions.DefaultIgnoreCondition =
                 System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                 options.JsonSerializerOptions.WriteIndented = true;
             });



            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            builder.Services.AddDbContext<LibraryManagementContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("PropelAug24Connection")));

            builder.Services.AddScoped<IBookRepository , BookRepository >();



            // Connection string as Middleware
            builder.Services.AddDbContext<LibraryManagementContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("PropelAug24Connection")));


            // Register repository and service layer
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();

            // Register the IReportRepository and its implementation
            builder.Services.AddScoped<IReportRepository, ReportRepository>();

            var app = builder.Build();


           

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
