using SoftUniDI_Framework.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniDI_Framework.Injectors
{
    public static class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
