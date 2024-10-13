using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Query
{
    public class QPage
    {
        private int totalRows;

        public int TotalRows
        {
            get { return totalRows; }
            set { totalRows = value; }
        }
        private int totalPages;

        public int TotalPages
        {
            get 
            {
                totalPages = totalRows % PageSize == 0 ? totalRows / PageSize : totalRows / PageSize + 1;
                return totalPages;
            }
        }
        private int pageSize;

        public int PageSize
        {
            get {
                if (pageSize <= 0)
                {
                    return 20;
                }
                else
                {
                    return pageSize;
                }
            }
            set { pageSize = value; }
        }
        private int pageIndex;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        public QPage()
        {
            this.pageSize = 25;
        }

        public QPage(int pageSize) 
        {
            this.pageSize = pageSize;
        }
    }
}
