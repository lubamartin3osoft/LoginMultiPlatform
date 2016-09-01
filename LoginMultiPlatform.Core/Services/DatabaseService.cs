using System;
using System.Threading.Tasks;
using LoginMultiPlatform.Core.Abstracts;
using LoginMultiPlatform.Core.Database;
using SQLite.Net.Async;

namespace LoginMultiPlatform.Core.Services
{
   public class DatabaseService
   {
      private readonly IDatabaseEvironment _evironment;
      private DatabaseManager _databaseManager;
      private readonly Func<SQLiteAsyncConnection> _createConnectionFunc;

      public DatabaseService(IDatabaseEvironment evironment, Func<SQLiteAsyncConnection> createConnectionFunc)
      {
         _evironment = evironment;
         _createConnectionFunc = createConnectionFunc;
      }

      public SQLiteAsyncConnection DatabaseConnection { get; private set; }

      public async Task<SQLiteAsyncConnection> InitializeDatabaseConnectionAsync()
      {
         _evironment.CreateDatabaseDirectoryIfNeccessary();

         if (!_evironment.ExistDatabase)
         {
            DatabaseConnection = _createConnectionFunc.Invoke();
            _databaseManager = new DatabaseManager(DatabaseConnection);
            await _databaseManager.CreateDatabaseTablesAsync();
         }
         else
         {
            DatabaseConnection = _createConnectionFunc.Invoke();
            _databaseManager = new DatabaseManager(DatabaseConnection);
         }

         return DatabaseConnection;
      }
   }
}
