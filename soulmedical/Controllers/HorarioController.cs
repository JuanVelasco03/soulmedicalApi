using Microsoft.AspNetCore.Mvc;

using soulmedical.Services;
using soulmedical.Models.bd;

namespace soulmedical.Controllers;

[Route("api/[controller]")]
public class HorarioController: ControllerBase
{
  IHorarioService horarioService;

  public HorarioController (IHorarioService service)
  {
    horarioService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(horarioService.Get());
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
        return Ok(horarioService.GetById(id));
  }

  [HttpPost]
  public IActionResult Post([FromBody] Tblhorario horario)
  {
    horarioService.Save(horario);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put(int id, [FromBody] Tblhorario horario)
  {
    horarioService.Update(id, horario);
    return Ok();
  }

    [HttpDelete("{id}")]
    public IActionResult Delete (int id)
    {
      horarioService.Delete(id);
      return Ok();
    }
}