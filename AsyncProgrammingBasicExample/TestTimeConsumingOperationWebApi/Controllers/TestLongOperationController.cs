using Microsoft.AspNetCore.Mvc;

namespace TestTimeConsumingOperationWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestLongOperationController : Controller
{
    [HttpGet]
     public async Task<IActionResult> Get()
     {
         // Fake the long operation using task delay
         await Task.Delay(5000);
         return Content("Web API long operation completed");
     }
}