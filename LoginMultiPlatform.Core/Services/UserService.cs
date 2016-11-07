using System.Threading.Tasks;
using LoginMultiPlatform.Core.Abstracts;
using LoginMultiPlatform.Core.Data;

namespace LoginMultiPlatform.Core.Services
{
   public class UserService
   {
      private readonly IUserRepository _userRepository;

      public UserService(IUserRepository userRepository)
      {
         _userRepository = userRepository;
      }

      public async Task InsertEmailAsync(User user)
      {
         await _userRepository.InsertUserAsync(user);
      }

      public async Task<User> GetEmailAsync()
      {
         User user = await _userRepository.GetUserAsync();
         return user;
      }
   }
}
