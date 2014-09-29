using System.Collections.Generic;
using ContextualDates.Library;

namespace ContextualDates
{
    public interface IDateCommentService
    {
        void CommentDates(IEnumerable<DateContext> dateContexts);
    }
}