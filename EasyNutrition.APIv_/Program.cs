using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Mapping;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using EasyNutrition.APIv_.CoreBussines.Persistence.Repositories;
using EasyNutrition.APIv_.CoreBussines.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//var connectionStrings = builder.Configuration.GetConnectionString("DefaulConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseMySQL(connectionStrings).LogTo(Console.WriteLine, LogLevel.Information)
    //.EnableSensitiveDataLogging()
    //.EnableDetailedErrors());
    //options.UseInMemoryDatabase("easynutrition-api-in-memory");
    //options.UseMySQL(builder.Configuration.GetConnectionString("DefaulConnection"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"));

});


//.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors());
builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfwork, UnitOfwork>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
builder.Services.AddScoped<IProgressService, ProgressService>();
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IDietService, DietService>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();
builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

builder.Services.AddAutoMapper(typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));


builder.Services.AddSwaggerGen(options =>
{ 
options.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "Easynutrition API",
    Description = "Easynutrition web services",
    Contact = new OpenApiContact
    {
        Name = "Easynutrition.com",
        Url = new Uri("https://Easynutrition.com")
    }
  });
    options.EnableAnnotations();

});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200/");
                      });
});

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//using (var context = scope.ServiceProvider.GetService<AppDbContext>())
//{
   //context.Database.EnsureCreated();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
