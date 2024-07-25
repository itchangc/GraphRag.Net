using GraphRag.Net.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GraphRag.Net.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GraphDemoController(IGraphService _graphService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllGraph()
        {
            var graphModel = _graphService.GetAllGraph();
            return Ok(graphModel);
        }

        [HttpPost]
        public async Task<IActionResult> InsertGraph(InputModel model)
        {
            await _graphService.InsertGraph(model.Input);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Search(InputModel model)
        {
            var result = await _graphService.SearchGraph(model.Input);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> ImportTxt(IFormFile file)
        {
            var forms = await Request.ReadFormAsync();
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                var txt = await stream.ReadToEndAsync();
                await _graphService.TextChunkInsertGraph(txt);
                return Ok();
            }
        }
    }

    public class InputModel
    {
        public string Input { get; set; }
    }
}
