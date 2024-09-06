using Microsoft.AspNetCore.Mvc;
using TestTaskSRCMS.App.Services;
using TestTaskSRCMS.Core.Models;
using TestTaskSRCMS.Web.Models;
using TestTaskSRCMS.Web.Models.Requests;

namespace TestTaskSRCMS.Web.Controllers;

[Route("doctors")]
public class DoctorController(DoctorService doctorService, SpecializationService specializationService, OfficeService officeService, DistrictService districtService) : Controller
{
    private readonly DoctorService _doctorService = doctorService;
    private readonly SpecializationService _specializationService = specializationService;
    private readonly OfficeService _officeService = officeService;
    private readonly DistrictService _districtService = districtService;

    [HttpPost("")]
    public async Task<IReadOnlyList<Doctor>> Create([FromBody] DoctorPost request)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Surname);

        var office = await _officeService.GetById(request.OfficeId) ?? throw new Exception("Not found office");
        var district = await _districtService.GetById(request.DistrictId) ?? throw new Exception("Not found district"); ;
        var specialization = await _specializationService.GetById(request.SpecializationId) ?? throw new Exception("Not found specialization"); ;

        await _doctorService.Create(
            request.Surname.Trim(),
            request.Name.Trim(),
            office,
            specialization,
            district,
            request.Patronymic?.Trim());

        return await _doctorService.GetAll();
    }

    [HttpPut("")]
    public async Task<IReadOnlyList<Doctor>> Update([FromBody] DoctorPut request)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Surname);

        var doctor = await _doctorService.GetById(request.Id) ?? throw new Exception("Not found doctor");
        var office = await _officeService.GetById(request.OfficeId) ?? throw new Exception("Not found office");
        var district = await _districtService.GetById(request.DistrictId) ?? throw new Exception("Not found district"); ;
        var specialization = await _specializationService.GetById(request.SpecializationId) ?? throw new Exception("Not found specialization"); ;

        await _doctorService.Update(
            doctor, 
            request.Surname.Trim(), 
            request.Name.Trim(),
            office,
            specialization,
            district,
            request.Patronymic?.Trim());

        return await _doctorService.GetAll();
    }

    [HttpDelete("")]
    public async Task<IReadOnlyList<Doctor>> Delete([FromBody] DoctorDelete request)
    {
        var doctor = await _doctorService.GetById(request.Id) ?? throw new Exception("Not found");

        await _doctorService.Delete(doctor);

        return await _doctorService.GetAll();
    }


    [HttpGet("{id:guid}")]
    public async Task<ResponseDoctorBrief> Get(Guid id)
    {
        var doctor = await _doctorService.GetById(id) ?? throw new Exception("Not found");
        var response = new ResponseDoctorBrief(doctor);
        return response;
    }

    [HttpGet("")]
    public async Task<IReadOnlyList<ResponseDoctorFull>> GetAll()
    {
        var response = new List<ResponseDoctorFull>();

        var doctors = await _doctorService.GetAll();

        foreach (var doctor in doctors)
        {
            var office = await _officeService.GetById(doctor.OfficeId) ?? throw new Exception("Not found office");
            var district = await _districtService.GetById(doctor.DistrictId) ?? throw new Exception("Not found district"); ;
            var specialization = await _specializationService.GetById(doctor.SpecializationId) ?? throw new Exception("Not found specialization"); ;

            response.Add(new(doctor, office, specialization, district));
        }

        return response;
    }

}
