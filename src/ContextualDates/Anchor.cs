using System;
using System.Collections.Generic;

namespace ContextualDates
{
    public class Anchor
    {
        public List<DateContext> Contexts { get; set; }
        public DateTime AnchorDate { get; set; }
        public String DocumentText { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}