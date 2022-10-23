namespace soulmedical.Services;

using Microsoft.AspNetCore.Mvc;
using soulmedical.Models.bd;


public class TrabajadorService : ITrabajadorService
{
  SoulMedicalContext context;

  public TrabajadorService(SoulMedicalContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<Tbltrabajadore> Get()
  {
    return context.Tbltrabajadores;
  }

    public Task<Tbltrabajadore>GetById(int id)
    {
        Tbltrabajadore worker = context.Tbltrabajadores.Find(id);

        return Task.FromResult(worker);
    }

    public async Task Save(Tbltrabajadore trabajador)
  {
    context.Add(trabajador);
    await context.SaveChangesAsync();
  }

  public async Task Update(int id, Tbltrabajadore trabajador)
  {
    var trabajadorActual = context.Tbltrabajadores.Find(id);

    if(trabajadorActual != null)
    {
      trabajadorActual.TraNombre = trabajador.TraNombre;
      trabajadorActual.TraApellido = trabajador.TraApellido;
      trabajadorActual.TraDireccion = trabajador.TraDireccion;
      trabajadorActual.TraCelular = trabajador.TraCelular;
      trabajadorActual.TraEmail = trabajador.TraEmail;
      trabajadorActual.TraFechaNacimiento = trabajador.TraFechaNacimiento;
      trabajadorActual.TraCodigocuenta = trabajador.TraCodigocuenta;
      trabajadorActual.TraEdad = trabajador.TraEdad;

      await context.SaveChangesAsync();
    }
}

    public async Task Delete(int id)
  {

    var trabajadorActual = context.Tbltrabajadores.Find(id);

    if(trabajadorActual != null)
    {
      context.Remove(trabajadorActual);
      await context.SaveChangesAsync();
    }
  }
}

public interface ITrabajadorService
{
 IEnumerable<Tbltrabajadore> Get();

    Task<Tbltrabajadore> GetById(int id);


 Task Save(Tbltrabajadore trabajador);

 Task Update(int id, Tbltrabajadore trabajador);

 Task Delete(int id);
}