using System.Collections.Generic;
using ContextualDates.Library;

namespace ContextualDates
{
    public class DateCommentService : IDateCommentService
    {
        private readonly ThisDocument _thisDocument;

        public DateCommentService(ThisDocument thisDocument)
        {
            _thisDocument = thisDocument;
        }

        public void CommentDates(IEnumerable<DateContext> dateContexts)
        {
            foreach (var dateContext in dateContexts)
            {
                object startIndex = dateContext.StartIndex;
                object endIndex = dateContext.EndIndex;
                _thisDocument.Comments.Add(_thisDocument.Range(ref startIndex, ref endIndex),
                    string.Format("{0:d} is here", dateContext.ContextDateTime));
            }
        }
    }
}