namespace SampleApp.Controllers
{
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;
  using SampleApp.Services;

  [ApiController]
  public class SampleController : ControllerBase
  {
    private readonly IEntityService service;

    public SampleController(IEntityService service)
    {
      this.service = service;
    }

    [HttpGet]
    [Route("groups")]
    public async Task<IActionResult> GroupEntities([FromQuery] bool tags = true)
    {
      var query = this.service.GetEntities(tags)
                      .GroupBy(e => e.Name)
                      .Select(g => new
                      {
                        Name = g.Key,
                        Count = g.Count()
                      });

      var groups = await query.ToListAsync(this.HttpContext.RequestAborted);
      return this.Ok(groups);
    }
  }
}