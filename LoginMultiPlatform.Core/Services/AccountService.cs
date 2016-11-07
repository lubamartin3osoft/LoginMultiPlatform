using System;
using LoginMultiPlatform.Core.Utilities;

namespace LoginMultiPlatform.Core.Services
{
   public class AccountService
   {
      private readonly string _email;      

      public AccountService(string email)
      {
         _email = email;
      }

      public void Login(Action invalidEmailAction, Action sucessAction)
      {
         if (EmailValidator.ValidateEmail(_email))
         {
            sucessAction.Invoke();
         }
         else
         {
            invalidEmailAction.Invoke();
         }
      }
   }
}
