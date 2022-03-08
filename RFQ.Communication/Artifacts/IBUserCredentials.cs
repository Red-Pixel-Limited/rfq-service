namespace RFQ.Communication.Artifacts
{
    using System;

    public sealed class IBUserCredentials : IEquatable<IBUserCredentials>
    {
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        #region IEquatable<T> Members

        public static bool operator ==(IBUserCredentials left, IBUserCredentials right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IBUserCredentials left, IBUserCredentials right)
        {
            return !Equals(left, right);
        }

        public bool Equals(IBUserCredentials other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Username, other.Username) && string.Equals(CurrentPassword, other.CurrentPassword) && string.Equals(NewPassword, other.NewPassword);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is IBUserCredentials && Equals((IBUserCredentials)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Username != null ? Username.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CurrentPassword != null ? CurrentPassword.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NewPassword != null ? NewPassword.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}
