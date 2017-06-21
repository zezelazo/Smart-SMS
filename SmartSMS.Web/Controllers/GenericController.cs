using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSMS.Web.Data;
using SmartSMS.Web.Entities;

namespace SmartSMS.Web.Controllers
{
  public abstract class GenericController<TEntity> : Controller where TEntity : class, IEntity
  {
    internal readonly GenericRepository<TEntity> _repo;
    internal readonly ILogger<GenericController<TEntity>> _logger;
    public GenericController(GenericRepository<TEntity> repo, ILogger<GenericController<TEntity>> logger)
    {
      _repo = repo;
      _logger = logger;
    }


    [HttpGet()]
    public async Task<IActionResult> Get(int page = 1, int pagesize = -1)
    {
      try
      {
        IEnumerable<TEntity> result;
        if (pagesize > 0)
        {
          _logger.LogInformation($"Trying to get items from the page {page} with the pagesize {pagesize}");
          result = await _repo.All(page, pagesize);
        }
        else
        {
          _logger.LogInformation($"Trying to get items from the page {page}");
          result = await _repo.All(page);
        }
        return Ok(result);
      }
      catch (System.Exception ex)
      {
        _logger.LogError(ex, "Cant get items");
      }
      return BadRequest();
    }

    [HttpGet("{id}", Name = "GetOne")]
    public async Task<IActionResult> GetOne(int id)
    {
      try
      {
        _logger.LogInformation($"Trying to get item with the id {id}");
        var result = await _repo.FindByKey(id);
        if (result == null)
        {
          _logger.LogWarning($"Cant find an item with the id {id}");
          return NotFound($"Item with id {id} was not found");
        }
        return Ok(result);
      }
      catch (System.Exception ex)
      {
        _logger.LogError(ex, $"Cant get item with id {id}");
      }
      return BadRequest();
    }

    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] TEntity item)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _logger.LogInformation($"Trying to create new item");
          var result = await _repo.InsertOrUpdate(item);
          var newUri = Url.Link("GetOne", new { id = result.Id });
          return Created(newUri, result);
        }
        else
        {
          _logger.LogError("Cant deserialize the model");
          return BadRequest();
        }
      }
      catch (System.Exception ex)
      {
        _logger.LogError(ex, "Cant create new item");
      }
      return BadRequest();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TEntity item)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _logger.LogInformation($"Trying to update item {id}");
          var result = await _repo.InsertOrUpdate(item);
          var newUri = Url.Link("GetOne", new { id = result.Id });
          return Accepted(newUri, result);
        }
        else
        {
          _logger.LogError("Cant deserialize the model");
          return BadRequest();
        }
      }
      catch (System.Exception ex)
      {
        _logger.LogError(ex, $"Cant update the item {id}");
      }
      return BadRequest($"Cant update the item {id}");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Del(int id)
    {
      try
      {
        _logger.LogInformation($"Trying to delete item {id}");
        await _repo.Delete(id);      
        return Ok();
      }
      catch (System.Exception ex)
      {
        _logger.LogError(ex, $"Cant delete the item {id}");
      }
      return BadRequest($"Cant delete the item {id}");
    }
    //TODO: Do Patch
  }
}