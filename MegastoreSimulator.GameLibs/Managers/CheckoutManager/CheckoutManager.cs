using System.Collections.Generic;
using System.Linq;
using InternalProduct = MegastoreSimulator.GameLibs.Models.Product;
using InternalCustomer = MegastoreSimulator.GameLibs.Models.Customer;

namespace MegastoreSimulator.GameLibs.Managers.CheckoutManager;

public class CheckoutManager
{
    private readonly global::CheckoutManager _instance;

    public Queue<InternalCustomer> CustomersInQueue => new(_instance.customers.Select(c => new InternalCustomer(c)));

    public List<InternalProduct> ProductsScanned => [.. _instance.productsScanned.Select(p => new InternalProduct(p))];
    public List<InternalProduct> ProductsPlaced => [.. _instance.productsPlaced.Select(p => new InternalProduct(p))];

    public bool IsClosed => _instance.IsClosed();
    public bool HasCustomersInQueue => _instance.CustomersInQueue;

    internal CheckoutManager(global::CheckoutManager instance)
    {
        _instance = instance;
    }
}
