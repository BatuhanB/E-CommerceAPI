using Commerce.Application.Validators.Products;
using Commerce.Infrastructure.Filters;
using Commerce.Persistence.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var myCors = "_myCors";
// Add services to the container.

builder.Services.AddControllers(opt => opt.Filters.Add<ValidationFilter>())
    .AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<AddProductValidator>())
    .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: myCors, builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(origin => true);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseCors(myCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
