using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenerarGruia
{
    public partial class Order
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("sequence")]
        public string Sequence { get; set; }

        [JsonProperty("marketplaceOrderId")]
        public string MarketplaceOrderId { get; set; }

        [JsonProperty("marketplaceServicesEndpoint")]
        public string MarketplaceServicesEndpoint { get; set; }

        [JsonProperty("sellerOrderId")]
        public string SellerOrderId { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("affiliateId")]
        public string AffiliateId { get; set; }

        [JsonProperty("salesChannel")]
        public string SalesChannel { get; set; }

        [JsonProperty("merchantName")]
        public object MerchantName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDescription")]
        public string StatusDescription { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("creationDate")]
        public DateTimeOffset CreationDate { get; set; }

        [JsonProperty("lastChange")]
        public DateTimeOffset LastChange { get; set; }

        [JsonProperty("orderGroup")]
        public string OrderGroup { get; set; }

        [JsonProperty("totals")]
        public List<Total> Totals { get; set; }

        [JsonProperty("items")]
        public List<WelcomeItem> Items { get; set; }

        [JsonProperty("marketplaceItems")]
        public List<object> MarketplaceItems { get; set; }

        [JsonProperty("clientProfileData")]
        public ClientProfileData ClientProfileData { get; set; }

        [JsonProperty("giftRegistryData")]
        public object GiftRegistryData { get; set; }

        [JsonProperty("marketingData")]
        public object MarketingData { get; set; }

        [JsonProperty("ratesAndBenefitsData")]
        public RatesAndBenefitsData RatesAndBenefitsData { get; set; }

        [JsonProperty("shippingData")]
        public ShippingData ShippingData { get; set; }

        [JsonProperty("paymentData")]
        public PaymentData PaymentData { get; set; }

        [JsonProperty("packageAttachment")]
        public PackageAttachment PackageAttachment { get; set; }

        [JsonProperty("sellers")]
        public List<Seller> Sellers { get; set; }

        [JsonProperty("callCenterOperatorData")]
        public object CallCenterOperatorData { get; set; }

        [JsonProperty("followUpEmail")]
        public string FollowUpEmail { get; set; }

        [JsonProperty("lastMessage")]
        public object LastMessage { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("changesAttachment")]
        public object ChangesAttachment { get; set; }

        [JsonProperty("openTextField")]
        public object OpenTextField { get; set; }

        [JsonProperty("roundingError")]
        public long RoundingError { get; set; }

        [JsonProperty("orderFormId")]
        public string OrderFormId { get; set; }

        [JsonProperty("commercialConditionData")]
        public object CommercialConditionData { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonProperty("customData")]
        public object CustomData { get; set; }

        [JsonProperty("storePreferencesData")]
        public StorePreferencesData StorePreferencesData { get; set; }

        [JsonProperty("allowCancellation")]
        public bool AllowCancellation { get; set; }

        [JsonProperty("allowEdition")]
        public bool AllowEdition { get; set; }

        [JsonProperty("isCheckedIn")]
        public bool IsCheckedIn { get; set; }

        [JsonProperty("marketplace")]
        public Marketplace Marketplace { get; set; }
    }

    public partial class ClientProfileData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("documentType")]
        public string DocumentType { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("corporateName")]
        public object CorporateName { get; set; }

        [JsonProperty("tradeName")]
        public object TradeName { get; set; }

        [JsonProperty("corporateDocument")]
        public object CorporateDocument { get; set; }

        [JsonProperty("stateInscription")]
        public object StateInscription { get; set; }

        [JsonProperty("corporatePhone")]
        public object CorporatePhone { get; set; }

        [JsonProperty("isCorporate")]
        public bool IsCorporate { get; set; }

        [JsonProperty("userProfileId")]
        public string UserProfileId { get; set; }

        [JsonProperty("customerClass")]
        public object CustomerClass { get; set; }
    }

    public partial class WelcomeItem
    {
        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("ean")]
        public object Ean { get; set; }

        [JsonProperty("lockId")]
        public string LockId { get; set; }

        [JsonProperty("itemAttachment")]
        public ItemAttachment ItemAttachment { get; set; }

        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("refId")]
        public string RefId { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("listPrice")]
        public long ListPrice { get; set; }

        [JsonProperty("manualPrice")]
        public object ManualPrice { get; set; }

        [JsonProperty("priceTags")]
        public List<PriceTag> PriceTags { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("detailUrl")]
        public string DetailUrl { get; set; }

        [JsonProperty("components")]
        public List<object> Components { get; set; }

        [JsonProperty("bundleItems")]
        public List<BundleItem> BundleItems { get; set; }

        [JsonProperty("params")]
        public List<object> Params { get; set; }

        [JsonProperty("offerings")]
        public List<object> Offerings { get; set; }

        [JsonProperty("sellerSku")]
        public string SellerSku { get; set; }

        [JsonProperty("priceValidUntil")]
        public object PriceValidUntil { get; set; }

        [JsonProperty("commission")]
        public long Commission { get; set; }

        [JsonProperty("tax")]
        public long Tax { get; set; }

        [JsonProperty("preSaleDate")]
        public object PreSaleDate { get; set; }

        [JsonProperty("additionalInfo")]
        public AdditionalInfo AdditionalInfo { get; set; }

        [JsonProperty("measurementUnit")]
        public string MeasurementUnit { get; set; }

        [JsonProperty("unitMultiplier")]
        public long UnitMultiplier { get; set; }

        [JsonProperty("sellingPrice")]
        public long SellingPrice { get; set; }

        [JsonProperty("isGift")]
        public bool IsGift { get; set; }

        [JsonProperty("shippingPrice")]
        public object ShippingPrice { get; set; }

        [JsonProperty("rewardValue")]
        public long RewardValue { get; set; }

        [JsonProperty("freightCommission")]
        public long FreightCommission { get; set; }
    }

    public partial class AdditionalInfo
    {
        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        [JsonProperty("brandId")]
        public string BrandId { get; set; }

        [JsonProperty("categoriesIds")]
        public string CategoriesIds { get; set; }

        [JsonProperty("productClusterId")]
        public string ProductClusterId { get; set; }

        [JsonProperty("commercialConditionId")]
        public string CommercialConditionId { get; set; }

        [JsonProperty("dimension")]
        public Dimension Dimension { get; set; }

        [JsonProperty("offeringInfo")]
        public object OfferingInfo { get; set; }

        [JsonProperty("offeringType")]
        public string OfferingType { get; set; }

        [JsonProperty("offeringTypeId")]
        public string OfferingTypeId { get; set; }
    }

    public partial class Dimension
    {
        [JsonProperty("cubicweight")]
        public double Cubicweight { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class BundleItem
    {
        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("productId")]
        public object ProductId { get; set; }

        [JsonProperty("ean")]
        public object Ean { get; set; }

        [JsonProperty("lockId")]
        public object LockId { get; set; }

        [JsonProperty("itemAttachment")]
        public Attachment ItemAttachment { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("seller")]
        public object Seller { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("refId")]
        public object RefId { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("listPrice")]
        public object ListPrice { get; set; }

        [JsonProperty("manualPrice")]
        public object ManualPrice { get; set; }

        [JsonProperty("priceTags")]
        public List<object> PriceTags { get; set; }

        [JsonProperty("imageUrl")]
        public object ImageUrl { get; set; }

        [JsonProperty("detailUrl")]
        public object DetailUrl { get; set; }

        [JsonProperty("components")]
        public List<object> Components { get; set; }

        [JsonProperty("bundleItems")]
        public List<object> BundleItems { get; set; }

        [JsonProperty("params")]
        public List<object> Params { get; set; }

        [JsonProperty("offerings")]
        public List<object> Offerings { get; set; }

        [JsonProperty("sellerSku")]
        public string SellerSku { get; set; }

        [JsonProperty("priceValidUntil")]
        public object PriceValidUntil { get; set; }

        [JsonProperty("commission")]
        public long Commission { get; set; }

        [JsonProperty("tax")]
        public long Tax { get; set; }

        [JsonProperty("preSaleDate")]
        public object PreSaleDate { get; set; }

        [JsonProperty("additionalInfo")]
        public AdditionalInfo AdditionalInfo { get; set; }

        [JsonProperty("measurementUnit")]
        public object MeasurementUnit { get; set; }

        [JsonProperty("unitMultiplier")]
        public long UnitMultiplier { get; set; }

        [JsonProperty("sellingPrice")]
        public long SellingPrice { get; set; }

        [JsonProperty("isGift")]
        public bool IsGift { get; set; }

        [JsonProperty("shippingPrice")]
        public object ShippingPrice { get; set; }

        [JsonProperty("rewardValue")]
        public long RewardValue { get; set; }

        [JsonProperty("freightCommission")]
        public long FreightCommission { get; set; }
    }

    public partial class Attachment
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
    }

    public partial class ItemAttachment
    {
        [JsonProperty("content")]
        public Con Content { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }
    }

    public partial class Con
    {
    }

    public partial class PriceTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("isPercentual")]
        public bool IsPercentual { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("rawValue")]
        public long RawValue { get; set; }
    }

    public partial class Marketplace
    {
        [JsonProperty("baseURL")]
        public string BaseUrl { get; set; }

        [JsonProperty("isCertified")]
        public object IsCertified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class PackageAttachment
    {
        [JsonProperty("packages")]
        public List<Package> Packages { get; set; }
    }

    public partial class Package
    {
        [JsonProperty("items")]
        public List<PackageItem> Items { get; set; }

        [JsonProperty("courier")]
        public string Courier { get; set; }

        [JsonProperty("invoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("invoiceValue")]
        public long InvoiceValue { get; set; }

        [JsonProperty("invoiceUrl")]
        public object InvoiceUrl { get; set; }

        [JsonProperty("issuanceDate")]
        public DateTimeOffset IssuanceDate { get; set; }

        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("invoiceKey")]
        public object InvoiceKey { get; set; }

        [JsonProperty("trackingUrl")]
        public string TrackingUrl { get; set; }

        [JsonProperty("embeddedInvoice")]
        public string EmbeddedInvoice { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("courierStatus")]
        public CourierStatus CourierStatus { get; set; }
    }

    public partial class CourierStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("finished")]
        public bool Finished { get; set; }

        [JsonProperty("data")]
        public List<object> Data { get; set; }
    }

    public partial class PackageItem
    {
        [JsonProperty("itemIndex")]
        public long ItemIndex { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }
    }

    public partial class PaymentData
    {
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }
    }

    public partial class Transaction
    {
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("merchantName")]
        public string MerchantName { get; set; }

        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }
    }

    public partial class Payment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("paymentSystem")]
        public string PaymentSystem { get; set; }

        [JsonProperty("paymentSystemName")]
        public string PaymentSystemName { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("installments")]
        public long Installments { get; set; }

        [JsonProperty("referenceValue")]
        public long ReferenceValue { get; set; }

        [JsonProperty("cardHolder")]
        public object CardHolder { get; set; }

        [JsonProperty("cardNumber")]
        public object CardNumber { get; set; }

        [JsonProperty("firstDigits")]
        public object FirstDigits { get; set; }

        [JsonProperty("lastDigits")]
        public object LastDigits { get; set; }

        [JsonProperty("cvv2")]
        public object Cvv2 { get; set; }

        [JsonProperty("expireMonth")]
        public object ExpireMonth { get; set; }

        [JsonProperty("expireYear")]
        public object ExpireYear { get; set; }

        [JsonProperty("url")]
        public object Url { get; set; }

        [JsonProperty("giftCardId")]
        public object GiftCardId { get; set; }

        [JsonProperty("giftCardName")]
        public object GiftCardName { get; set; }

        [JsonProperty("giftCardCaption")]
        public object GiftCardCaption { get; set; }

        [JsonProperty("redemptionCode")]
        public object RedemptionCode { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("tid")]
        public object Tid { get; set; }

        [JsonProperty("dueDate")]
        public object DueDate { get; set; }

        [JsonProperty("connectorResponses")]
        public Con ConnectorResponses { get; set; }
    }

    public partial class RatesAndBenefitsData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rateAndBenefitsIdentifiers")]
        public List<RateAndBenefitsIdentifier> RateAndBenefitsIdentifiers { get; set; }
    }

    public partial class RateAndBenefitsIdentifier
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("matchedParameters")]
        public MatchedParameters MatchedParameters { get; set; }
    }

    public partial class MatchedParameters
    {
        [JsonProperty("Seller@CatalogSystem")]
        public string SellerCatalogSystem { get; set; }

        [JsonProperty("slaIds")]
        public string SlaIds { get; set; }
    }

    public partial class Seller
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }

    public partial class ShippingData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("logisticsInfo")]
        public List<LogisticsInfo> LogisticsInfo { get; set; }

        [JsonProperty("trackingHints")]
        public object TrackingHints { get; set; }

        [JsonProperty("selectedAddresses")]
        public List<Address> SelectedAddresses { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("addressType")]
        public string AddressType { get; set; }

        [JsonProperty("receiverName")]
        public string ReceiverName { get; set; }

        [JsonProperty("addressId")]
        public string AddressId { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("number")]
        public object Number { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("complement")]
        public string Complement { get; set; }

        [JsonProperty("reference")]
        public object Reference { get; set; }

        [JsonProperty("geoCoordinates")]
        public List<object> GeoCoordinates { get; set; }
    }

    public partial class LogisticsInfo
    {
        [JsonProperty("itemIndex")]
        public long ItemIndex { get; set; }

        [JsonProperty("selectedSla")]
        public string SelectedSla { get; set; }

        [JsonProperty("lockTTL")]
        public string LockTtl { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("listPrice")]
        public long ListPrice { get; set; }

        [JsonProperty("sellingPrice")]
        public long SellingPrice { get; set; }

        [JsonProperty("deliveryWindow")]
        public object DeliveryWindow { get; set; }

        [JsonProperty("deliveryCompany")]
        public string DeliveryCompany { get; set; }

        [JsonProperty("shippingEstimate")]
        public string ShippingEstimate { get; set; }

        [JsonProperty("shippingEstimateDate")]
        public DateTimeOffset ShippingEstimateDate { get; set; }

        [JsonProperty("slas")]
        public List<Sla> Slas { get; set; }

        [JsonProperty("shipsTo")]
        public List<string> ShipsTo { get; set; }

        [JsonProperty("deliveryIds")]
        public List<DeliveryId> DeliveryIds { get; set; }

        [JsonProperty("deliveryChannel")]
        public string DeliveryChannel { get; set; }

        [JsonProperty("pickupStoreInfo")]
        public PickupStoreInfo PickupStoreInfo { get; set; }

        [JsonProperty("addressId")]
        public string AddressId { get; set; }
    }

    public partial class DeliveryId
    {
        [JsonProperty("courierId")]
        public string CourierId { get; set; }

        [JsonProperty("courierName")]
        public string CourierName { get; set; }

        [JsonProperty("dockId")]
        public string DockId { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("warehouseId")]
        public string WarehouseId { get; set; }
    }

    public partial class PickupStoreInfo
    {
        [JsonProperty("additionalInfo")]
        public object AdditionalInfo { get; set; }

        [JsonProperty("address")]
        public object Address { get; set; }

        [JsonProperty("dockId")]
        public object DockId { get; set; }

        [JsonProperty("friendlyName")]
        public object FriendlyName { get; set; }

        [JsonProperty("isPickupStore")]
        public bool IsPickupStore { get; set; }
    }

    public partial class Sla
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shippingEstimate")]
        public string ShippingEstimate { get; set; }

        [JsonProperty("deliveryWindow")]
        public object DeliveryWindow { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("deliveryChannel")]
        public string DeliveryChannel { get; set; }

        [JsonProperty("pickupStoreInfo")]
        public PickupStoreInfo PickupStoreInfo { get; set; }
    }

    public partial class StorePreferencesData
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currencyFormatInfo")]
        public CurrencyFormatInfo CurrencyFormatInfo { get; set; }

        [JsonProperty("currencyLocale")]
        public long CurrencyLocale { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }

    public partial class CurrencyFormatInfo
    {
        [JsonProperty("CurrencyDecimalDigits")]
        public long CurrencyDecimalDigits { get; set; }

        [JsonProperty("CurrencyDecimalSeparator")]
        public string CurrencyDecimalSeparator { get; set; }

        [JsonProperty("CurrencyGroupSeparator")]
        public string CurrencyGroupSeparator { get; set; }

        [JsonProperty("CurrencyGroupSize")]
        public long CurrencyGroupSize { get; set; }

        [JsonProperty("StartsWithCurrencySymbol")]
        public bool StartsWithCurrencySymbol { get; set; }
    }

    public partial class Total
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }

}