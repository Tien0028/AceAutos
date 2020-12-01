using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AceAutos.Infrastructure.Data.Helpers
{
    public interface IAuthenticationHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        string GenerateToken(List<Claim> claims);
    }
}
