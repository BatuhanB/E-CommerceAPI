using Commerce.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);
var myCors = "_myCors";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: myCors, builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myCors);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
