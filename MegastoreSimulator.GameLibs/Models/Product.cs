using InternalEnums = MegastoreSimulator.GameLibs.Models.Enums;

namespace MegastoreSimulator.GameLibs.Models;

public class Product
{
    public InternalEnums.ProductType ProductType { get; internal set;  }
    public string Brand { get; internal set; }
}
