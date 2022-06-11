using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace jwt
{
    public static class JwTBearerConfiguration
    {
        public static AuthenticationBuilder SetJwtConfig(this AuthenticationBuilder builder, string issuer,
            string audience)
        {
            return builder
                .Services
                .AddAuthorization()
                .AddAuthentication(opt =>
                {
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidIssuer = "test",
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes("w+1alOGke7bSPTgeMVlDXS5FRg3jcjRxkBtG0u3NrOo="))
                    };
                });
        }
    }
}