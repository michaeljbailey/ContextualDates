using System.Collections.Generic;

namespace ContextualDates.Library.Services
{
    public class DateContextParsingService : IDateContextParsingService
    {
        public List<DateContext> ParseOutDateContexts(Anchor anchor)
        {
            var dateContexts = new List<DateContext>();

            //NLP algo implementation goes here, NBD
            //Starting out simple with the anchor itself
            dateContexts.Add(new DateContext
            {
                StartIndex = 0,
                EndIndex = anchor.DocumentText.Length - 1
            });
            return dateContexts;
        }
    }
}