namespace RFQ.Altex.Specs.Utils
{
    using Altex.Utils;
    using FluentAssertions;
    using Machine.Specifications;

    [Subject(typeof(AltexUtils))]
    public class when_encoding_string_for_sending
    {
        Because of = () => encoded = initial.EncodeToAltexEncoding();

        It should_substitute_altex_not_supported_characters = () => encoded.Should().Be(expected);

        const string initial = "encoding^string,test";
        const string expected = "ZW5jb2Rpbmdec3RyaW5nLHRlc3Q_e";
        
        static string encoded;
    }

    [Subject(typeof(AltexUtils))]
    public class when_decoding_string_from_altex_encoding
    {
        Because of = () => decoded = initial.DecodeFromAltexEncoding();

        It should_provide_expected_value = () => decoded.Should().Be(expected);

        const string initial = "ZGVjb2Rpbmdec3RyaW5nLHRlc3Q_e";
        const string expected = "decoding^string,test";

        static string decoded;
    }
}
