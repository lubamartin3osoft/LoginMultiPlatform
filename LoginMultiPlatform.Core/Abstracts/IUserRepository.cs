using System.Threading.Tasks;
using LoginMultiPlatform.Core.Data;

namespace LoginMultiPlatform.Core.Abstracts
{
   public interface IUserRepository
   {
      Task InsertUserAsync(User user);
      Task<User> GetUserAsync();
      Task DeleteUserAsync(User user);
      Task DeleteAllUsersAsync();
   }
}
