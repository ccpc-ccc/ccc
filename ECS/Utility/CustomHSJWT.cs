using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YF.MWS.Models;

namespace ESC.Utility {
    public class CustomHSJWT {
        private readonly JWTTokenOptions _jwtOptions;
        public CustomHSJWT(IOptionsMonitor<JWTTokenOptions> jwtOptions) {
            this._jwtOptions = jwtOptions.CurrentValue; 
        }
        public string GetToken(S_User user) {
            Claim[] claims = new[] {
                new Claim(ClaimTypes.Name,user.Id),
                new Claim(ClaimTypes.Role,"User"),
                new Claim("UserName",user.UserName)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey)); //秘钥
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//加密方式
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GetCompanyToken(S_Company company) {
            Claim[] claims = new[] {
                new Claim(ClaimTypes.Name,company.Id),
                new Claim(ClaimTypes.Role,"Company"),
                new Claim("CompanyName",company.CompanyName)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey)); //秘钥
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//加密方式
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GetClientToken(S_Client client) {
            Claim[] claims = new[] {
                new Claim(ClaimTypes.Name,client.Id),
                new Claim(ClaimTypes.Role,"Client"),
                new Claim("MachineCode",client.MachineCode)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey)); //秘钥
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//加密方式
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static TypeAndValue GetUserId(string token) {
            try {
            JwtSecurityToken tj = new JwtSecurityTokenHandler().ReadJwtToken(token);
            //获取Claim 相关数据
            IEnumerable<Claim> j = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            //查找类型为ClaimTypes.Name的数据，可以通过Value获取内容
            string id = string.Empty;
                string type = string.Empty;
            foreach (Claim claim in j) {
                if (claim.Type == ClaimTypes.Role) {
                    if (claim.Value != "User"&&claim.Value != "Company"&&claim.Value != "Client") return null;
                        type = claim.Value;
                }
                    if (claim.Type == ClaimTypes.Name) id= claim.Value;
            }
                return new TypeAndValue() { Type=type,Value=id };
            }catch (Exception ex) { 
                return null;
            }
        }
    }
    public class TypeAndValue {
        public string Type { get; set; }
        public string Value { get; set; }
    }
    public class DateTimeJsonConverter : System.Text.Json.Serialization.JsonConverter<DateTime> {
        private readonly string Format;
        public DateTimeJsonConverter(string format) {
            Format = format;
        }

        public override DateTime Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options) {
            return DateTime.ParseExact(reader.GetString(), Format, null);
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, DateTime value, System.Text.Json.JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
