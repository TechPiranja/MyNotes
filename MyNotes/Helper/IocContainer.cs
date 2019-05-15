using Autofac;

namespace View.Helper
{    public class IocContainer
    {
        private IContainer _container;
        private static IocContainer _instance;
        private static readonly object IsLocked = new object();

        private IocContainer()
        {
        }

        /// <summary>
        /// Container with all instantiated objects.
        /// </summary>
        public IContainer Container
        {
            get => _container;
            set => _container = value;
        }

        public static IocContainer Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (IsLocked)
                    if (_instance == null)
                        _instance = new IocContainer();

                return _instance;
            }
        }
    }
}