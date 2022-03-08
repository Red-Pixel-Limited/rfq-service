namespace RFQ.Service.Settings.Altex
{
    using System.Configuration;

    [ConfigurationCollection(typeof(AltexSetting), AddItemName = "setting",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class AltexSettings : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AltexSetting();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AltexSetting)element).Name;
        }

        public AltexSetting this[int index]
        {
            get { return (AltexSetting)BaseGet(index); }
        }

        public AltexSetting this[object key]
        {
            get { return (AltexSetting)BaseGet(key); }
        }
    }
}
