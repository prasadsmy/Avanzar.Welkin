using Microsoft.Azure.WebJobs.Host;
using Microsoft.Practices.Unity;

namespace Avanzar.Welkin.Core
{
    class Activator : IJobActivator
    {
        private readonly IUnityContainer _container;

        public Activator(IUnityContainer container)
        {
            _container = container;
        }

        public T CreateInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
