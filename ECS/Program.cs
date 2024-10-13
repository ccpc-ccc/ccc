using ESC.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using YF.MWS.BaseMetadata;
using YF.MWS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option => {
    //option.Conventions.Insert(0, new RouteConvention(new Microsoft.AspNetCore.Mvc.RouteAttribute("api/")));
}).AddJsonOptions(options=> {
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter("yyyy-MM-dd HH:mm:ss"));
    //options.JsonSerializerOptions.Converters.Add(new DateTimeJsonCon)
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(option => {
    option.AddPolicy("any", builder => {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});
//api接口页面
builder.Services.AddSwaggerGen(option => {
    typeof(ApiVersion).GetEnumNames().ToList().ForEach(version => {
        option.SwaggerDoc(version,new Microsoft.OpenApi.Models.OpenApiInfo() {
            Title = $"{version} Api文档",
            Version = version,
            Description = $"通用版本的CoreApi版本{version}"
        });
    });
    #region 配置展示注释
    var file = Path.Combine(AppContext.BaseDirectory, "ESC.xml");
    option.IncludeXmlComments(file, true);
    option.OrderActionsBy(o => o.RelativePath);
    #endregion
});
builder.Services.AddTransient<CustomHSJWT>();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));
JWTTokenOptions tokenOptions=new JWTTokenOptions();
builder.Configuration.Bind("JWTTokenOptions", tokenOptions);
builder.Services.AddAuthorization(); //启用授权
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //授权方式
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,  //是否验证失效时间
                ValidateIssuerSigningKey = true,
                ValidAudience=tokenOptions.Audience,
                ValidIssuer=tokenOptions.Issuer,
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                AudienceValidator = (m, n, z) => {
                    return true;
                },
                LifetimeValidator = (notBefore, expires, securityToken, validationParameters)=>{
                    return true;
                }
            };
            options.Events = new JwtBearerEvents() {
                //身份验证失败出发
                OnAuthenticationFailed = AuthenticationFailedContext =>
                {
                    return Task.CompletedTask;
                },
                //授权失败触发
                OnForbidden = ForbiddenContext =>
                {
                    return Task.CompletedTask;
                },
                //请求时候触发
                OnMessageReceived = MessageReceivedContext =>
                {
                    return Task.CompletedTask;
                },
                //Token验证成功触发
                OnTokenValidated = TokenValidatedContext =>
                {
                    return Task.CompletedTask;
                },
                //没有token,授权Handler处理失败触发
                OnChallenge = JwtBearerChallengeContext =>
                {
                    return Task.CompletedTask;
                }
            };
        });
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
var app = builder.Build();
app.UseCors("any");
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) {
        app.UseSwagger();
        app.UseSwaggerUI(option => {
            foreach (var version in typeof(ApiVersion).GetEnumNames()) {
                option.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"版本：{version}");
            }
        });
    }
app.UseStaticFiles();
app.UseAuthentication();//鉴权
app.UseAuthorization();//授权
app.MapControllers();
app.Run();
