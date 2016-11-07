using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace LoginMultiPlatform.Droid.Activities
{
   [Activity(Label = "LogoutActivity")]
   public class LogoutActivity : Activity
   {
      protected override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);
         SetContentView(Resource.Layout.LogoutActivity);
         TextView logoutTextView = FindViewById<TextView>(Resource.Id.emailTextView);
         logoutTextView.Text = $"Current loged user {ApplicationSessionContext.Instance.User.Email}";

         Button logooutButton = FindViewById<Button>(Resource.Id.logoutButton);
         logooutButton.Click += async (sender, args) =>
         {
            await ApplicationSessionContext.Instance.LogOutAsync();
         };
         // Create your application here
      }

      public static void Navigate(Activity activity)
      {
         Intent intent = new Intent(Application.Context, typeof(LogoutActivity));
         intent.AddFlags(ActivityFlags.SingleTop);
         intent.AddFlags(ActivityFlags.ClearTop);
         activity.StartActivity(intent);
      }
   }
}