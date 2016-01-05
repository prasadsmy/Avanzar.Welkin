using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanzar.Welkin.Core.Repositories
{
    class SettingsRepository :ISettingsRepository
    {

        private string DocumentDBUri = "https://hbotdocdb.documents.azure.com:443/";
  
        public string DocDBUri { get { return DocumentDBUri; } }


    }
}
