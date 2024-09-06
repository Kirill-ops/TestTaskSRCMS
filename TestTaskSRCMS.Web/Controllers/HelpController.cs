using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Reflection.Metadata.Ecma335;
using TestTaskSRCMS.App.Services;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Web.Controllers;

[Route("help")]
public class HelpController(DoctorService doctorService, SpecializationService specializationService, OfficeService officeService, DistrictService districtService) : Controller
{
    private readonly DoctorService _doctorService = doctorService;
    private readonly SpecializationService _specializationService = specializationService;
    private readonly OfficeService _officeService = officeService;
    private readonly DistrictService _districtService = districtService;

    [HttpGet("offices")]
    public async Task<IReadOnlyList<Office>> GetAllOffices()
    {
        return await _officeService.GetAll();
    }

    [HttpGet("districts")]
    public async Task<IReadOnlyList<District>> GetAllDistricts()
    {
        return await _districtService.GetAll();
    }

    [HttpGet("specializations")]
    public async Task<IReadOnlyList<Specialization>> GetAllSpecializations()
    {
        return await _specializationService.GetAll();
    }

    [HttpPost("")]
    public async Task<string> Help()
    {
        var offices = await _officeService.GetAll();
        var districts = await _districtService.GetAll();
        var specializations = await _specializationService.GetAll();

        var pathDirectory = "Files";

        if (Directory.Exists(pathDirectory))
            Directory.Delete(pathDirectory, true);

        Directory.CreateDirectory(pathDirectory);

        var content = "{\r\n  " +
            "\"surname\": \"Иванов\",\r\n  " +
            "\"name\": \"Иван\",\r\n  " +
            "\"patronymic\": \"Иванович\",\r\n  " +
            $"\"officeId\": \"{offices[0].Id}\",\r\n  " +
            $"\"specializationId\": \"{specializations[0].Id}\",\r\n  " +
            $"\"districtId\": \"{districts[0].Id}\"\r\n" +
        "}";

        using (var writetext = new StreamWriter(pathDirectory + "/postDoctor.json"))
        {
            writetext.WriteLine(content);
        }

        return "Файл postDoctor создан";
    }


    [HttpPost("{id:guid}")]
    public async Task<string> Help(Guid id)
    {
        var doctor = await _doctorService.GetById(id);

        if (doctor is null)
            return "Врача с таким ID нет в БД.";

        var offices = await _officeService.GetAll();
        var districts = await _districtService.GetAll();
        var specializations = await _specializationService.GetAll();

        var pathDirectory = "Files";

        if (!Directory.Exists(pathDirectory))
            Directory.CreateDirectory(pathDirectory);

        var content = "{\r\n  " +
            $"\"id\": \"{doctor.Id}\",\r\n  " +
            "\"surname\": \"Иванов\",\r\n  " +
            "\"name\": \"Андрей\",\r\n  " +
            "\"patronymic\": \"Иванович\",\r\n  " +
            $"\"officeId\": \"{offices[1].Id}\",\r\n  " +
            $"\"specializationId\": \"{specializations[0].Id}\",\r\n  " +
            $"\"districtId\": \"{districts[0].Id}\"\r\n" +
        "}";

        using (var writetext = new StreamWriter(pathDirectory + "/putDoctor.json"))
        {
            writetext.WriteLine(content);
        }

        content = "{\r\n  " +
            $"\"id\": \"{doctor.Id}\"\r\n  " +
        "}";

        using (var writetext = new StreamWriter(pathDirectory + "/deleteDoctor.json"))
        {
            writetext.WriteLine(content);
        }

        return "Файлы putDoctor и deleteDoctor созданы";
    }
}
