using System;
using InternalProductType = MegastoreSimulator.GameLibs.Models.Enums.ProductType;

namespace MegastoreSimulator.GameLibs.Managers.StockManager;

public static class StockManager
{
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
}
