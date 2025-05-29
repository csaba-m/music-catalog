using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Domain.Persistance;

namespace MusicCatalog;

[ApiController]
[Route("songs")]
public class SongsController : ControllerBase
{
    [HttpGet("{id:int}")]
    [ProducesResponseType<SongResponse>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [ProducesResponseType<SongResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<SongResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody]SongRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpPut]
    [ProducesResponseType<SongResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<SongResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody]SongRequest request)
    {
        throw new NotImplementedException();
    }
}