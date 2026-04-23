using System;
using InternalCheckoutManager = MegastoreSimulator.GameLibs.Managers.CheckoutManager.CheckoutManager;
using InternalProduct = MegastoreSimulator.GameLibs.Models.Product;
using InternalCustomer = MegastoreSimulator.GameLibs.Models.Customer;
using System.Collections.Generic;

namespace MegastoreSimulator.GameLibs.Managers.CheckoutManager;

public static class CheckoutManagerEvents
{
    #region Payment
    /// <summary>Fired when a payment operation is completed. Subscribers receive the checkout manager instance and the payment amount.</summary>
    public static event Action<InternalCheckoutManager, float> OnPaymentFinished;
    internal static void FireOnPaymentFinished(InternalCheckoutManager self, float amount) => OnPaymentFinished?.Invoke(self, amount);

    /// <summary>Fired when payment is taken from the customer. Subscribers receive the checkout manager instance.</summary>
    public static event Action<InternalCheckoutManager> OnPaymentTaken;
    internal static void FireOnPaymentTaken(InternalCheckoutManager self) => OnPaymentTaken?.Invoke(self);

    /// <summary>Fired when cash payment is taken from the customer. Subscribers receive the checkout manager instance.</summary>
    public static event Action<InternalCheckoutManager> OnCashPaymentTaken;
    internal static void FireOnCashPaymentTaken(InternalCheckoutManager self) => OnCashPaymentTaken?.Invoke(self);

    /// <summary>Fired when card payment is taken from the customer. Subscribers receive the checkout manager instance.</summary>
    public static event Action<InternalCheckoutManager> OnCardPaymentTaken;
    internal static void FireOnCardPaymentTaken(InternalCheckoutManager self) => OnCardPaymentTaken?.Invoke(self);
    #endregion

    #region Products and Scanning
    /// <summary>Fired when a product is scanned at the checkout. Subscribers receive the checkout manager instance and the scanned product.</summary>
    public static event Action<InternalCheckoutManager, InternalProduct> OnProductScanned;
    internal static void FireOnProductScanned(InternalCheckoutManager self, InternalProduct product) => OnProductScanned?.Invoke(self, product);

    /// <summary>Fired when products are placed on the checkout counter. Subscribers receive the checkout manager instance and the list of placed products.</summary>
    public static event Action<InternalCheckoutManager, IReadOnlyList<InternalProduct>> OnProductsPlaced;
    internal static void FireOnPlaceProducts(InternalCheckoutManager self, IReadOnlyList<InternalProduct> products) => OnProductsPlaced?.Invoke(self, products);
    
    /// <summary>Fired when scanned products are moved to the customer's bag. Subscribers receive the checkout manager instance, the list of products being bagged, and a speed multiplier for animation.</summary>
    public static event Action<InternalCheckoutManager, IReadOnlyList<InternalProduct>> OnMovedToBag;
    internal static void FireOnMovedToBag(InternalCheckoutManager self, IReadOnlyList<InternalProduct> products) => OnMovedToBag?.Invoke(self, products);
    #endregion

    #region Queue and Customer
    /// <summary>Fired when a customer joins the checkout queue. Subscribers receive the checkout manager instance and the customer that joined.</summary>
    public static event Action<InternalCheckoutManager, InternalCustomer> OnCustomerJoinedQueue;
    internal static void FireOnCustomerJoinedQueue(InternalCheckoutManager self, InternalCustomer customer) => OnCustomerJoinedQueue?.Invoke(self, customer);

    /// <summary>Fired when a customer leaves the checkout queue. Subscribers receive the checkout manager instance.</summary>
    public static event Action<InternalCheckoutManager> OnCustomerLeftQueue;
    internal static void FireOnCustomerLeftQueue(InternalCheckoutManager self) => OnCustomerLeftQueue?.Invoke(self);
    #endregion

    #region Checkout State
    /// <summary>Fired when the checkout status changes. Subscribers receive the checkout manager instance.</summary>
    public static event Action<InternalCheckoutManager> OnCheckoutStatusChanged;
    internal static void FireOnCheckoutStatusChanged(InternalCheckoutManager self) => OnCheckoutStatusChanged?.Invoke(self);
    #endregion
}