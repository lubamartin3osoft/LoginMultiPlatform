namespace LoginMultiPlatform.Core.Abstracts
{
   public interface IDatabaseEvironment
   {
      string DatabasePath { get; }
      string DatabaseDirrectory { get; }
      bool ExistDatabase { get; }
      void CreateDatabaseDirectoryIfNeccessary();
   }
}
