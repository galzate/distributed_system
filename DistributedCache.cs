using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]")]
public class CacheController : ControllerBase
{
    private readonly IDistributedCache _cache;


    public CacheController(IDistributedCache cache)
    {
        _cache = cache;
    }


    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        var value = await _cache.GetStringAsync(key);
        if (value == null)
        {
            return NotFound();
        }
        return Ok(value);
    }


    [HttpPost("{key}")]
    public async Task<IActionResult> Set(string key, [FromBody] string value)
    {
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            .SetAbsoluteExpiration(TimeSpan.FromHours(1));


        await _cache.SetStringAsync(key, value, options);
        return Ok();
    }


    [HttpDelete("{key}")]
    public async Task<IActionResult> Remove(string key)
    {
        await _cache.RemoveAsync(key);
        return NoContent();
    }
}
