using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Metadata.Event
{
    public class PageChangedEventArgs : EventArgs
    {
        public QPage Page { get; set; }
        public PageDirection Direction { get; set; }

        public PageChangedEventArgs(PageDirection direction, QPage page) 
        {
            Page = page;
            Direction = direction;
        }
    }
}
