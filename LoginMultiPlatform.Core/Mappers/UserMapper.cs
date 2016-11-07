using LoginMultiPlatform.Core.Data;

namespace LoginMultiPlatform.Core.Mappers
{
   public class UserMapper
   {
      public static User FromDataToDomain(UserEntity userEntity)
      {
         return userEntity != null 
            ? new User(userEntity.Email)
            : null;
      }

      public static UserEntity FromDomainToData(User user)
      {
         return new UserEntity()
         {
            Email = user.Email
         };
      }
   }
}
