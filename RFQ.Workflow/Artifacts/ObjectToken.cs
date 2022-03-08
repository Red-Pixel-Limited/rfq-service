namespace RFQ.Workflow.Artifacts
{
    using System;
    using System.Text;

    public sealed class ObjectToken : IEquatable<ObjectToken>
    {
        private readonly string _value;

        public static bool operator ==(ObjectToken left, ObjectToken right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObjectToken left, ObjectToken right)
        {
            return !Equals(left, right);
        }

        public ObjectToken(params string[] fields)
        {
            var sb = new StringBuilder();
            for (var index = 0; index < fields.Length; index++)
            {
                var field = fields[index];
                sb.Append((index + 1) == fields.Length ? field : field + "-");
            }
            _value = sb.ToString();
        }

        public bool Equals(ObjectToken other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || string.Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ObjectToken && Equals((ObjectToken)obj);
        }

        public override int GetHashCode()
        {
            return (_value != null ? _value.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
