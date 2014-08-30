using System;
using System.Collections.Generic;

namespace ContextualDates
{
    public class Anchor
    {
        public List<DateContext> Contexts { get; set; }
        public DateTime AnchorDate { get; set; }
    }
}