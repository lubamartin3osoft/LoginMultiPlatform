using System.Threading.Tasks;
using LoginMultiPlatform.Core.Data;

namespace LoginMultiPlatform.Core.Abstracts
{
   public interface IUserRepository
   {
      Task InsertEmailAsync(User user);
      Task<User> GetEmailAsync();
      Task DeleteEmailAsync(User user);
   }
}
