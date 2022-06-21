using Hellang.Middleware.ProblemDetails;
using Microsoft.EntityFrameworkCore;
using RentalPage.Bll.Exceptions;
using RentalPage.Bll.Interfaces;
using RentalPage.Bll.Services;
using RentalPage.Bll.Dtos;
using RentalPage.Dal;
using System.Text.Json.Serialization;
using WebApiLab.Api.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers(options => options.EnableEndpointRouting = true)
    .AddJsonOptions(opts =>
    {
        //opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddAutoMapper(typeof(WebApiProfile));
builder.Services.AddOpenApiDocument();
builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(builder.Configuration["ConnectionStrings:AzureConnString"]));

builder.Services.AddTransient<IRentItemService, RentItemService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRentedItemService, RentedItemService>();

builder.Services.AddProblemDetails(options =>
{
    options.IncludeExceptionDetails = (ctx, ex) => false;
    options.Map<EntityNotFoundException>(
        (ctx, ex) =>
        {
            var pd = StatusCodeProblemDetails.Create(StatusCodes.Status404NotFound);
            pd.Title = ex.Message;
            return pd;
        }
    );
    options.Map<DbUpdateConcurrencyException>(
        ex => new ConcurrencyProblemDetails(ex));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAll", opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); ;
    c.AddPolicy("anotherOne", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); ;
    } );
});

var app = builder.Build();
app.UseProblemDetails();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



app.Run();
