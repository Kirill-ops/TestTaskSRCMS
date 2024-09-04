using Microsoft.AspNetCore.Mvc;
using TestTaskSRCMS.Storage;
using TestTaskSRCMS.Web.Models.Requests;

namespace TestTaskSRCMS.Web.Controllers;

[Route("doctors")]
public class DoctorController(ContextDatabase contextDatebase) : Controller
{
    private ContextDatabase _contextDatebase = contextDatebase;

    [HttpPost("")]
    public async Task<string> Create([FromForm] DoctorPost request)
    {
        return "OK";
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
