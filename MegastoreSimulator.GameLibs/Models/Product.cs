using InternalProductType = MegastoreSimulator.GameLibs.Models.Enums.ProductType;

namespace MegastoreSimulator.GameLibs.Models;

public class Product
{
    public InternalProductType ProductType { get; internal set;  }
    public string Brand { get; internal set; }

    internal Product(global::Product product)
    {
        Brand = product.data.brand;
        ProductType = (InternalProductType)(int)product.data.type;
    }
}
