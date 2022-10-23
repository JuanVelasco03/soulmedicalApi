namespace soulmedical.Services;

using Microsoft.AspNetCore.Mvc;
using soulmedical.Models.bd;

public class HorarioService : IHorarioService
{
  SoulMedicalContext context;

  public HorarioService(SoulMedicalContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<Tblhorario> Get()
  {
    return context.Tblhorarios;
  }

    public Task<Tblhorario>GetById(int id)
    {
        Tblhorario horario = context.Tblhorarios.Find(id);

        return Task.FromResult(horario);
    }

    public async Task Save(Tblhorario horario)
  {
    context.Add(horario);
    await context.SaveChangesAsync();
  }

  public async Task Update(int id, Tblhorario horario)
  {
    var horarioActual = context.Tblhorarios.Find(id);

    if(horarioActual != null)
    {
      horarioActual.HorNombre = horario.HorNombre;
      horarioActual.HorApellido = horario.HorApellido;
      horarioActual.HorLlegada = horario.HorLlegada;
      horarioActual.HorSalida = horario.HorSalida;

      await context.SaveChangesAsync();
    }
}

    public async Task Delete(int id)
  {

    var horarioActual = context.Tblhorarios.Find(id);

    if(horarioActual != null)
    {
      context.Remove(horarioActual);
      await context.SaveChangesAsync();
    }
  }
}

public interface IHorarioService
{
 IEnumerable<Tblhorario> Get();

 Task<Tblhorario>GetById(int id);

 Task Save(Tblhorario horario);

 Task Update(int id, Tblhorario horario);

 Task Delete(int id);
}