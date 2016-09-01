using UIKit;

namespace LoginMultiPlatform.iOS.ViewControlers
{
   public partial class LogoutViewController : UIViewController
   {
      public LogoutViewController() : base("LogoutViewController", null)
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();
         EmailLabel.Text = $"You are loged with email {ApplicationSessionContext.Instance.User.Email}";
         LogoutButton.TouchUpInside += async (sender, args) =>
         {
            await ApplicationSessionContext.Instance.LogOutAsync();
         };
      }
   }
}