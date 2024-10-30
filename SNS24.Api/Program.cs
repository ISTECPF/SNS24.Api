using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SNS24.WebApi.Data;
using SNS24.WebApi.Enums;
using SNS24.WebApi.Utilities;
using SNS24.WebApi.Utilities.Authorization;

namespace SNS24.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Add authorization services
            builder.Services.AddAuthorization(options =>
            {
                foreach (Role role in Enum.GetValues(typeof(Role)))
                {
                    options.AddPolicy(role.ToString(), policy =>
                        policy.Requirements.Add(new RoleRequirement(role)));
                }
            });

            // Register RoleRequirementHandler
            builder.Services.AddSingleton<IAuthorizationHandler, RoleRequirementHandler>();

            // Configure Services and Authentication
            builder.Services.ConfigureAuthentication(builder.Configuration);
            builder.Services.ConfigureServices();
            builder.Services.ConfigureSwagger();

            var app = builder.Build();

            // Apply migrations at startup
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
