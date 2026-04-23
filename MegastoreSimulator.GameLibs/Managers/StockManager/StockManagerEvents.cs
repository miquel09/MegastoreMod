using System;
using InternalShelf = MegastoreSimulator.GameLibs.Models.Shelf;
using InternalProductType = MegastoreSimulator.GameLibs.Models.Enums.ProductType;
using InternalProductGroup = MegastoreSimulator.GameLibs.Models.Enums.ProductGroup;

namespace MegastoreSimulator.GameLibs.Managers.StockManager;

public class StockManagerEvents
{
    public static event Action<InternalShelf, InternalProductType> OnProductAddedToShelf;
    internal static void FireOnProductAddedToShelf(InternalShelf shelf, InternalProductType type)
        => OnProductAddedToShelf?.Invoke(shelf, type);

    public static event Action<int, InternalProductGroup> OnLicensePurchased;
    internal static void FireOnLicensePurchased(int newLicense, InternalProductGroup group)
        => OnLicensePurchased?.Invoke(newLicense, group);

    public static event Action<InternalProductType, int> OnProductAddedToBox;
    internal static void FireOnProductAddedToBox(InternalProductType type, int count)
        => OnProductAddedToBox?.Invoke(type, count);

    public static event Action<InternalShelf, InternalProductType> OnProductRemoved;
    internal static void FireOnProductRemoved(InternalShelf shelf, InternalProductType type)
        => OnProductRemoved?.Invoke(shelf, type);

    public static event Action<InternalProductType, float> OnProductPriceChanged;
    internal static void FireOnProductPriceChanged(InternalProductType type, float newPrice)
        => OnProductPriceChanged?.Invoke(type, newPrice);

}
