using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace OrdiOwin.Core.Settings
{
    public class ExtendedDefaultAssembliesResolver : DefaultAssembliesResolver    {        public override ICollection<Assembly> GetAssemblies()        {            LoadedAssembliesSettings settings = LoadedAssembliesSettings.GetSection();            if (null != settings)            {                foreach (AssemblyElement element in settings.AssemblyNames)                {                    AssemblyName assemblyName = AssemblyName.GetAssemblyName(element.AssemblyName);                    if (!AppDomain.CurrentDomain.GetAssemblies().Any(assembly => AssemblyName.ReferenceMatchesDefinition(assembly.GetName(), assemblyName)))                    {                        AppDomain.CurrentDomain.Load(assemblyName);                    }                }            }            return base.GetAssemblies();        }    }
}
