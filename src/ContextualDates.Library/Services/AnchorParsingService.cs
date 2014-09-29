using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContextualDates.Library.Services
{
    public class AnchorParsingService
    {
        private readonly IDateContextParsingService _dateContextParsingService;

        public AnchorParsingService(IDateContextParsingService dateContextParsingService)
        {
            _dateContextParsingService = dateContextParsingService;
        }

        public List<Anchor> ParseOutAnchors(string documentText)
        {
            var regex = new Regex(@"(\d{2})/(\d{2})/(\d{4})"); //Totally not married to this implementation. Also, it only gets one expression
            var matches = regex.Matches(documentText);
            var anchors = new List<Anchor>();

            /* 
             * In my head, the implementation following goes such that:
             *  1. Regex out all datetime indexes as a base for building anchors and contexts
             *  2. Reorder the indexes to be contiguous
             *  3. Call out to a datecontextservice to parse out nonexact datetimes ("A week later", "a month later", etc)
             */
            foreach (Match match in matches)
            {
                var anchor = new Anchor
                {
                    AnchorDate = Convert.ToDateTime(match.Value),
                    DocumentText = documentText
                };
                //anchor.Contexts = _dateContextParsingService.ParseOutDateContexts(anchor);
                anchors.Add(anchor);
            }
            return anchors;
        }
    }
}