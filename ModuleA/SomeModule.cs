using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    public class SomeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TabView>();
        }
        
    }
}