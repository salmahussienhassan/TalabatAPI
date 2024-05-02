using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.Api.Errors;
using Talabat.Api.Extension;
using Talabat.Api.Helper;
using Talabat.Api.Middlewares;
using Talabat.Core.Repositories;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services -Add services to the container
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddApplicationServices();

            #endregion


            var app = builder.Build();

            #region Update Database

            //TalabatDbContext dbContext =new TalabatDbContext(); //invaild
            //await dbContext.Database.MigrateAsync();

            var Scope = app.Services.CreateScope();
            //Group Of Services Lifetime Scopped

            var Services = Scope.ServiceProvider;
            //Services Itself
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try

            {
                var DbContext = Services.GetRequiredService<StoreDbContext>();
                //Ask CLR creating object from TalabatDbContext
                await DbContext.Database.MigrateAsync();
               await StoreContextSeed.Seed(DbContext);

            }
            catch(Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "Error During Appling Migration");
            }




            #endregion

            #region Configure the HTTP request pipeline.

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                //Handling internal Server error
                app.UseMiddleware<ExceptionMiddleware>();
                app.UseSwaggerMiddleware();
            }

            app.UseStatusCodePagesWithReExecute("errors/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            #endregion

            app.Run();

        }
    }
}
