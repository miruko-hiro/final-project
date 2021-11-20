using System.Collections.Generic;
using Zenject;

namespace FinalProject.Architecture.Helpers.Scripts
{
    public class InjectionClassFactory
    {
        private DiContainer _container;

        [Inject]
        public InjectionClassFactory(DiContainer container)
        {
            _container = container;
        }

        public T Create<T>()
        {
            return _container.Instantiate<T>();
        }

        public T CreateWithParameters<T>(IEnumerable<object> parameters)
        {
            return _container.Instantiate<T>(parameters);
        }
    }
}