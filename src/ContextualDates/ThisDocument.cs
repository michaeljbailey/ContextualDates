using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Tools.Word;
using Label = System.Windows.Forms.Label;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace ContextualDates
{
    public partial class ThisDocument
    {
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            Content.Text = "This is 01/01/2014. Now it is 02/14/1987. Now it is 09/09/2014.";

            BeforeSave += OnBeforeSave;
        }

        private void OnBeforeSave(object sender, SaveEventArgs saveEventArgs)
        {
            var text = Content.Text;
            var myRegex = new Regex(@"\d{2}/\d{2}/\d{4}");
            var totalLength = 0;
            for (var i = 1; i <= Sentences.Count; i++)
            {
                var matchCollection = myRegex.Matches(Sentences[i].Text);
                if (matchCollection.Count > 0)
                {
                    foreach (Match match in matchCollection)
                    {
                        object matchStartIndex = totalLength+match.Index;
                        object matchEndIndex = ((int) matchStartIndex) + 10;
                        Comments.Add(Range(ref matchStartIndex, ref matchEndIndex),
                            string.Format("{0:d} is here", match.Value));
                    }
                    
                }
                totalLength += Sentences[i].Text.Count()+1; // Not sure why the +1 needs to be here, but there it is...
            }
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
