using InternalEnums = MegastoreSimulator.GameLibs.Models.Enums;

namespace MegastoreSimulator.GameLibs.Models;

public class Product
{
    public InternalEnums.ProductType ProductType { get; internal set;  }
    public string Brand { get; internal set; }

    internal Product(global::Product product)
    {
        Brand = product.data.brand;
        ProductType = (InternalEnums.ProductType)(int)product.data.type;
    }
}
