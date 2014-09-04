using System.Collections.Generic;
using System.Linq;

namespace ContextualDates.Library.Services
{
    public class ContextualDatesService
    {
        public DateContext IdentifyContext(int cursorIndex, List<Anchor> anchors)
        {
            var context =
                anchors.First(anchor => anchor.StartIndex <= cursorIndex && anchor.EndIndex >= cursorIndex)
                    .Contexts.First(
                        dateContext => dateContext.StartIndex <= cursorIndex && dateContext.EndIndex >= cursorIndex);

            return context;
        }
    }
}