using Microsoft.AspNetCore.Mvc;

namespace NotNullApi.Controllers;

[ApiController]
[Route("echo")]
public class EchoController : ControllerBase
{
    [HttpPost]
    public IActionResult EchoResponse([FromBody] RequestDtoObject requestDto)
    {
        return Ok(requestDto);
    }
}

public class RequestDtoObject
{
    public List<string> Names { get; set; }
    public string Name { get; set; }
}
