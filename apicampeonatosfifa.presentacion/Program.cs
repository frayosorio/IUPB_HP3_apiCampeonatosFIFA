//crear la aplicación web
using presentacion.InyeccionDependencias;

var builder = WebApplication.CreateBuilder(args);

//establecer objeto de configuracion
var configuracion = builder.Configuration;

//establecer los objetos a inyectar
builder.Services.AgregarDependencias(configuracion);
builder.Services.AddControllers();


var app = builder.Build();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();

