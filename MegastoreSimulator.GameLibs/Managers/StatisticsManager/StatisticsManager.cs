using System;
using System.Collections.Generic;
using InternalProductType = MegastoreSimulator.GameLibs.Models.Enums.ProductType;

namespace MegastoreSimulator.GameLibs.Managers.StatisticsManager;

public class StatisticsManager
{
    #region Instance
    private static global::StatisticsManager _instance;

    internal static global::StatisticsManager Instance
    {
        private get
        {
            if (_instance == null)
                throw new InvalidOperationException("StatisticsManager is not yet initialised");
            return _instance;
        }
        set
        {
            _instance ??= value;
        }
    }
    #endregion

    public IReadOnlyDictionary<InternalProductType, int> SoldItems => GetCount(Instance.soldItemsDictionary);

    private static IReadOnlyDictionary<InternalProductType, int> GetCount(Dictionary<global::ProductType, int> source)
    {
        var dictionary = new Dictionary<InternalProductType, int>();

        foreach (var kvp in source)
        {
            dictionary[(InternalProductType)(int)kvp.Key] = kvp.Value;
        }

        return dictionary;
    }
}
