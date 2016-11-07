using System;
using System.IO;
using LoginMultiPlatform.Core.Abstracts;

namespace LoginMultiPlatform.Droid.Utilities
{
   public class DroidDatabaseEnviroment : IDatabaseEvironment
   {
      public string DatabasePath
      {
         get
         {
            string databasePath = Path.Combine(DatabaseDirrectory, "client.db");
            return databasePath;
         }
      }

      public string DatabaseDirrectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
      public bool ExistDatabase => File.Exists(DatabasePath);
      public void CreateDatabaseDirectoryIfNeccessary()
      {
         if (!ExistDatabase)
         {
            Directory.CreateDirectory(DatabaseDirrectory);
         }
      }
   }
}