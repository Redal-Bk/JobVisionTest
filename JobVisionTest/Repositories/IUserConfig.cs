using JobVisionTest.Domain.DTOs;

namespace JobVisionTest.Repositories
{
    public interface IUserConfig
    {
        Task<bool> AddUser(UserDTO user);
        Task<bool> RemoveUser(UserDTO user);
        Task<bool> UpdateUser(UserDTO user);
    }
}
