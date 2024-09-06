using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.App.Services;
using TestTaskSRCMS.App.Startup;
using TestTaskSRCMS.Storage;
using TestTaskSRCMS.Storage.Storages;

namespace TestTaskSRCMS.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });

        string connection = "Server=(localdb)\\mssqllocaldb;Database=TestTaskSRCMS;Trusted_Connection=True;";
        builder.Services.AddDbContext<ContextDatabase>(options => options.UseSqlServer(connection));

        // Сервисы взаимодействия с бд
        builder.Services.AddScoped<StorageDoctor>();
        builder.Services.AddScoped<StoragePatient>();
        builder.Services.AddScoped<StorageDistrict>();
        builder.Services.AddScoped<StorageOffice>();
        builder.Services.AddScoped<StorageSpecialization>();

        //
        builder.Services.AddScoped<DoctorService>();
        builder.Services.AddScoped<DistrictService>();
        builder.Services.AddScoped<SpecializationService>();
        builder.Services.AddScoped<OfficeService>();
        builder.Services.AddScoped<DistrictService>();

        // Задачи, которые нужно выполнить при старте программы.
        builder.Services.AddScoped<IStartupTask, TaskStorageInitalization>();

        var app = builder.Build();

        //app.Services.GetServices<IStartupTask>().ToList().ForEach(async x => await x.Execute());
        // Создаем скоуп
        using (var scope = app.Services.CreateScope())
        {
            var startupTasks = scope.ServiceProvider.GetServices<IStartupTask>();
            foreach (var task in startupTasks)
            {
                task.Execute().Wait();
            }
        }

        app.MapControllers();

        app.Run();
    }
}
