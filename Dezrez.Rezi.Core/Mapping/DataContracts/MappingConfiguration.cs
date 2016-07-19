using AutoMapper;

namespace Dezrez.Rezi.Core.Mapping.DataContracts
{
    public class MappingConfiguration
    {
        public static void Configure(IConfiguration configuration)
        {
            // Add Mapping files here
            configuration.AddProfile<BaseMapping>();
        }
    }
}