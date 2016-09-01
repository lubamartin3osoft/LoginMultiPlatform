using System.Threading.Tasks;
using LoginMultiPlatform.Core.Data;
using SQLite.Net.Async;

namespace LoginMultiPlatform.Core.Database
{
   public class DatabaseManager
   {
      private readonly SQLiteAsyncConnection _connection;

      public DatabaseManager(SQLiteAsyncConnection connection)
      {
         _connection = connection;
      }

      public async Task CreateDatabaseTablesAsync()
      {
         await _connection.DeleteAllAsync<User>();
         await _connection.CreateTableAsync<User>();
      }

      public async Task DeleteDatabaseTablesAsync()
      {
         await _connection.DropTableAsync<User>();
      }
   }
}
