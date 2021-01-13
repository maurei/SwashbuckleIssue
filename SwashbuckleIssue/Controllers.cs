using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SwashbuckleIssue
{
    public sealed class ArticlesController: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok();
        }

        [HttpGet("{id}/{relationshipName}")]
        public async Task<IActionResult> GetSecondaryAsync(int id, string relationshipName)
        {
            return Ok();
        }

        [HttpGet("{id}/relationships/{relationshipName}")]
        public async Task<IActionResult> GetRelationshipAsync(int id, string relationshipName)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Article resource)
        {
            return Ok();
        }
    }
}