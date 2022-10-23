using Microsoft.AspNetCore.Mvc;

using soulmedical.Services;
using soulmedical.Models.bd;

namespace soulmedical.Controllers;

[Route("api/[controller]")]
public class VacacionController: ControllerBase
{
  IVacacionService vacacionService;

  public VacacionController (IVacacionService service)
  {
    vacacionService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(vacacionService.Get());
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
        return Ok(vacacionService.GetById(id));
  }

  [HttpPost]
  public IActionResult Post([FromBody] Tblvacacione vacacion)
  {
    vacacionService.Save(vacacion);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put(int id, [FromBody] Tblvacacione vacacion)
  {
    vacacionService.Update(id, vacacion);
    return Ok();
  }

    [HttpDelete("{id}")]
    public IActionResult Delete (int id)
    {
      vacacionService.Delete(id);
      return Ok();
    }
}