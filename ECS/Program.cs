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
//api�ӿ�ҳ��
builder.Services.AddSwaggerGen(option => {
    typeof(ApiVersion).GetEnumNames().ToList().ForEach(version => {
        option.SwaggerDoc(version,new Microsoft.OpenApi.Models.OpenApiInfo() {
            Title = $"{version} Api�ĵ�",
            Version = version,
            Description = $"ͨ�ð汾��CoreApi�汾{version}"
        });
    });
    #region ����չʾע��
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
builder.Services.AddAuthorization(); //������Ȩ
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //��Ȩ��ʽ
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,  //�Ƿ���֤ʧЧʱ��
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
                //�����֤ʧ�ܳ���
                OnAuthenticationFailed = AuthenticationFailedContext =>
                {
                    return Task.CompletedTask;
                },
                //��Ȩʧ�ܴ���
                OnForbidden = ForbiddenContext =>
                {
                    return Task.CompletedTask;
                },
                //����ʱ�򴥷�
                OnMessageReceived = MessageReceivedContext =>
                {
                    return Task.CompletedTask;
                },
                //Token��֤�ɹ�����
                OnTokenValidated = TokenValidatedContext =>
                {
                    return Task.CompletedTask;
                },
                //û��token,��ȨHandler����ʧ�ܴ���
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
                option.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"�汾��{version}");
            }
        });
    }
app.UseStaticFiles();
app.UseAuthentication();//��Ȩ
app.UseAuthorization();//��Ȩ
app.MapControllers();
app.Run();
