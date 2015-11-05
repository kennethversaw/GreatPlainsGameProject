using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityResolver.cs
{
    public static class UnityCache
    {
        private static IUnityContainer _defaultContainer = null;
        private static IUnityContainer _currentContainer = null;
        private static Dictionary<string, IUnityContainer> _containers = new Dictionary<string, IUnityContainer>();

        public static IUnityContainer DefaultContainer
        {
            get
            {
                if (_defaultContainer == null)
                {
                    // only load the container once so we can cache types as they are resolved
                    _defaultContainer = new UnityContainer();
                    var section = GetUnitySection();
                    _defaultContainer.LoadConfiguration(section);
                }

                return _defaultContainer;
            }
        }

        public static IUnityContainer CurrentContainer
        {
            get
            {
                if (_currentContainer == null)
                {
                    return DefaultContainer;
                }
                else
                {
                    return _currentContainer;
                }
            }
            set
            {
                _currentContainer = value;
            }
        }

        public static IUnityContainer Container(string containerName)
        {
            IUnityContainer container;
            _containers.TryGetValue(containerName, out container);

            if (container == null)
            {
                var section = GetUnitySection();
                if (string.IsNullOrEmpty(containerName) || containerName == "Parent")
                {
                    // Create the parent container as a normal container
                    container = new UnityContainer();
                }
                else
                {
                    // Otherwise create all named containers as a child of the parent container
                    if (section.Containers["Parent"] != null)
                    {
                        IUnityContainer parentContainer = Container("Parent");
                        container = parentContainer.CreateChildContainer();
                    }
                    else
                    {
                        // There is no parent container. Create this as a normal container
                        container = new UnityContainer();
                    }
                }
                // load container and add to dictionary 
                container.LoadConfiguration(section, containerName);
                _containers[containerName] = container;
            }

            return container;
        }

        private static UnityConfigurationSection GetUnitySection()
        {
            var configSection = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (configSection == null)
            {
                throw new ConfigurationErrorsException("Unable to load unity config section");
            }
            return configSection;
        }

        public static void SetCurrentContainer(string containerName)
        {
            CurrentContainer = Container(containerName);
        }

        public static T Resolve<T>()
        {
            return CurrentContainer.Resolve<T>();
        }

        public static T Resolve<T>(string interfaceName)
        {
            return CurrentContainer.Resolve<T>(interfaceName);
        }

        public static T ResolveDefault<T>(ParameterOverride parameterOverride)
        {
            return DefaultContainer.Resolve<T>(parameterOverride);
        }

        public static T ResolveDefault<T>()
        {
            return DefaultContainer.Resolve<T>();
        }

        public static T ResolveDefault<T>(string interfaceName)
        {
            return DefaultContainer.Resolve<T>(interfaceName);
        }
        public static T ResolveWithContainer<T>(string containerName)
        {
            return Container(containerName).Resolve<T>();
        }

        public static T ResolveWithContainer<T>(string containerName, string interfaceName)
        {
            return Container(containerName).Resolve<T>(interfaceName);
        }

        public static void RegisterInstance<T>(T instance)
        {
            CurrentContainer.RegisterInstance<T>(instance);
        }

        public static void RegisterInstance<T>(string interfaceName, T instance)
        {
            CurrentContainer.RegisterInstance<T>(interfaceName, instance);
        }

        public static void RegisterInstanceDefault<T>(T instance)
        {
            DefaultContainer.RegisterInstance<T>(instance);
        }

        public static void RegisterInstanceDefault<T>(string interfaceName, T instance)
        {
            DefaultContainer.RegisterInstance<T>(interfaceName, instance);
        }

        public static void RegisterInstanceWithContainer<T>(string containerName, T instance)
        {
            Container(containerName).RegisterInstance<T>(instance);
        }

        public static void RegisterInstanceWithContainer<T>(string containerName, string interfaceName, T instance)
        {
            Container(containerName).RegisterInstance<T>(interfaceName, instance);
        }
    }
}
