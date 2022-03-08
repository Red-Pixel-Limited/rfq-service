namespace RFQ.Communication.Artifacts
{
    using System;

    public sealed class IBFirmCredentials : IEquatable<IBFirmCredentials>
    {
        public string UserId { get; set; }
        public string FirmId { get; set; }

        #region IEquatable<T> Members

        public static bool operator ==(IBFirmCredentials left, IBFirmCredentials right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IBFirmCredentials left, IBFirmCredentials right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is IBFirmCredentials && Equals((IBFirmCredentials)obj);
        }

        public bool Equals(IBFirmCredentials other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(UserId, other.UserId) && string.Equals(FirmId, other.FirmId);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((UserId != null ? UserId.GetHashCode() : 0)*397) ^ (FirmId != null ? FirmId.GetHashCode() : 0);
            }
        }

        #endregion
    }
}
