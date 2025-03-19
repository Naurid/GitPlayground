var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IList<Product>>(sp =>
{
    return new List<Product>(){
    new Product(1, "Apple", 0.99m),
    new Product(2, "Banana", 0.59m),
    new Product(3, "Orange", 1.29m),
    new Product(4, "Grapes", 2.49m),
    new Product(5, "Mango", 1.99m),
    new Product(6, "Blueberry", 3.49m),
    new Product(7, "Watermelon", 4.99m),
    new Product(8, "Pineapple", 3.99m),
    new Product(9, "Strawberry", 2.79m),
    new Product(10, "Peach", 1.69m),
    new Product(11, "Plum", 1.49m),
    new Product(12, "Avocado", 2.89m),
    new Product(13, "Lemon", 0.79m),
    new Product(14, "Tomato", 1.29m),
    new Product(15, "Cucumber", 0.99m),
    new Product(16, "Carrot", 1.19m),
    new Product(17, "Broccoli", 2.39m),
    new Product(18, "Spinach", 1.99m),
    new Product(19, "Bell Pepper", 1.59m),
    new Product(20, "Cabbage", 1.49m)
    };
});

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

app.Run();
