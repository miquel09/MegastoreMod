using MegastoreSimulator.GameLibs.Models.Enums;
using System.Collections.Generic;

namespace SalesNumbersPlugin.Managers;

public static class SalesNumbersManager
{
    public static Dictionary<ProductType, int> SalesNumbers { get; private set; } = new Dictionary<ProductType, int>();

    public static void UpdateSalesNumbers(ProductType productType, int quantity)
    {
        if (SalesNumbers.ContainsKey(productType))
        {
            SalesNumbers[productType] += quantity;
        }
        else
        {
            SalesNumbers[productType] = quantity;
        }
    }
}
