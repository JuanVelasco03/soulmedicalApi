namespace soulmedical.Services;

using Microsoft.AspNetCore.Mvc;
using soulmedical.Models.bd;

public class VacacionService : IVacacionService
{
  SoulMedicalContext context;

  public VacacionService(SoulMedicalContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<Tblvacacione> Get()
  {
    return context.Tblvacaciones;
  }

    public Task<Tblvacacione>GetById(int id)
    {
        Tblvacacione vacacion = context.Tblvacaciones.Find(id);

        return Task.FromResult(vacacion);
    }

    public async Task Save(Tblvacacione vacacion)
  {
    context.Add(vacacion);
    await context.SaveChangesAsync();
  }

  public async Task Update(int id, Tblvacacione vacacion)
  {
    var vacacionActual = context.Tblvacaciones.Find(id);

    if(vacacionActual != null)
    {
      vacacionActual.VacNombre = vacacion.VacNombre;
      vacacionActual.VacApellido = vacacion.VacApellido;
      vacacionActual.VacDiasnormales = vacacion.VacDiasnormales;
      vacacionActual.VacDiasadicionales = vacacion.VacDiasadicionales;
      vacacionActual.VacDiastotales = vacacion.VacDiastotales;
      vacacionActual.VacInicio = vacacion.VacInicio;
      vacacionActual.VacFin = vacacion.VacFin;

      await context.SaveChangesAsync();
    }
}

    public async Task Delete(int id)
  {

    var vacacionActual = context.Tblvacaciones.Find(id);

    if(vacacionActual != null)
    {
      context.Remove(vacacionActual);
      await context.SaveChangesAsync();
    }
  }
}

public interface IVacacionService
{
 IEnumerable<Tblvacacione> Get();

 Task<Tblvacacione>GetById(int id);

 Task Save(Tblvacacione vacacion);

 Task Update(int id, Tblvacacione vacacion);

 Task Delete(int id);
}