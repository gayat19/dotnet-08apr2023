using AuthenticationAPI.Models.DTO;

namespace AuthenticationAPI.Interfaces
{
    public interface IGenerateToken
    {
        string GenerateToken(UserDTO user);
    }
}
