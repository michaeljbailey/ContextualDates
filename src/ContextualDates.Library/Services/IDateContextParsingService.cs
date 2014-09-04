using System.Collections.Generic;

namespace ContextualDates.Library.Services
{
    public interface IDateContextParsingService
    {
        List<DateContext> ParseOutDateContexts(Anchor anchor);
    }
}