using FinalProject.Config;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using Subscriber_Data;

///CReate API 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//���� �� ����� APPSETIINGS
ConfigurationManager configuration = builder.Configuration;

//var setting = configuration.GetSection("setting").Get<Settings>();

//���� �� �����������
///���� ���� �API!!!!
builder.Services.AddControllers();

//builder.Services.AddSingleton(setting);

//.����� ������ ������� �� ����� ������ ��� �MAPPER 
builder.Services.ConfigureServices();
///��� �'
///add nuget 
///serilog
///serilog.aspnetcore
///serilog.sink.file 
//builder.Host.UseSerilog((context, configuration) =>
//{

//    ///����� �� ������ �������d 
//    configuration.ReadFrom.Configuration(context.Configuration);

//});
///����� �� ������� ������ ���� ������ 
builder.Services.AddDbContext<Weight_Watchers_Context>(option =>
{
    // ������ ����� DB ������
    option.UseSqlServer(configuration.GetConnectionString("FinalProject"));
}
       );

///���� ���� ���� ����� ��� API 
///������ �� ����� ���� 
builder.Services.AddEndpointsApiExplorer();

///����� �� ������ ��� ���� ��� 
builder.Services.AddSwaggerGen(
/*
    options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer Authentication with JWT Token",
            Type = SecuritySchemeType.Http
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
                       {
                  {
                  new OpenApiSecurityScheme
               {


                       Reference = new OpenApiReference
                                 {
               Id = "Bearer",
                     Type = ReferenceType.SecurityScheme
              }
                               },
                           new List<string>()
}
});
    }
*/
    );


var app = builder.Build();

// Output some text on the console
///���� �� �� �HTML �� ��� �TEST 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = builder.Configuration["JWT:Issuer"],
                     ValidAudience = builder.Configuration["JWT:Audience"],
                     IssuerSigningKey = new
                     SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                 };
             });*/
//����� ���� �� �� ����� ������� �� ���� 
//app.UseSerilogRequestLogging();

//���� ����� ��� �������� 
app.UseCors(builder =>
{
    builder
   .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
//app.UseHttpsRedirection();

//app.UseAuthorization();
///���� ���� ���� �RUTINGS 
app.MapControllers();
///����� �� ����� ���������
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

//���� 
app.Run();



