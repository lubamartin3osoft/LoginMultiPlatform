using System.Threading.Tasks;
using LoginMultiPlatform.Core.Abstracts;
using LoginMultiPlatform.Core.Data;
using SQLite.Net.Async;

namespace LoginMultiPlatform.Core.Repository
{
   public class UserRepository : IUserRepository
   {
      private readonly SQLiteAsyncConnection _connection;

      public UserRepository(SQLiteAsyncConnection connection)
      {
         _connection = connection;
      }

      public async Task InsertEmailAsync(User user)
      {
         await _connection.InsertOrReplaceAsync(user);
      }

      public Task<User> GetUserlAsync()
      {
         Task<User> email = _connection.Table<User>().FirstOrDefaultAsync();
         return email;
      }

      public async Task DeleteEmailAsync(User user)
      {
         await _connection.DeleteAsync(user);
      }
   }
}
