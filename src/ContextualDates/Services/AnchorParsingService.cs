using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContextualDates.Services
{
    public class AnchorParsingService
    {
        public List<Anchor> ParseOutAnchors(string documentText)
        {
            var regex = new Regex(@"(\d{2})/(\d{2})/(\d{4})"); //Totally not married to this implementation. Also, it only gets one expression
            var matches = regex.Matches(documentText);
            var anchors = new List<Anchor>();
            foreach (Match match in matches)
            {
                anchors.Add(new Anchor
                {
                    AnchorDate = Convert.ToDateTime(match.Value),
                    Contexts = null
                });
            }
            return anchors;
        }
    }
}