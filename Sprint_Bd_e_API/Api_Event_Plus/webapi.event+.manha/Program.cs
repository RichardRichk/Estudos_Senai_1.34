
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace webapi.event_.manha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            //Adiciona servi�o de Jwt Bearer (forma de autentica��o)
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = "JwtBearer";
                options.DefaultAuthenticateScheme = "JwtBearer";
            })
                 .AddJwtBearer("JwtBearer", options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         //valida quem est� solicitando
                         ValidateIssuer = true,

                         //valida quem est� recebendo
                         ValidateAudience = true,

                         //define se o tempo de expira��o ser� validado
                         ValidateLifetime = true,

                         //forma de criptografia e valida a chave de autentica��o
                         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-plus-chave-autenticacao-webapi-dev")),

                         //valida o tempo de expira��o do token
                         ClockSkew = TimeSpan.FromMinutes(5),

                         //nome do issuer (de onde est� vindo)
                         ValidIssuer = "Event+_Manha",

                         //nome do audience (para onde est� indo)
                         ValidAudience = "Event+_Manha"
                     };
                 });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {

                //Adiciona informacoes sobre a API no Swagger
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API inlock Manha",
                    Description = "API para gerenciamento de inlock",
                    Contact = new OpenApiContact
                    {
                        Name = "GitHub Do Desenvolvedor",
                        Url = new Uri("https://github.com/RichardRichk")
                    },
                });

                //Configure o Swagger para usar o arquivo XML gerado com as instru��es anteriores.
                //using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Value: Bearer TokenJWT ",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                    },
                    new string[] {}
                }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}