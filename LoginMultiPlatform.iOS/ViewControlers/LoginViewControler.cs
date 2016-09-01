using System;
using LoginMultiPlatform.Core.Data;
using LoginMultiPlatform.Core.Utilities;
using UIKit;

namespace LoginMultiPlatform.iOS.ViewControlers
{
   public partial class LoginViewControler : UIViewController
   {
      public LoginViewControler() : base("LoginViewControler", null)
      {
      }

      public override void DidReceiveMemoryWarning()
      {
         base.DidReceiveMemoryWarning();

         // Release any cached data, images, etc that aren't in use.
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();
         LoginButton.TouchUpInside += async (sender, args) =>
         {
            string email = EmailTextField.Text;
            if (EmailValidator.ValidateEmail(email))
            {
               await ApplicationSessionContext.Instance.StoreUserAsync(new User(email));
               NavigationController.PushViewController(new LogoutViewController(), false);
            }
            else
            {
               //TODO zobrazit chybu
            }
            

         };
         // Perform any additional setup after loading the view, typically from a nib.
      }
   }
}