using System;
using System.Text.RegularExpressions;

namespace LoginMultiPlatform.Core.Utilities
{
   public class EmailValidator
   {
      public static bool ValidateEmail(string email)
      {
         return Regex.IsMatch(email,
             @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
             RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
      }
   }
}
