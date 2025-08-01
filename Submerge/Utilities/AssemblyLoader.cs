using System.Reflection;

namespace Submerge.Utilities;

public class AssemblyLoader
{
    public static List<T> LoadTypesFromAssembly<T>(Assembly assembly)
    {
        var loadedTypes = new List<T>();
        
        foreach (var type in assembly.GetTypes())
        {
            // Check for validity
            if (type.FullName.Contains("System") || type.FullName.Contains("Mono"))
                continue;
            
            if (!type.IsSubclassOf(typeof(T)))
                continue;
            
            loadedTypes.Add((T)Activator.CreateInstance(type));
        }
        
        return loadedTypes;
    }
}