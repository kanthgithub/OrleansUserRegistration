using System.Threading.Tasks;
using Grains;
using Orleans;

namespace GrainInterfaces
{
    public interface IUserGrain : IGrainWithStringKey
    {
        Task<string> RegisterUser(string userName, string email, string postalCode, string phoneNumber);
        Task<User> GetUserById(string id);
        Task<User> GetUserByUserName(string userName);
        Task<List<User>> GetAllUsers();
    }
}