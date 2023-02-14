using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Models;
using Microsoft.IdentityModel.Tokens;
using Data.Repositories.IRepositories;

namespace Data.Services;

public class AuthService{
    private IUnitOfWork UnitOfWork {get; set;}
    public AuthService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
    public static string MasterKey = "eyJ1bmlxdWVfbmFtZSI6ImFuZHJlYmFsdGllcmkiLCJTdG9yZSI6InVzZXIiLCJCJuYmYiOjE1NjE2MDI2NjYdG9yZSI6InVzZXIiLCJCJuYmYiOjE1NjE2MDI2NjYU2MjIwNzQ2NiwiaWF0IjoxNd7eBg";

    public string GenerateToken(User user){
        var key = Encoding.ASCII.GetBytes(MasterKey);

        var tokenHandler = new JwtSecurityTokenHandler();        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
        Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        user.Token = tokenHandler.WriteToken(token);
        return user.Token;
    }

    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        var userLogged = await UnitOfWork.UserRepo.GetAsync(u => u.Password == user.Password);
        if(userLogged is not null)
            return true;
        return false;
    }
}