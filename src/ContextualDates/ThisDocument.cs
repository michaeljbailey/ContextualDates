using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Tools.Word.Controls;
using Microsoft.VisualStudio.Tools.Applications.Runtime;

using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace ContextualDates
{
    public partial class ThisDocument
    {
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            
            var activeWindowWidth = ActiveWindow.Width;
            var width = activeWindowWidth/3;
            var left = width;
            var controlSite = Controls.AddControl(new Microsoft.Office.Tools.Word.Controls.Label
            {
                Text = @"Hey, welcome to Contextual Dates!",
                Font = new Font("Arial", 40),
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = Color.BlanchedAlmond
            }, 0 , 50, width, 100,
                "ContextualDateIdentifier");
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
