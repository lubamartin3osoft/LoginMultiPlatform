using Android.App;
using Android.Content;
using Android.OS;
using LoginMultiPlatform.Core.Repository;
using LoginMultiPlatform.Core.Services;
using LoginMultiPlatform.Core.Utilities;
using LoginMultiPlatform.Droid.Activities;
using LoginMultiPlatform.Droid.Utilities;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;

namespace LoginMultiPlatform.Droid
{
   [Activity(Label = "MainActivity", MainLauncher = true, Icon = "@drawable/icon")]
   public class MainActivity : Activity
   {      

      protected override async void OnCreate(Bundle bundle)
      {
         base.OnCreate(bundle);
         DroidDatabaseEnviroment databaseEnviroment = new DroidDatabaseEnviroment();
         ISQLitePlatform platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

         DatabaseService databaseService = new DatabaseService(databaseEnviroment, () =>
         {
            SQLiteConnectionWithLock connectionWithLock = new SQLiteConnectionWithLock(platform, new SQLiteConnectionString(databaseEnviroment.DatabasePath, false));
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(() => connectionWithLock);
            return connection;
         });

         await databaseService.InitializeDatabaseConnectionAsync();
         await ApplicationSessionContext.Instance.InitializeConextAsync(
            new UserRepository(databaseService.DatabaseConnection));
         BaseContainer.Instance.InitializeDependencies(databaseService.DatabaseConnection, () => ApplicationSessionContext.Instance);

         //Autologin
         Intent intent = ApplicationSessionContext.Instance.IsLogged
            ? new Intent(ApplicationContext, typeof(LogoutActivity))
            : new Intent(ApplicationContext, typeof(LoginActivity));
         StartActivity(intent);
      }
   }
}

