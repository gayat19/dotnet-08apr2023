using AuthenticationAPI.Models;
using AuthenticationAPI.Models.DTO;

namespace AuthenticationAPI.Interfaces
{
    public interface IRepo
    {
        Task<USer> Add(USer user);
        Task<USer> Get(USer user);
    }
}
