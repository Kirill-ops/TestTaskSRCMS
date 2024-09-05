using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TestTaskSRCMS.App.Services;
using TestTaskSRCMS.Core.Models;
using TestTaskSRCMS.Storage;
using TestTaskSRCMS.Storage.Storages;
using TestTaskSRCMS.Web.Models;
using TestTaskSRCMS.Web.Models.Requests;

namespace TestTaskSRCMS.Web.Controllers;

[Route("doctors")]
public class DoctorController(DoctorService service) : Controller
{
    private readonly DoctorService _service = service;

    [HttpPost("")]
    public async Task<IReadOnlyList<Doctor>> Create([FromBody] DoctorPost request)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Surname);

        await _service.Create(
            request.Surname.Trim(),
            request.Name.Trim(),
            new Office(1),
            new Specialization("Терапевт"),
            new District(1),
            request.Patronymic?.Trim());

        return await _service.GetAll();
    }

    [HttpPut("")]
    public async Task<IReadOnlyList<Doctor>> Update([FromBody] DoctorPut request)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Surname);

        var doctor = await _service.GetById(request.Id) ?? throw new Exception("Not found");

        await _service.Update(
            doctor, 
            request.Surname.Trim(), 
            request.Name.Trim(), 
            new Office(1), 
            new Specialization("Терапевт"), 
            new District(1), 
            request.Patronymic?.Trim());

        return await _service.GetAll();
    }

    [HttpDelete("")]
    public async Task<IReadOnlyList<Doctor>> Delete([FromBody] DoctorDelete request)
    {
        var doctor = await _service.GetById(request.Id) ?? throw new Exception("Not found");

        await _service.Delete(doctor);

        return await _service.GetAll();
    }


    [HttpGet("{id:guid}")]
    public async Task<ResponseDoctorBrief> Get(Guid id)
    {
        var doctor = await _service.GetById(id) ?? throw new Exception("Not found");
        var response = new ResponseDoctorBrief(doctor);
        return response;
    }

    [HttpGet("")]
    public async Task<IReadOnlyList<Doctor>> GetAll()
    {
        return await _service.GetAll();
    }

}
