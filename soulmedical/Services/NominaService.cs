namespace soulmedical.Services;

using Microsoft.AspNetCore.Mvc;
using soulmedical.Models.bd;

public class NominaService : INominaService
{
  SoulMedicalContext context;

  public NominaService(SoulMedicalContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<Tblnomina> Get()
  {
    return context.Tblnominas;
  }

    public Task<Tblnomina>GetById(int id)
    {
        Tblnomina nomina = context.Tblnominas.Find(id);

        return Task.FromResult(nomina);
    }

    public async Task Save(Tblnomina nomina)
  {
    context.Add(nomina);
    await context.SaveChangesAsync();
  }

  public async Task Update(int id, Tblnomina nomina)
  {
    var nominaActual = context.Tblnominas.Find(id);

    if(nominaActual != null)
    {
      nominaActual.NomNombre = nomina.NomNombre;
      nominaActual.NomApellido = nomina.NomApellido;
      nominaActual.NomSalarioestipulado = nomina.NomSalarioestipulado;
      nominaActual.NomDeduccionsalario = nomina.NomDeduccionsalario;
      nominaActual.NomSaludpension = nomina.NomSaludpension;
      nominaActual.NomCesantias = nomina.NomCesantias;
      nominaActual.NomParafiscales = nomina.NomParafiscales;
      nominaActual.NomInicio = nomina.NomInicio;
      nominaActual.NomFin = nomina.NomFin;

      await context.SaveChangesAsync();
    }
}

    public async Task Delete(int id)
  {

    var nominaActual = context.Tblnominas.Find(id);

    if(nominaActual != null)
    {
      context.Remove(nominaActual);
      await context.SaveChangesAsync();
    }
  }
}

public interface INominaService
{
 IEnumerable<Tblnomina> Get();

 Task<Tblnomina>GetById(int id);

 Task Save(Tblnomina nomina);

 Task Update(int id, Tblnomina nomina);

 Task Delete(int id);
}