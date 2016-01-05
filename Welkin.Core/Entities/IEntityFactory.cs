using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanzar.Welkin.Core.Entities
{
    public interface IEntityFactory
    {
        IEventEntity CreateEntity(string type);
    }
}
