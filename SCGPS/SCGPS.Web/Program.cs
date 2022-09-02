using SCGPS.Data;
using SCGPS.Logic;
using SCGPS.Web.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o =>
{
	o.AddPolicy(name: "scgpsCors", b =>
	{
		b.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});
builder.Services.AddDataLayer(builder.Configuration);
builder.Services.AddLogicLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("scgpsCors");
app.UseAuthorization();
app.UseMiddleware<ExceptionHandler>();
app.MapControllers();

app.Run();