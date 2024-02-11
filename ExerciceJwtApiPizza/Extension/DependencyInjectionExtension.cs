using ExerciceJwtApiPizza.Data;
using ExerciceJwtApiPizza.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using System.Security.Claims;
using System.Text;

namespace ExerciceJwtApiPizza.Extension
{
public static class DependencyInjectionExtension
    {
        // Méthode principale pour l'injection de dépendances
        public static void InjectDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(); // Ajoute le support pour les contrôleurs MVC
            builder.AddSwagger(); // Ajoute et configure Swagger
            builder.AddRepositories(); // Ajoute les repositories personnalisés
            builder.AddDatabase(); // Configure la base de données
            builder.AddAuthentication(); // Ajoute et configure l'authentification JWT
            // Ajoute AutoMapper pour le mappage entre les modèles de données et DTOs
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // Méthode pour ajouter et configurer Swagger
        private static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer(); // Active l'explorateur d'API
            builder.Services.AddSwaggerGen(c =>
            {
                // Configuration de base pour le document Swagger
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactApi", Description = "API pour la gestion des contacts" });
                // Ajoute la définition de sécurité pour l'utilisation des JWT dans Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entête d'autorisation JWT utilisant le schéma Bearer",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.Http
                });
                // Exige que l'authentification JWT soit utilisée pour toutes les routes
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }});
            });
        }

        // Méthode pour ajouter les repositories à l'injection de dépendances
        private static void AddRepositories(this WebApplicationBuilder builder)
        {
            // Ajoute le repository Contact comme un service avec une portée de demande
            builder.Services.AddScoped<IRepository<User>, UserRepository>();
        }

        // Méthode pour configurer la base de données
        private static void AddDatabase(this WebApplicationBuilder builder)
        {
            // Récupère la chaîne de connexion et configure le contexte de la base de données avec EF Core
            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
        }

        // Méthode pour ajouter et configurer l'authentification JWT
        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            var appSettingSection = builder.Configuration.GetSection(nameof(AppSettings));
            builder.Services.Configure<AppSettings>(appSettingSection); // Lie les paramètres de configuration
            AppSettings appSettings = appSettingSection.Get<AppSettings>(); // Récupère les paramètres de configuration

            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey); // Convertit la clé secrète pour la signature

            // Configure l'authentification JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true; // Sauvegarde le token dans le contexte de l'authentification
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true, // Valide la clé de signature de l'émetteur
                        IssuerSigningKey = new SymmetricSecurityKey(key), // Définit la clé de signature
                        ValidateAudience = true, // Valide le public cible du token
                        ValidAudience = appSettings.ValidAudience, // Définit le public cible valide
                        ValidateIssuer = true, // Valide l'émetteur du token
                        ValidIssuer = appSettings.ValidIssuer, // Définit l'émetteur valide
                        ValidateLifetime = true, // Valide la durée de vie du token
                        ClockSkew = TimeSpan.Zero // Ajuste la tolérance de l'horloge pour la validation du token
                    };
                });

            // Configure les politiques d'autorisation basées sur les rôles
            builder.Services.AddAuthorization(options =>
            {
                // Politique pour les administrateurs
                options.AddPolicy(Constants.PolicyAdmin, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, Constants.RoleAdmin);
                });

                // Politique pour les utilisateurs standards
                options.AddPolicy(Constants.PolicyUser, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, Constants.RoleUser);
                });
            });
        }
    }
}
