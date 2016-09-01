namespace LoginMultiPlatform.Core.Data
{
   public class User
   {
      public string Email { get; private set; }

      public User(string email)
      {
         Email = email;
      }      
   }
}
