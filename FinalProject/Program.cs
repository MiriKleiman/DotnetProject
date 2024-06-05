using FinalProject.Config;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using Subscriber_Data;

///CReate API 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//מכיל את הקובץ APPSETIINGS
ConfigurationManager configuration = builder.Configuration;

//var setting = configuration.GetSection("setting").Get<Settings>();

//קבלת כל הקונטרולררי
///שורת חובה בAPI!!!!
builder.Services.AddControllers();

//builder.Services.AddSingleton(setting);

//.קריאה להרחבה שמפעילה את הזרקת תלויות ואת הMAPPER 
builder.Services.ConfigureServices();
///לוג ל'
///add nuget 
///serilog
///serilog.aspnetcore
///serilog.sink.file 
//builder.Host.UseSerilog((context, configuration) =>
//{

//    ///קריאה של ההגדות מהקונפיd 
//    configuration.ReadFrom.Configuration(context.Configuration);

//});
///מוסיפ את האפשרות להשתמש במסד נתונים 
builder.Services.AddDbContext<Weight_Watchers_Context>(option =>
{
    // הגדרתי לאיזה DB להתחבר
    option.UseSqlServer(configuration.GetConnectionString("FinalProject"));
}
       );

///שורת בסיס חיבת להיות בכל API 
///מגדירה את כתובת האתר 
builder.Services.AddEndpointsApiExplorer();

///הגדרה של הגדרות הדף הרצה טסט 
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
///יוצר את דף הHTML של אתר הTEST 
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
//כתיבה ללוג של כל קריאה אוטמטית לא חובה 
//app.UseSerilogRequestLogging();

//הוסת דיבור בין פרויקטים 
app.UseCors(builder =>
{
    builder
   .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
//app.UseHttpsRedirection();

//app.UseAuthorization();
///שורת חובה פונה לRUTINGS 
app.MapControllers();
///מגדיר את הפעלה הממידלוור
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

//הרצה 
app.Run();



