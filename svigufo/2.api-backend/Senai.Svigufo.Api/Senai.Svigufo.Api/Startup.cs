using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Senai.Svigufo.Api
{
    public class Startup
    {
        // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio

        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona o mvc e coloca a versão de compatibilidade que estamos trabalhando
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            // services.AddTransient<ITipoEventoRepository, TipoEventoRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Svigufo API", Version = "v1" });
            });

            services.AddAuthentication(options =>
            {
                // esquema de autenticação padrão
                // Bearer - quem será o portador do jwt
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                // parâmetros para autenticar
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    // quando um token for enviado na requisição, preciso saber como será sua validação
                    // quem está solicitando
                    ValidateIssuer = true,
                    // quem está realizando a audiência
                    ValidateAudience = true,
                    // tempo de expiração
                    ValidateLifetime = true,
                    // chave de assinatura que será utilizada por quem está validando
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("svigufo-chave-autenticacao")),
                    // tempo de expiração
                    ClockSkew = TimeSpan.FromMinutes(5),
                    // quem está fazendo a própria validação
                    ValidIssuer = "Svigufo.WebApi",
                    // de onde está vindo
                    ValidAudience = "Svigufo.WebApi"
                };
            });

            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            //        .RequireAuthenticatedUser().Build());
            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Svigufo API V1");
            });
            
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseMvc();

        }
    }
}
