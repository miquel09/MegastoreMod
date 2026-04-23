using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Rendering;
using InternalProductType = MegastoreSimulator.GameLibs.Models.Enums.ProductType;

namespace MegastoreSimulator.GameLibs.Managers.StockManager;

public static class StockManager
{
    #region Instance
    private static global::StockManager _instance;

    internal static global::StockManager Instance
    {
        private get
        {
            if (_instance == null)
                throw new InvalidOperationException("StockManager is not yet initialised");
            return _instance;
        }
        set
        {
            _instance ??= value;
        }
    }
    #endregion

    public static IReadOnlyDictionary<InternalProductType, int> AvailableStock => GetCount(Instance.availableStockDictionary);
    public static IReadOnlyDictionary<InternalProductType, int> BoxStock => GetCount(Instance.boxStockDictionary);
    public static IReadOnlyDictionary<InternalProductType, int> Stock => GetCount(Instance.stockDictionary);

    public static IReadOnlyList<InternalProductType> OutOfStockProducts => [.. Instance.outOfStockProducts.Select(x => (InternalProductType)(int)x)];
    public static IReadOnlyList<InternalProductType> PurchasableProducts => [.. Instance.purchasableProducts.Select(x => (InternalProductType)(int)x)];


    public static int GetProductCount()
    {
        return Instance.GetProductCount();
    }

    public static int GetAvailableStockOnShelves(InternalProductType productType)
    {
        return Instance.GetAvailableStockOnShelves((ProductType)(int)productType);
    }

    public static int GetAvailableStockInBoxes(InternalProductType productType)
    {
        return Instance.GetAvailableStockInBoxes((ProductType)(int)productType);
    }

    public static bool IsProductOutStock(InternalProductType productType)
    {
        return Instance.IsProductOutStock((ProductType)(int)productType);
    }

    private static IReadOnlyDictionary<InternalProductType, int> GetCount(SerializedDictionary<global::ProductType, int> source)
    {
        var dictionary = new Dictionary<InternalProductType, int>();

        foreach (var kvp in source)
        {
            dictionary[(InternalProductType)(int)kvp.Key] = kvp.Value;
        }

        return dictionary;
    }
}
