using AutoMapper;
using Serilog;
using System;
using System.Linq;
using System.Reflection;

namespace Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            CreateMap<Guid, Guid?>().ConvertUsing(guid => guid == Guid.Empty ? (Guid?)null : guid);
            CreateMap<string, Guid>().ConvertUsing(s => Guid.Parse(s));
            CreateMap<string, Guid?>().ConvertUsing(s => String.IsNullOrWhiteSpace(s) ? (Guid?)null : Guid.Parse(s));
            CreateMap<Guid, string>().ConvertUsing(g => g.ToString("N"));
            ApplyMappingsFromAssembly(assembly);
        }


        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                Log.Warning(type.Name);
                methodInfo?.Invoke(instance, new object[] { this });
                Log.Warning(type.Name);
            }
        }
    }
}
