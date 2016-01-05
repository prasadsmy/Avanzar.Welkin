using Microsoft.Practices.Unity;
using System;

namespace Avanzar.Welkin.Core.Entities
{
    public class EntityFactory : IEntityFactory
    {
        private IUnityContainer _unityContainer;

        public EntityFactory(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

       
        public IEventEntity CreateEntity(string type)
        {
            try
            {
                var _eventEntity = _unityContainer.Resolve<IEventEntity>(type);

                return _eventEntity;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}
