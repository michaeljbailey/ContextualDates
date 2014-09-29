using System.Collections.Generic;
using ContextualDates.Library;
using ContextualDates.Library.Services;
using Microsoft.Office.Tools.Word;
using Office = Microsoft.Office.Core;

namespace ContextualDates
{
    public partial class ThisDocument
    {
        private IDateContextParsingService _dateContextParsingService;
        private IDateCommentService _dateCommentService;

        
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            _dateContextParsingService = new DateContextParsingService();
            _dateCommentService = new DateCommentService(this);
            Content.Text = "This is 01/01/2014. Why do I need to add +1 to the index for each sentence?! Now it is 02/14/1987. This is an interim sentence. Now it is 09/09/2014.";

            BeforeSave += OnBeforeSave;
        }

        private void OnBeforeSave(object sender, SaveEventArgs saveEventArgs)
        {
            var dateContexts = _dateContextParsingService.ParseOutDateContexts(Content.Text);
            _dateCommentService.CommentDates(dateContexts);
        }


        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
