namespace RFQ.Communication.DTOs
{
    using System;

    public sealed class ExtensionMessageDTO
    {
        public Object Extension { get; private set; }
        public String ExtensionType { get; private set; }

        public ExtensionMessageDTO(object extension, string extensionType)
        {
            ExtensionType = extensionType;
            Extension = extension;
        }
    }
}
