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




app.MapGet("/tva/{country}/{price:double}", (double price, string country) =>
{
    if (country != "BE" && country != "FR")
    {
        return Results.BadRequest("Invalid country code. Please use 'BE' or 'FR'.");
    }

    var vatRate = country == "BE" ? 0.21 : 0.20;
    var priceWithVAT = price * (1 + vatRate);

    return Results.Ok(new { Price = price, Country = country, PriceWithVAT = priceWithVAT });
});


app.Run();

