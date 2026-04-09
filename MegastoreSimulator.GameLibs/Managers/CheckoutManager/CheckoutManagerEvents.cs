using System;
using InternalCheckoutManager = MegastoreSimulator.GameLibs.Managers.CheckoutManager.CheckoutManager;
using InternalProduct = MegastoreSimulator.GameLibs.Models.Product;
using InternalCustomer = MegastoreSimulator.GameLibs.Models.Customer;
using System.Collections.Generic;

namespace MegastoreSimulator.GameLibs.Managers.CheckoutManager;

public static class CheckoutManagerEvents
{
    #region Payment
    public static event Action<InternalCheckoutManager, float> OnPaymentFinished;
    internal static void FireOnPaymentFinished(InternalCheckoutManager self, float amount) => OnPaymentFinished?.Invoke(self, amount);

    public static event Action<InternalCheckoutManager> OnPaymentTaken;
    internal static void FireOnPaymentTaken(InternalCheckoutManager self) => OnPaymentTaken?.Invoke(self);

    public static event Action<InternalCheckoutManager> OnCashPaymentTaken;
    internal static void FireOnCashPaymentTaken(InternalCheckoutManager self) => OnCashPaymentTaken?.Invoke(self);

    public static event Action<InternalCheckoutManager> OnCardPaymentTaken;
    internal static void FireOnCardPaymentTaken(InternalCheckoutManager self) => OnCardPaymentTaken?.Invoke(self);
    #endregion

    #region Products and Scanning
    public static event Action<InternalCheckoutManager, InternalProduct> OnProductScanned;
    internal static void FireOnProductScanned(InternalCheckoutManager self, InternalProduct product) => OnProductScanned?.Invoke(self, product);

    public static event Action<InternalCheckoutManager, List<InternalProduct>> OnProductsPlaced;
    internal static void FireOnPlaceProducts(InternalCheckoutManager self, List<InternalProduct> products) => OnProductsPlaced?.Invoke(self, products);
    
    public static event Action<InternalCheckoutManager, List<InternalProduct>, float> OnMovedToBag;
    internal static void FireOnMovedToBag(InternalCheckoutManager self, List<InternalProduct> products, float speedMultiplier) => OnMovedToBag?.Invoke(self, products, speedMultiplier);
    #endregion

    #region Queue and Customer
    public static event Action<InternalCheckoutManager, InternalCustomer> OnCustomerJoinedQueue;
    internal static void FireOnCustomerJoinedQueue(InternalCheckoutManager self, InternalCustomer customer) => OnCustomerJoinedQueue?.Invoke(self, customer);

    public static event Action<InternalCheckoutManager> OnCustomerLeftQueue;
    internal static void FireOnCustomerLeftQueue(InternalCheckoutManager self) => OnCustomerLeftQueue?.Invoke(self);
    #endregion

    #region Checkout State
    public static event Action<InternalCheckoutManager, bool> OnCheckoutStatusChanged;
    internal static void FireOnCheckoutStatusChanged(InternalCheckoutManager self, bool isClosed) => OnCheckoutStatusChanged?.Invoke(self, isClosed);
    #endregion
}