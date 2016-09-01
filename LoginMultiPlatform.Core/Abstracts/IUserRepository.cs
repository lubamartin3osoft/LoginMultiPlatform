using System.Threading.Tasks;
using LoginMultiPlatform.Core.Data;

namespace LoginMultiPlatform.Core.Abstracts
{
   public interface IUserRepository
   {
      Task InsertEmailAsync(User user);
      Task<User> GetUserlAsync();
      Task DeleteEmailAsync(User user);
   }
}
