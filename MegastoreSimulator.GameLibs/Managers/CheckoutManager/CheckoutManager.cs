using System.Collections.Generic;
using System.Linq;
using InternalProduct = MegastoreSimulator.GameLibs.Models.Product;

namespace MegastoreSimulator.GameLibs.Managers.CheckoutManager;

public class CheckoutManager
{
    private readonly global::CheckoutManager _instance;

    public List<InternalProduct> ProductsScanned => _instance.productsScanned.Select(p => new InternalProduct(p)).ToList();

    internal CheckoutManager(global::CheckoutManager instance)
    {
        _instance = instance;
    }

}
