
using DsInsurance.Data;
using DsInsurance.Exceptions;
using DsInsurance.Mappers;
using DsInsurance.Repositories.Implemetations;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Implementations;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace DsInsurance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // **********   ADD SERVICES ************

            // Connection String Configuration
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<InsuranceContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));

                options.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("*");

                });
            });

            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IRoleService, RoleService>();
            builder.Services.AddTransient<IAddressService, AddressService>();
            builder.Services.AddTransient<IStateService, StateService>();
            builder.Services.AddTransient<ICityService, CityService>();
            builder.Services.AddTransient<IAgentService, AgentService>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IAdminService, AdminService>();
            builder.Services.AddTransient<IInsuranceSchemeService, InsuranceSchemeService>();
            builder.Services.AddTransient<IInsurancePlanService, InsurancePlanService>();
            builder.Services.AddTransient<INomineeService, NomineeService>();
            builder.Services.AddTransient<IPolicyAccountService, PolicyAccountService>();
            builder.Services.AddTransient<IPolicyCoverageService, PolicyCoverageService>();
            builder.Services.AddTransient<IPolicyTransactionService, PolicyTransactionService>();
            builder.Services.AddTransient<IInstallmentService, InstallmentService>();
            builder.Services.AddTransient<IDocumentService, DocumentService>();
            builder.Services.AddTransient<IWithdrawRequestService, WithdrawRequestService>();



            builder.Services.AddControllers();

            // Igonre Cycles
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddExceptionHandler<AppExceptionHandler>();
            //add auth scheme--validating token
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(builder.Configuration.GetSection("AppSettings:Key").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler(_ => { });
            app.UseHttpsRedirection();
            app.UseCors("AllowAngularApp");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
