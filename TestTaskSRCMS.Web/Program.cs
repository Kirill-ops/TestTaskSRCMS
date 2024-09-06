using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.App.Services;
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

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
