namespace soulmedical.Services;

using soulmedical.Models.bd;


public class UsuarioService : IUsuarioService
{
  SoulMedicalContext context;

  public UsuarioService(SoulMedicalContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<Tblusuario> Get()
  {
    return context.Tblusuarios;
  }

  public async Task Save(Tblusuario usuario)
  {
    context.Add(usuario);
    await context.SaveChangesAsync();
  }

  public async Task Update(int id, Tblusuario usuario)
  {

    var usuarioActual = context.Tblusuarios.Find(id);

    if(usuarioActual != null)
    {
      usuarioActual.Usernombre = usuario.Usernombre;
      usuarioActual.Userapellido = usuario.Userapellido;
      usuarioActual.Useremail = usuario.Useremail;
      usuarioActual.Userclave = usuario.Userclave;
      usuarioActual.Idrol = usuario.Idrol;

      await context.SaveChangesAsync();
    }
}

    public async Task Delete(int id)
  {
    var usuarioActual = context.Tblusuarios.Find(id);

    if(usuarioActual != null)
    {
      context.Remove(usuarioActual);
      await context.SaveChangesAsync();
    }
} 
}

public interface IUsuarioService
{
 IEnumerable<Tblusuario> Get();

 Task Save(Tblusuario usuario);

 Task Update(int id, Tblusuario usuario);

 Task Delete(int id);
}