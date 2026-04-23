using System.Collections.Generic;
using System.Linq;
using InternalProduct = MegastoreSimulator.GameLibs.Models.Product;
using InternalCustomer = MegastoreSimulator.GameLibs.Models.Customer;

namespace MegastoreSimulator.GameLibs.Managers.CheckoutManager;

public sealed class CheckoutManager
{
    private readonly global::CheckoutManager _instance;

    public IReadOnlyList<InternalCustomer> CustomersInQueue => [.. _instance.customers.Select(c => new InternalCustomer(c))];
    public IReadOnlyList<InternalProduct> ProductsScanned => [.. _instance.productsScanned.Select(p => new InternalProduct(p))];
    public IReadOnlyList<InternalProduct> ProductsPlaced => [.. _instance.productsPlaced.Select(p => new InternalProduct(p))];

    public bool IsClosed => _instance.IsClosed();
    public bool HasCustomersInQueue => _instance.CustomersInQueue;

    internal CheckoutManager(global::CheckoutManager instance)
    {
        _instance = instance;
    }
}
