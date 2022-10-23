using Microsoft.AspNetCore.Mvc;

using soulmedical.Services;
using soulmedical.Models.bd;

namespace soulmedical.Controllers;

[Route("api/[controller]")]
public class UsuarioController: ControllerBase
{
  IUsuarioService usuarioService;

  public UsuarioController (IUsuarioService service)
  {
    usuarioService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(usuarioService.Get());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Tblusuario usuario)
  {
    usuarioService.Save(usuario);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put(int id, [FromBody] Tblusuario usuario)
  {
    usuarioService.Update(id, usuario);
    return Ok();
  }

    [HttpDelete("{id}")]
    public IActionResult Delete (int id)
    {
      usuarioService.Delete(id);
      return Ok();
    }
}