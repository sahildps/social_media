using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();

// if(builder.Environment.IsDevelopment()){
//     app.UseDeveloperExceptionPage();
// }

// app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();


app.UseCors(builder=> builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();    

app.MapControllers();

app.Run();
