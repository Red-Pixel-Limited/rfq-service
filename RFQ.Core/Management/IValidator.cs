namespace RFQ.Core.Management
{
    using System.Collections.Generic;

    public interface IValidator<in T>
    {
        bool IsValid(T source);
        IEnumerable<string> BrokenRules(T source);
    }
}
