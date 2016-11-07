using SQLite.Net.Attributes;

namespace LoginMultiPlatform.Core.Data
{
   public class UserEntity
   {
      [PrimaryKey]
      public string Email { get; set; }      
   }
}
