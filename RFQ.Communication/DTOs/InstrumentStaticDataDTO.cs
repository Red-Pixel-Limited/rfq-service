namespace RFQ.Communication.DTOs
{
    using System.Collections.Generic;
    using Options;

    public sealed class InstrumentStaticDataDTO
    {
        public string DisplayName { get; private set; }
        public string Currency { get; private set; }
        public Price PriceType { get; private set; }
        public PricePriority BidPricePriorityType { get; private set; }
        public PricePriority OfferPricePriorityType { get; private set; }
        public PriceFormat PriceFormat { get; private set; }
        public SizeMagnitude SizeMagnitude { get; private set; }
        public IList<ExtensionMessageDTO> ProductExtensions { get; private set; }
        public IList<ExtensionMessageDTO> VenueExtensions { get; private set; }

        public InstrumentStaticDataDTO(string displayName, 
                                       string currency, 
                                       Price priceType, 
                                       PricePriority bidPricePriorityType, 
                                       PricePriority offerPricePriorityType, 
                                       PriceFormat priceFormat, 
                                       SizeMagnitude sizeMagnitude, 
                                       IList<ExtensionMessageDTO> productExtensions = null, 
                                       IList<ExtensionMessageDTO> venueExtensions = null)
        {
            VenueExtensions = venueExtensions ?? new List<ExtensionMessageDTO>();
            ProductExtensions = productExtensions ?? new List<ExtensionMessageDTO>();
            SizeMagnitude = sizeMagnitude;
            PriceFormat = priceFormat;
            OfferPricePriorityType = offerPricePriorityType;
            BidPricePriorityType = bidPricePriorityType;
            PriceType = priceType;
            Currency = currency;
            DisplayName = displayName;
        }
    }
}
