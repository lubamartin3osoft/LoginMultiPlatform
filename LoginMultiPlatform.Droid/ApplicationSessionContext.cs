using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Preferences;
using LoginMultiPlatform.Core.Abstracts;
using LoginMultiPlatform.Core.Data;
using LoginMultiPlatform.Droid.Activities;

namespace LoginMultiPlatform.Droid
{
   public class ApplicationSessionContext : IApplicationSessionContext
   {

      private const string IsLoggedKey = "IsLogged";
      private static ApplicationSessionContext _instance;
      private IUserRepository _userRepository;

      private ApplicationSessionContext()
      {
         
      }

      public static ApplicationSessionContext Instance => _instance ?? (_instance = new ApplicationSessionContext());

      public User User { get; private set; }

      public bool IsLogged
      {
         get { return ReadBoolSharedPreferencies(IsLoggedKey); }
         set { WriteBoolToSharedPreferencies(value, IsLoggedKey); }
      }      

      public async Task LogOutAsync()
      {
         await _userRepository.DeleteUserAsync(User);
         IsLogged = false;
         LoginActivity.Navigate();
      }

      public async Task StoreUserAsync(User user)
      {
         IsLogged = true;
         User = user;
         await _userRepository.DeleteAllUsersAsync();
         await _userRepository.InsertUserAsync(user);
      }

      public async Task InitializeConextAsync(IUserRepository userRepository)
      {
         _userRepository = userRepository;
         User = await _userRepository.GetUserAsync();
      }

      private void WriteBoolToSharedPreferencies(bool value, string key)
      {
         ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
         ISharedPreferencesEditor preferencesEditor = sharedPreferences.Edit();
         preferencesEditor.PutBoolean(key, value);
         preferencesEditor.Commit();
      }

      private bool ReadBoolSharedPreferencies(string key)
      {
         ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
         return preferences.GetBoolean(key, false);
      }
   }
}