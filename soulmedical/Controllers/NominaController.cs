using Microsoft.AspNetCore.Mvc;

using soulmedical.Services;
using soulmedical.Models.bd;

namespace soulmedical.Controllers;

[Route("api/[controller]")]
public class NominaController: ControllerBase
{
  INominaService nominaService;

  public NominaController (INominaService service)
  {
    nominaService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(nominaService.Get());
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
        return Ok(nominaService.GetById(id));
  }

  [HttpPost]
  public IActionResult Post([FromBody] Tblnomina nomina)
  {
    nominaService.Save(nomina);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put(int id, [FromBody] Tblnomina nomina)
  {
    nominaService.Update(id, nomina);
    return Ok();
  }

    [HttpDelete("{id}")]
    public IActionResult Delete (int id)
    {
      nominaService.Delete(id);
      return Ok();
    }
}