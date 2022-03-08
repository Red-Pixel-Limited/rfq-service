namespace RFQ.Altex.Mappings
{
    interface IOptionsMapper<TOption1, TOption2> 
        where TOption1 : struct 
        where TOption2 : struct
    {
        TOption2 Map(TOption1 option);
        TOption1 Map(TOption2 option);
    }
}
