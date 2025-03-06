using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filmes_Context>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Adicionar o  e a interface ao container de inje��o de depend�ncia
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Adicionar o servi�o de Controllers
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        ClockSkew = TimeSpan.FromMinutes(5),

        ValidIssuer = "api_filmes_senai",

        ValidAudience = "api_filmes_senai"
    };
});

var app = builder.Build();

//Adicionar o mapeamento dos controllers
app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
