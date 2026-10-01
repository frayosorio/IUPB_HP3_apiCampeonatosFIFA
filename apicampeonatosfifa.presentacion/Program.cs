using presentacion.InyeccionDependencias;

//crear el CONSTRUCTOR la aplicación web
var builder = WebApplication.CreateBuilder(args);

//establecer objeto de configuracion
var configuracion = builder.Configuration;

//establecer los objetos a inyectar
builder.Services.AgregarDependencias(configuracion);

//instanciar los controladores
builder.Services.AddControllers();

//agregar el servicio de SWAGGER
builder.Services.AddSwaggerGen();

//crear la aplicacción web
var app = builder.Build();

//si es ambiente de desarrollo, permitir SWAGGER (documentación técnica de la API)
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

