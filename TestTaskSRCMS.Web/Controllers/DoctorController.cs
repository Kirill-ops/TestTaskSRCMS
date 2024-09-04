using Microsoft.AspNetCore.Mvc;
using TestTaskSRCMS.Storage;

namespace TestTaskSRCMS.Web.Controllers;

[Route("doctors")]
public class DoctorController(ContextDatabase contextDatebase) : Controller
{
    private ContextDatabase _contextDatebase = contextDatebase;

    [HttpPost("")]
    public async Task<string> Create()
    {

        return "OK";
    }

}
