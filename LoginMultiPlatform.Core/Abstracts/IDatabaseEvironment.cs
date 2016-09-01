using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
