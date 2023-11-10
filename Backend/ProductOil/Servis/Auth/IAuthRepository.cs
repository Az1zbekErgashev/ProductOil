using ProductOil.Dto;
using ProductOil.Enitiy;

namespace ProductOil.Servis.Auth
{
    public interface IAuthRepository
    {
        Task<User> Register(UserDto userDto);
        Task<string> Login(UserDto userDto);
        Task<List<User>> GetAllUsers();
    }
}
