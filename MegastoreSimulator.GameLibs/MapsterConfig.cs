using Mapster;
using InternalEnums = MegastoreSimulator.GameLibs.Models.Enums;
using InternalModels = MegastoreSimulator.GameLibs.Models;

namespace MegastoreSimulator.GameLibs;

internal class MapsterConfig
{
    public static void Register()
    {
        TypeAdapterConfig<global::Product, InternalModels.Product>.NewConfig()
            .Map(dest => dest.Brand, src => src.Data.brand)
            .Map(dest => dest.ProductType, src => (InternalEnums.ProductType)(int)src.Data.type);
    }
}
