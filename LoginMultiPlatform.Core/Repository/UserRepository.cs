using System.Threading.Tasks;
using LoginMultiPlatform.Core.Abstracts;
using LoginMultiPlatform.Core.Data;
using LoginMultiPlatform.Core.Mappers;
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

      public async Task InsertUserAsync(User user)
      {
         await _connection.InsertOrReplaceAsync(UserMapper.FromDomainToData(user));
      }

      public async Task<User> GetUserAsync()
      {
         UserEntity userEntity = await _connection.Table<UserEntity>().FirstOrDefaultAsync();
         return UserMapper.FromDataToDomain(userEntity);
      }

      public async Task DeleteUserAsync(User user)
      {
         await _connection.DeleteAsync(UserMapper.FromDomainToData(user));
      }

      public async Task DeleteAllUsersAsync()
      {
         await _connection.DeleteAllAsync<UserEntity>();
      }
   }
}
