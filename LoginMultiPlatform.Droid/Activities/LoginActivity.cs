using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;
using LoginMultiPlatform.Core.Data;
using LoginMultiPlatform.Core.Services;

namespace LoginMultiPlatform.Droid.Activities
{
   [Activity(Label = "LoginActivity")]
   public class LoginActivity : Activity
   {
      protected override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);
         SetContentView(Resource.Layout.LoginLayout);
         EditText loginEditText = FindViewById<EditText>(Resource.Id.emailEditText);
         Button loginButton = FindViewById<Button>(Resource.Id.loginButton);

         loginButton.Click += (sender, args) =>
         {
            string email = loginEditText.Text;
            AccountService accountService = new AccountService(email);
            accountService.Login(
               () => //invalid email action
               {
                  AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                  alertDialog.SetMessage("Email is not valid");
                  alertDialog.Show();
               },
               async () => //success action
               {
                  await ApplicationSessionContext.Instance.StoreUserAsync(new User(email));
                  LogoutActivity.Navigate(this);
               });
         };

         loginEditText.EditorAction += (sender, args) =>
         {
            if (args.ActionId.Equals(ImeAction.Done))
            {
               InputMethodManager inputMethodService = (InputMethodManager) GetSystemService(InputMethodService);
               inputMethodService.HideSoftInputFromWindow(loginEditText.WindowToken, HideSoftInputFlags.None);
               loginButton.PerformClick();
            }
         };         
         // Create your application here
      }

      public static void Navigate()
      {
         Intent intent = new Intent(Application.Context, typeof(LoginActivity));
         intent.AddFlags(ActivityFlags.SingleTop);
         intent.AddFlags(ActivityFlags.ClearTop);
         intent.AddFlags(ActivityFlags.NewTask);

         Application.Context.StartActivity(intent);
      }
   }
}