using Learn.Models;
using Learn.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers;

[ApiController]
[Route("[controller]")]
public class TestStreamController : Controller
{
    public ITestStreamService TestStreamService { get; set; }
    
    public TestStreamController(ITestStreamService testStreamService)
    {
        TestStreamService = testStreamService;
    }
    
    [HttpGet("GetTestStream")]
    public void GetTestStream(string fileName, string fileSavePath)
    {
        TestStreamService.GetTestStream(fileName, fileSavePath);
    }
    
    [HttpPut("AddTestStream")]
    public void AddTestStream(string testStreamName)
    {
        TestStreamService.AddTestStreamAsync(testStreamName);
    }
}