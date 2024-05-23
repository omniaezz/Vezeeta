
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vezeeta.Application.Contract.AppointmentContracts;
using Vezeeta.Application.Contract.DoctorContracts;
using Vezeeta.Application.Contract.SubSpecialtyContracts;
using Vezeeta.Application.Contract.WorkingPlaceContracts;
using Vezeeta.Application.Services.DoctorServices;
using Vezeeta.Context;
using Vezeeta.Infrastucture.AppointmentRepositories;
using Vezeeta.Infrastucture.DoctorRepositories;
using Vezeeta.Infrastucture.SubSpecialitiesRepositories;
using Vezeeta.Infrastucture.WorkingPlaceRepositories;
using Vezeeta.Models.UserModels;

namespace Vezeeta.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<VezeetaContext>(options =>
                             options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<VezeetaContext>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentsRepository>();
            builder.Services.AddScoped<IDoctorAppointmentsRepository, DoctorAppointmentsRepository>();
            builder.Services.AddScoped<IDoctorTeleAppointmentsRepository, DoctorTeleAppointmentsRepository>();
            builder.Services.AddScoped<IWorkingPlaceRepository, WorkingPlaceRepository>();
            builder.Services.AddScoped<ISubSpecialitiesRepository, SubSpecialtiesRepository>();
            builder.Services.AddScoped<IDoctorWorkingPlaceRepository, DoctorWorkingPlaceRepository>();
            builder.Services.AddScoped<IDoctorSubSpecialitiesRepository, DoctorSubSpecialitiesRepository>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
