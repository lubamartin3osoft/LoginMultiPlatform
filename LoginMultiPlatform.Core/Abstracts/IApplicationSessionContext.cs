using System.Threading.Tasks;
using LoginMultiPlatform.Core.Data;

namespace LoginMultiPlatform.Core.Abstracts
{
   public interface IApplicationSessionContext
   {
      User User { get; }      
      Task LogOutAsync();
      Task StoreUserAsync(User user);
      Task InitializeConextAsync();
   }
}
