using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LoginMultiPlatform.Core.Abstracts;

namespace LoginMultiPlatform.iOS
{
   public class IosDatabaseEnvironment : IDatabaseEvironment
   {
      public string DatabasePath
      {
         get
         {
            string databasePath = Path.Combine(DatabaseDirrectory, "client.db");
            return databasePath;
         }
      }

      public string DatabaseDirrectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Db");

      public bool ExistDatabase => File.Exists(DatabasePath);

      public void CreateDatabaseDirectoryIfNeccessary()
      {
         if (!Directory.Exists(DatabaseDirrectory))
         {
            Directory.CreateDirectory(DatabaseDirrectory);
         }
      }
   }
}
