using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt
{
    [ApiController]
    [Route("/api/claims")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            JwtTokenGenerator jwtTokenGenerator = new JwtTokenGenerator();

            return jwtTokenGenerator.Generate("test", "test");
        }        
        
        [HttpPut]
        [Authorize]
        public string Put()
        {
            JwtTokenGenerator jwtTokenGenerator = new JwtTokenGenerator();

            return jwtTokenGenerator.Generate("test", "test");
        }
    }
}