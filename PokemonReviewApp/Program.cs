using PokemonReviewApp.Data;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

//WebApplication sýnýfýnýn metodunu bir deðiþkene atadýk
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Web application sýnýfýnýn hizmetlerini(Services) kullanarak bazý içerikleri yarat yani ekle
builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IReviewRepository,ReviewRepository>();
builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//swagger oluþturucuyu içindeki hizmetler koleksiyonuna ekledik
builder.Services.AddSwaggerGen();
//UseSqlServer ile birlikte daha önce “appsettings.json” da tanýmladýðýmýz
//“connectionString” bilgisini veriyoruz.
builder.Services.AddDbContext<DataContext> (options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

//veri eklemesini uyguladýðýmýz metot
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}
// Configure the HTTP request pipeline.
//Swagger çalýþtýrdýðýmýz etkinleþtirdiðimiz kýsým
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
