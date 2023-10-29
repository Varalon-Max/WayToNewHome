using System;
using System.Collections.Generic;
using System.Reflection;

namespace _Project.Scripts
{
    public static class PredefinedAssembliesUtil
    {
        private enum AssemblyType
        {
            AssemblyCSharp,
            AssemblyCSharpEditor,
            AssemblyCSharpEditorFirstPass,
            AssemblyCSharpFirstPass,
        }

        private static AssemblyType? GetAssemblyType(string assemblyName)
        {
            return assemblyName switch
            {
                "Assembly-CSharp" => AssemblyType.AssemblyCSharp,
                "Assembly-CSharp-Editor" => AssemblyType.AssemblyCSharpEditor,
                "Assembly-CSharp-Editor-firstpass" => AssemblyType.AssemblyCSharpEditorFirstPass,
                "Assembly-CSharp-firstpass" => AssemblyType.AssemblyCSharpFirstPass,
                _ => null
            };
        }

        public static List<Type> GetTypes(Type interfaceType)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            
            Dictionary<AssemblyType, Type[]> assemblyTypes = new Dictionary<AssemblyType, Type[]>();
            List<Type> types = new List<Type>();
            for (var i = 0; i < assemblies.Length; i++)
            {
                AssemblyType? assemblyType = GetAssemblyType(assemblies[i].GetName().Name);
                if (assemblyType != null)
                {
                    assemblyTypes.Add(assemblyType.Value, assemblies[i].GetTypes());
                }
            }

            AddTypesFromAssembly(assemblyTypes[AssemblyType.AssemblyCSharp], interfaceType, types);
            if (assemblyTypes.TryGetValue(AssemblyType.AssemblyCSharpFirstPass, out var assembly))
            {
                AddTypesFromAssembly(assembly, interfaceType, types);
            }

            return types;
        }

        private static void AddTypesFromAssembly(Type[] assembly, Type interfaceType, ICollection<Type> types)
        {
            if (assembly == null)
            {
                return;
            }

            for (var i = 0; i < assembly.Length; i++)
            {
                Type type = assembly[i];
                if (type != interfaceType && interfaceType.IsAssignableFrom(type))
                {
                    types.Add(type);
                }
            }
        }
    }
}