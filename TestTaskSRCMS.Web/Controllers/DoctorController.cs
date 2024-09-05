using Microsoft.AspNetCore.Mvc;
using TestTaskSRCMS.Storage;
using TestTaskSRCMS.Storage.Storages;
using TestTaskSRCMS.Web.Models.Requests;

namespace TestTaskSRCMS.Web.Controllers;

[Route("doctors")]
public class DoctorController(StorageDoctor storage) : Controller
{
    private readonly StorageDoctor _storage = storage;

    [HttpPost("")]
    public async Task<string> Create([FromForm] DoctorPost request)
    {
        var a = await _storage.Get();

        return "OK " + a.Id.ToString();
    }

    [HttpPut("")]
    public async Task<string> Update([FromForm] DoctorPut request)
    {
        return "OK";
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
