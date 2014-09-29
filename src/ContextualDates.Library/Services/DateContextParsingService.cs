using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContextualDates.Library.Services
{
    public class DateContextParsingService : IDateContextParsingService
    {
        public List<DateContext> ParseOutDateContexts(string documentText)
        {
            var dateContexts = new List<DateContext>();

            var myRegex = new Regex(@"\d{2}/\d{2}/\d{4}");

            var matchCollection = myRegex.Matches(documentText);
            if (matchCollection.Count > 0)
            {
                var matchCount = 0;
                foreach (Match match in matchCollection)
                {
                    dateContexts.Add(new DateContext
                    {
                        StartIndex = match.Index + matchCount,
                        EndIndex = match.Index + matchCount + 10,
                        ContextDateTime = DateTime.Parse(match.Value)
                    });
                    matchCount++;
                }

            }
            
            return dateContexts;
        }
    }
}