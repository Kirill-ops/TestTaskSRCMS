using Microsoft.AspNetCore.Mvc;
using TestTaskSRCMS.App.Services;
using TestTaskSRCMS.Core.Models;
using TestTaskSRCMS.Storage;
using TestTaskSRCMS.Storage.Storages;
using TestTaskSRCMS.Web.Models.Requests;

namespace TestTaskSRCMS.Web.Controllers;

[Route("doctors")]
public class DoctorController(DoctorService service) : Controller
{
    private readonly DoctorService _service = service;

    [HttpPost("")]
    public async Task<IReadOnlyList<Doctor>> Create([FromBody] DoctorPost request)
    {
        await _service.Create(request.Surname, request.Name, new Office(1), new Specialization("Терапевт"), new District(1), request.Patronymic);
        return await _service.GetAll();
    }

    [HttpPut("")]
    public async Task<IReadOnlyList<Doctor>> Update([FromBody] DoctorPut request)
    {
        var doctor = await _service.GetById(request.Id) ?? throw new Exception("Not found");
        await _service.Update(doctor, request.Surname, request.Name, new Office(1), new Specialization("Терапевт"), new District(1), request.Patronymic);
        return await _service.GetAll();

    }

    [HttpDelete("")]
    public async Task<string> Delete([FromBody] DoctorDelete request)
    {
        return "OK";
    }


    [HttpGet("{id:guid}")]
    public async Task<string> Get(Guid id)
    {
        return "OK";
    }

    [HttpGet("")]
    public async Task<IReadOnlyList<string>> GetAll()
    {
        return new List<string>();
    }

}
