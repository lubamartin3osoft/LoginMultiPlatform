using Foundation;
using LoginMultiPlatform.Core.Services;
using LoginMultiPlatform.Core.Utilities;
using LoginMultiPlatform.iOS.ViewControlers;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;

namespace LoginMultiPlatform.iOS
{
   // The UIApplicationDelegate for the application. This class is responsible for launching the
   // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
   [Register("AppDelegate")]
   public class AppDelegate : UIApplicationDelegate
   {
      // class-level declarations

      public override UIWindow Window
      {
         get;
         set;
      }

      public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
      {                
         Initialize();         

         return true;
      }

      private async void Initialize()
      {
         Window = new UIWindow(UIScreen.MainScreen.Bounds);
         Window.RootViewController = new LoginViewControler();

         SQLitePlatformIOS platform = new SQLitePlatformIOS();
         platform.SQLiteApi.Config(ConfigOption.MultiThread);
         IosDatabaseEnvironment databaseEnvironment = new IosDatabaseEnvironment();
         DatabaseService databaseService = new DatabaseService(databaseEnvironment, () =>
         {
            SQLiteConnectionWithLock connectionWithLock = new SQLiteConnectionWithLock(platform, new SQLiteConnectionString(databaseEnvironment.DatabasePath, false));
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(() => connectionWithLock);
            return connection;
         });
         
         await databaseService.InitializeDatabaseConnectionAsync();
         BaseContainer.Instance.InitializeDependencies(databaseService.DatabaseConnection, () => ApplicationSessionContext.Instance);
         await ApplicationSessionContext.Instance.InitializeConextAsync();

         if (ApplicationSessionContext.Instance.User != null)
         {
            Window.RootViewController = new LogoutViewController();
         }
         else
         {
            Window.RootViewController = new LoginViewControler();
         }

         Window.MakeKeyAndVisible();
      }

      public override void OnResignActivation(UIApplication application)
      {
         // Invoked when the application is about to move from active to inactive state.
         // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
         // or when the user quits the application and it begins the transition to the background state.
         // Games should use this method to pause the game.
      }

      public override void DidEnterBackground(UIApplication application)
      {
         // Use this method to release shared resources, save user data, invalidate timers and store the application state.
         // If your application supports background exection this method is called instead of WillTerminate when the user quits.
      }

      public override void WillEnterForeground(UIApplication application)
      {
         // Called as part of the transiton from background to active state.
         // Here you can undo many of the changes made on entering the background.
      }

      public override void OnActivated(UIApplication application)
      {
         // Restart any tasks that were paused (or not yet started) while the application was inactive. 
         // If the application was previously in the background, optionally refresh the user interface.
      }

      public override void WillTerminate(UIApplication application)
      {
         // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
      }
   }
}


