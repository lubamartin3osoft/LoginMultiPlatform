using System.Threading.Tasks;
using LoginMultiPlatform.Core.Data;

namespace LoginMultiPlatform.Core.Abstracts
{
   public interface IApplicationSessionContext
   {
      User User { get; }      
      Task LogOutAsync();
      Task StoreEmailAsync(User user);
      Task InitializeConextAsync(IUserRepository userRepository);
   }
}
