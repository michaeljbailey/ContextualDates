using System.Collections.Generic;

namespace ContextualDates.Services
{
    public interface IDateContextParsingService
    {
        List<DateContext> ParseOutDateContexts(Anchor anchor);
    }
}