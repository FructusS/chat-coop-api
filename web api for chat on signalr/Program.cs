using Microsoft.EntityFrameworkCore;
using web_api_for_chat_on_signalr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer("workstation id=chatcoop.mssql.somee.com;packet size=4096;user id=chat_SQLLogin_1;pwd=9hwofpmz2i;data source=chatcoop.mssql.somee.com;persist security info=False;initial catalog=chatcoop"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chatHub");
app.Run();
