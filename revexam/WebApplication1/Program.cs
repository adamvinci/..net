var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/weatherforecast/{price}/{country}", (double price, string country) =>
{
    double priceWithTva = country == "BE" ? (price * 1.21) : country == "FR" ? (price * 1.20) : -1;
    if (priceWithTva < 0) return Results.BadRequest("only be or fr");
    return Results.Ok(priceWithTva);
});

app.Run();

