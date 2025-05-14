using Contato.Leitura.Domain.Interfaces;
using Contato.Leitura.Infra.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permite qualquer origem
              .AllowAnyMethod()  // Permite qualquer método (GET, POST, etc.)
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

// Configuração do MongoDB
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var mongoDbSettings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(mongoDbSettings.ConnectionString);
});

// Registro de repositório
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Serviços padrão da Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);
});

builder.WebHost.UseUrls("http://*:7100");

var app = builder.Build();

// Ativa o CORS com a política "AllowAll"
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
