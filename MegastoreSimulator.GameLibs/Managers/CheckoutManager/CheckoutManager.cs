using Mapster;
using System.Collections.Generic;
using InternalProduct = MegastoreSimulator.GameLibs.Models.Product;

namespace MegastoreSimulator.GameLibs.Managers.CheckoutManager;

public class CheckoutManager
{
    private readonly global::CheckoutManager _instance;

    public List<InternalProduct> ProductsScanned => _instance.productsScanned.Adapt<List<InternalProduct>>();

    internal CheckoutManager(global::CheckoutManager instance)
    {
        _instance = instance;
    }

}
