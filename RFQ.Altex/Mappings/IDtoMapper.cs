namespace RFQ.Altex.Mappings
{
    interface IDtoMapper<TDto1, TDto2>
        where TDto1 : class 
        where TDto2 : class
    {
        TDto1 Map(TDto2 dto);
        TDto2 Map(TDto1 dto);
    }
}
