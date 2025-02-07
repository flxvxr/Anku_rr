using Learn.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController
{
    [HttpPost("Square")]
    public double Square([FromBody]double square)
    {  
        return Math.Pow(square, 2);
    }

    [HttpPost("Sum")]
    public double Sum([FromBody]SumRequest sumRequest)
    {
        return sumRequest.NumberX + sumRequest.NumberY;
    }
    
    [HttpGet ("Test")]
    public string Test()
    {
        return "OnePiece";
    }
}