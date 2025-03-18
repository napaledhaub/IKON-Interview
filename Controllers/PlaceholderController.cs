using interview.Models;
using interview.Services;
using Microsoft.AspNetCore.Mvc;

namespace interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceholderController : ControllerBase
    {
        private readonly IPlaceholderService _placeholderService;
        public PlaceholderController(IPlaceholderService placeholderService)
        { 
            _placeholderService = placeholderService;
        }

        [HttpGet("GetTitle")]
        public async Task<IActionResult> GetTitle(int pageNumber = 1, int pageSize = 10)
        {
            var response = await _placeholderService.FetchTitle(pageNumber, pageSize);
            return Ok(response);
        }

        [HttpGet("GetExample")]
        public async Task<IActionResult> GetExample()
        {
            var response = await _placeholderService.GetExample();
            return Ok(response);
        }

        [HttpPost("SaveExample")]
        public async Task<IActionResult> SaveExample(string name)
        {
            Example param = new Example();
            param.name = name;
            await _placeholderService.AddExample(param);
            return Ok();
        }

        [HttpPut("UpdateExample")]
        public async Task<IActionResult> UpdateExample(int id, string name)
        {
            Example param = new Example();
            param.id = id;
            param.name = name;
            await _placeholderService.UpdateExample(param);
            return Ok();
        }

        [HttpDelete("DeleteExample")]
        public async Task<IActionResult> DeleteExample(long id)
        {
            await _placeholderService.DeleteExample(id);
            return Ok();
        }
    }
}
