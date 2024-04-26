using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICompanionManager>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<CompanionContext>();
    optionsBuilder.UseSqlite("Data Source=CompationDataBase.db");

    var companionContext = new CompanionContext(optionsBuilder.Options);
    companionContext.Database.EnsureCreated();

    ICompanionManager companionManager = new CompanionManager(companionContext);

    return companionManager;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();
