using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanzar.Welkin.Core.Repositories
{
    public interface IDataRepository
    {
        void UpsertDocument(string document);

        Task DeleteDocsAsync(string collName);

    }
}
