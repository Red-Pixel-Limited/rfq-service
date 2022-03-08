namespace RFQ.Altex.Specs.Mappings.Options
{
    using Altex.Mappings.Options;
    using Communication.Options;
    using FluentAssertions;
    using global::Altex.MessageLibrary;
    using Machine.Specifications;

    [Subject(typeof(SideMapper))]
    public class when_mapping_side_to_side_type
    {
        Establish context = () =>
        {
            mapper = new SideMapper();
            targets = new SideType[4];
        };

        Because of = () =>
        {
            targets[0] = mapper.Map(Side.Undefined);
            targets[1] = mapper.Map(Side.Buy);
            targets[2] = mapper.Map(Side.Sell);
            targets[3] = mapper.Map(Side.Both);
        };

        It should_map_to_matching_target_fields = () => targets.ShouldBeEquivalentTo(new[]
        {
            SideType.Undefined,
            SideType.Buy,
            SideType.Sell,
            SideType.Both
        });

        static SideMapper mapper;
        static SideType[] targets;
    }
}
