using Microsoft.EntityFrameworkCore;
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

        builder.Services.AddScoped<StorageDoctor>();
        builder.Services.AddScoped<StoragePatient>();

        var app = builder.Build();

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
